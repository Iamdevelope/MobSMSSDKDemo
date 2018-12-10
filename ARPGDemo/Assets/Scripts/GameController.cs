using System.Collections;
using System.Collections.Generic;
using TRPG.Module;
using TRPG.MVC;
using UnityEngine;
 
/// <summary>
///  整个程序的入口文件
/// </summary>
public class GameController:MonoBehaviour
{
    public static GameController instance;
    public UserVO crtUser; // 当前登录用户
    public UserHeroVO crtHero; // 当前用户英雄
    public SkillInfo skillInfo; //当前技能
    private void Start()
    {
        instance = this;
        Debug.Log( "游戏启动了..." );
        //FPS: Frames Per Second
        Application.targetFrameRate = 30; //限制帧频为30
        // 自动隐藏主城界面
        UIManager.ToggleObjects( Tags.MainObjects , false );
        // 自动隐藏HeroObjects
        UIManager.ToggleObjects( Tags.HeroObjects , false );
        // 启动MVC框架
        ApplicationFacade.I().Startup();
    }
}
