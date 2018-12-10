using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
/// 
/// </summary>
public class NotificationList
{
    // 用户系统
    public const string LOGIN = "Login"; // 登录
    public const string REGISTER = "Register"; // 注册
    public const string LOGOUT = "Logout"; // 注销
    // 角色系统
    public const string GET_USER_HERO_LIST = "GetUserHeroList";
    public const string GET_HERO_LIST = "GetHeroListr";
    public const string CREATE_HERO = "CreateHero";
    public const string HERO_STAGE = "HeroStage"; // 创建英雄场景
    public const string SWITCH_HERO = "SwitchHero";
    public const string ADD_MONEY = "AddMoney";
    public const string ADD_EXP = "AddExp";
    public const string UPDATE_HERO_DATA = "UpdateHeroData";
    // 场景
    public const string PLAY_LEVEL = "PlayLevel";
    public const string LEVEL_LOADED = "LevelLoaded";
    public const string UNLOAD_LEVEL = "UnloadLevel";
    public const string TRY_EXIT_GAME = "TryExitGame";

    //技能
    public const string UPDATE_SKILL_DATA = "UpdateSkillData";
    public const string GET_SKILL_LIST = "GetSkillList";
 
    // 成功状态
    public const string SUCCESS = "Success"; // 成功
    public const string FAILURE = "Failure"; // 失败
    // 动作(显示和隐藏)
    public const string SHOW = "Show";
    public const string HIDE = "Hide";
}
