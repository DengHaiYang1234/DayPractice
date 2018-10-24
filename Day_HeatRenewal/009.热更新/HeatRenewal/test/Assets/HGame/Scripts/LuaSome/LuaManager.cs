using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaFramework
{
    public class LuaManager : MonoBehaviour
    {
        private LuaState lua;
        private LuaLoader loader;
        private LuaLooper loop = null;
        
        void Awake()
        {
            loader = new LuaLoader();
            lua = new LuaState();
            Debug.LogError("lua:" + lua == null);
            this.OpenLibs();
            lua.LuaSetTop(0);
            LuaBinder.Bind(lua);
            LuaCoroutine.Register(lua, this);
        }

        public void InitStart()
        {
            InitLuaPath();
            InitLuaBundle();
            this.lua.Start();
            this.StartMain();
            this.StartLooper();
        }

        void StartLooper()
        {
            loop = gameObject.AddComponent<LuaLooper>();
            loop.luaState = lua;
        }

        //初始第三方库
        void OpenLibs()
        {
            lua.LuaGetField(LuaIndexes.LUA_REGISTRYINDEX, "_LOADED");
            lua.OpenLibs(LuaDLL.luaopen_bit);
            lua.LuaSetField(-2, "cjson");

            lua.OpenLibs(LuaDLL.luaopen_cjson_safe);
            lua.LuaSetField(-2, "cjson.safe");
        }

        /// <summary>
        /// ! cjson 比较特殊，只new了一个table，没有注册表，这里注册一下
        /// </summary>
        protected void OpenCJson()
        {
            lua.LuaGetField(LuaIndexes.LUA_REGISTRYINDEX, "_LOADED");
            lua.OpenLibs(LuaDLL.luaopen_cjson);
            lua.LuaSetField(-2, "cjson");

            lua.OpenLibs(LuaDLL.luaopen_cjson_safe);
            lua.LuaSetField(-2, "cjson.safe");
        }

        /// <summary>
        /// 初始化Lua代码加载路径
        /// </summary>
        void InitLuaPath()
        {
            if(AppConst.DebugMode)
            {
                string rootPath = AppConst.FrameworkRoot;
                
                Debug.Log(rootPath + "/Lua");
                lua.AddSearchPath(rootPath + "/Lua/");
                lua.AddSearchPath(rootPath + "/ToLua/Lua/");
            }
            else
            {
                lua.AddSearchPath(Util.DataPath + "lua");
            }
        }


        /// <summary>
        /// 初始化LuaBundle
        /// </summary>
        void InitLuaBundle()
        {
            if(loader.beZip)
            {
                loader.AddBundle("lua/lua");
                loader.AddBundle("lua/lua_cjson");
                loader.AddBundle("lua/lua_misc");
                loader.AddBundle("lua/lua_system");
                loader.AddBundle("lua/lua_system_reflection");
                loader.AddBundle("lua/lua_unityengine");
            }
        }

        void StartMain()
        {
            lua.DoFile("Main.lua");
            LuaFunction main = lua.GetFunction("Main.main");
            main.Call();
            main.Dispose();
            main = null;
            //此处重复加载lua的assetbundle了
            //if(loader.beZip)
            //{
            //    lua.DoFile("Main.lua");
            //    object[] assetBundels = CallFunction("GetAssetBundles");
            //    foreach(object obj in assetBundels)
            //    {
            //        string path = obj.ToString().Trim();
            //        if (string.IsNullOrEmpty(path))
            //            continue;
            //        loader.AddBundle(path);
            //    }
            //}
        }

        public object[] CallFunction(string funcName,params object[] args)
        {
            LuaFunction func = lua.GetFunction(funcName);
            if (func != null)
                return func.Call(args);

            return null;
        }

        public void DoFile(string fileName)
        {
            lua.DoFile(fileName);
        }
    }
}


