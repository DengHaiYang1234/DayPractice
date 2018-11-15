using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HotFix;
using System;
/*  
 *  
 *   实测可完成PC和Android热更.
1.资源打包入口: PackageBuild() ---> 选择不同平台 打包不同平台资源资源  资源默认打包.Lua打包需设置AppConst中LuaBunldeMode = true；
                                  打包资源切记刷新 AssetDatabase.Refresh();
2.项目入口： Main（）
3.资源下载更新：HotManager() ---> 检查是否存在已经资源文件.
                         若不存在（第一次安装游戏）,先解压项目的文件资源（游戏包资源目录 只读）至本地数据目录（可读可写）.
                         若已经存在，那么通过网络资源地址中的网络资源，与本地文件比对。检测是否需要更新（是否能进行更新主要是通过比对文件MD5）.
4.资源下载：ThreadManager() ---> 通过检测队列中是否有元素来下载资源.（lock还有点问题）
5.Lua虚拟机：LuaManager()  ---> (1) 设置lua的加载路径（可直接加载也可打包加载）.
                               (2) 启动lua虚拟机.使在Lua中也可调用C#的方法等
6.资源加载：ResourceManager() ---> 加载AB中的资源
7.日志输出：LTDebugOutput() ---> 控制Debug的打印至屏幕。并将Debug日志跟随游戏保存.
*/

public class GamerManager : BaseClass
{
    #region 游戏管理类
    public void Awake()
    {
        SDRootPath.Instance.Init();
        HotManager_.Init();
    }


    private void Start()
    {
        if (LTDebugOutput.Instance != null)
        {
            LTDebugOutput.Instance.Init();
        }
    }


    #endregion
}
