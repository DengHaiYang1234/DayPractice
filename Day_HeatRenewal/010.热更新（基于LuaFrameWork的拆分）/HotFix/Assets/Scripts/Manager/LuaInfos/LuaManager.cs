using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;


namespace HotFix
{
    public class LuaManager : BaseClass
    {
        private LuaState lua;
        private LuaLoader loader;
        private LuaLooper loop = null;

        private void Awake()
        {
            loader = new LuaLoader();
            lua = new LuaState();
            this.OpenLibs();
            lua.LuaSetTop(0);
            LuaBinder.Bind(lua);
            LuaCoroutine.Register(lua, this);
        }


        public void InitStart()
        {
            InitLuaPath();
            InitLuaBunlde();
            this.lua.Start();
            this.StartMain();
            this.StartLooper();
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

        void InitLuaPath()
        {
            if (AppConst.DebugMode)
            {
                string rootPath = AppConst.HotFixRoot;

                lua.AddSearchPath(rootPath + "/Lua/");
                lua.AddSearchPath(rootPath + "/ToLua/Lua/");
            }
            else
                lua.AddSearchPath(Util.DataPath + "lua");
        }


        void InitLuaBunlde()
        {
            if (loader.beZip)
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
        }

        void StartLooper()
        {
            loop = gameObject.AddComponent<LuaLooper>();
            loop.luaState = lua;
        }

        public void DoFile(string fileName)
        {
            lua.DoFile(fileName);
        }

        public object[] CallFunction(string funcName, params object[] args)
        {
            LuaFunction func = lua.GetFunction(funcName);
            if (func != null)
                return func.Call(args);

            return null;
        }
    }
}

