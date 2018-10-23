using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            SensitiveWords.Instance.Init();
            Console.WriteLine("敏感词测试：" + GlobalData.Instance.ReplaceSensitiveWords("111123"));
        }
    }


    public struct WordNodeKeyValue
    {
        public string key;
        public WordNode value;
    }

    public sealed class WordNode
    {
        public string word;
        public int endTag;
        public WordNodeMap wordNodes = new WordNodeMap();

        public WordNode(string word)
        {
            Reset(word);
        }

        public void Reset(string word)
        {
            this.word = word;
            endTag = 0;
            wordNodes.Clear();
        }

        public void Dispose()
        {
            Reset(string.Empty);
        }
    }

    public sealed class WordNodeMap
    {
        public WordNodeKeyValue[] wordNodes = null;

        public WordNode this[string key]
        {
            get
            {
                if (wordNodes == null)
                    return null;

                for(var i = 0;i < wordNodes.Length;i++)
                {
                    if (wordNodes[i].key == key)
                        return wordNodes[i].value;
                }
                return null;
            }

            set
            {
                if(wordNodes == null)
                {
                    Console.WriteLine("第一次");
                    wordNodes = new WordNodeKeyValue[1];  //value
                    //添加首元素
                    wordNodes[0] = new WordNodeKeyValue() { key = key, value = value };
                }
                else
                {
                    var needAdd = true;
                    for(var i = 0; i < wordNodes.Length;i++)
                    {
                        Console.WriteLine("下一次");
                        if (wordNodes[i].key == key)
                        {
                            wordNodes[i].value = value;
                            needAdd = false;
                        }
                    }

                    if(needAdd)
                    {
                        var newWordNodes = new WordNodeKeyValue[wordNodes.Length + 1];
                        Array.Copy(wordNodes, newWordNodes, wordNodes.Length);
                        newWordNodes[wordNodes.Length] = new WordNodeKeyValue() { key = key, value = value };
                        wordNodes = newWordNodes;
                    }
                }
            }
        }

        public bool TryGetValue(string key,out WordNode value)
        {
            value = null;
            if(wordNodes == null)
            {
                return false;
            }
            for(var i = 0; i < wordNodes.Length;i++)
            {
                if(wordNodes[i].key == key)
                {
                    value = wordNodes[i].value;
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            wordNodes = null;
        }
    }

    public class SensitiveWords
    {
        private static SensitiveWords _instance;
        public static SensitiveWords Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SensitiveWords();
                return _instance;
            }
        }
        private List<string> allSensitiveWords = new List<string>();
        private WordNode rootWordNode = null;
        private bool isInit = false;

        /// <summary>
        /// 切割并保存字符串.开始构造树结构
        /// </summary>
        /// <param name="words"></param>
        public void InitSensitiveWords(string words)
        {
            string[] wordArr = words.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            this.allSensitiveWords.Clear();
            this.allSensitiveWords.Capacity = wordArr.Length;
            for(int index = 0;index < wordArr.Length;index++)
            {
                this.allSensitiveWords.Add(wordArr[index]);
            }

            BuildWordTree();
            this.allSensitiveWords.Clear();
            this.isInit = true;
        }

        /// <summary>
        /// 构造树
        /// </summary>
        private void BuildWordTree()
        {
            //头结点
            if (this.rootWordNode == null)
                this.rootWordNode = new WordNode("R");
            //更新词库时的初始化
            this.rootWordNode.Reset("R");

            //构造子树
            for(int index = 0;index < this.allSensitiveWords.Count;index++)
            {
                string strTmp = this.allSensitiveWords[index];
                if (strTmp.Length > 0)
                    InsertNode(this.rootWordNode, strTmp);
            }
        }

        /// <summary>
        /// 添加树节点
        /// </summary>
        /// <param name="node"></param>  头结点
        /// <param name="content"></param> 
        private void InsertNode(WordNode node,string content)
        {
            if(node == null)
            {
                Console.WriteLine("root node is null");
                return;
            }
            
            string strTmp = content.Substring(0, 1);
            WordNode wordNode = FindNode(node, strTmp);
            //若不存在.那么就构造新节点
            if(wordNode == null)
            {
                wordNode = new WordNode(strTmp);
                node.wordNodes[strTmp] = wordNode;
            }

            strTmp = content.Substring(1);
            if(string.IsNullOrEmpty(strTmp))
            {
                wordNode.endTag = 1;
            }
            else
            {
                InsertNode(wordNode, strTmp);
            }
        }

        /// <summary>
        /// 是否已经存在的子节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private WordNode FindNode(WordNode node,string content)
        {
            if(node == null)
            {
                Console.WriteLine("root node is null");
                return null;
            }
            WordNode wordNode = null;
            node.wordNodes.TryGetValue(content, out wordNode);
            return wordNode;
        }

        public string FilterSensitiveWords(string content)
        {
            if(!isInit || rootWordNode == null)
            {
                return content;
            }

            string originalValue = content;
            content = content.ToLower();
            WordNode node = this.rootWordNode;
            StringBuilder buffer = new StringBuilder();
            List<string> badLst = new List<string>();
            int a = 0;
            while(a < content.Length)
            {
                string contentTmp = content.Substring(a);
                string strTmp = contentTmp.Substring(0, 1);
                node = FindNode(node, strTmp);
                if(node == null)
                {
                    node = this.rootWordNode;
                    a = a - badLst.Count;
                    if (a < 0)
                        a = 0;
                    badLst.Clear();
                    string beginContent = content.Substring(a);
                    if (beginContent.Length > 0)
                        buffer.Append(beginContent[0]);
                }
                else if(node.endTag == 1)
                {
                    badLst.Add(strTmp);
                    for(int index =0;index < badLst.Count;index++)
                    {
                        buffer.Append("*");
                    }

                    node = this.rootWordNode;
                    badLst.Clear();
                }
                else
                {
                    badLst.Add(strTmp);
                    if(a == content.Length - 1)
                    {
                        for(int index = 0;index < badLst.Count;index++)
                        {
                            buffer.Append(badLst[index]);
                        }
                    }
                }

                contentTmp = contentTmp.Substring(1);
                ++a;
            }

            string newValue = buffer.ToString();
            if(newValue.CompareTo(originalValue.ToLower()) != 0)
            {
                int idx = newValue.IndexOf('*');
                char[] originaArr = originalValue.ToCharArray();
                while(idx != -1)
                {
                    originaArr[idx] = '*';
                    idx = newValue.IndexOf('*', idx + 1);
                }

                originalValue = new string(originaArr);
            }

            return originalValue;
        }


        public void Init()
        {
            string sensitiveWord = "|112|211|121|";
            InitSensitiveWords(sensitiveWord);
            GlobalData.Instance.ReplaceSensitiveWordsToStarFunction = OutputCheckOutWords;
        }

        public string OutputCheckOutWords(string input)
        {
            string res = "";
            if(input != null)
            {
                res = FilterSensitiveWords(input);
            }

            return res;
        }
    }

}
