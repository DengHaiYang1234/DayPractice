--主入口函数。从这里开始lua逻辑

Main = {}


print("主入口函数。从这里开始lua逻辑0")
function Main.main()
    print("主入口函数。从这里开始lua逻辑1")
    Util = LuaFramework.Util
    print('主入口函数。从这里开始lua逻辑2')
    Util.Log("Hello World For Lua is shit")	
end
 
