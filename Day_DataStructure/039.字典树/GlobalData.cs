using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class GlobalData
    {
        private static GlobalData _instance;

        public static GlobalData Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new GlobalData();
                }
                return _instance;
            }
        }


        public delegate string GetStrValuePara1Fun(string s);

        public GetStrValuePara1Fun ReplaceSensitiveWordsToStarFunction;

        public string ReplaceSensitiveWords(string s)
        {
            if(ReplaceSensitiveWordsToStarFunction != null)
            {
                return ReplaceSensitiveWordsToStarFunction(s);
            }
            return s;
        }
    }
}
