--主入口函数。从这里开始lua逻辑


Main = {}

print("Hello World For Lua is shit0")
function Main.main()
    print("Hello World For Lua is shit1")
    Util = HotFix.Util
    print('Hello World For Lua is shit2')
    Util.Log("这是用来测试CustomSettings")	
end

function Main.start()
    print('这是测试start')
end
 
