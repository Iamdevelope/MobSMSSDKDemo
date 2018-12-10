using System.Collections;
using System.Collections.Generic;
using PJWMVC.Patterns;
using TRPG.Module;
using TRPG.MVC.Models;
using UnityEngine;
 
namespace TRPG.MVC.Views
{
    /// <summary>
    /// 角色(英雄)系统的Mediator
    /// </summary>
    public class HeroMediator:BaseMediator
    {
        /// <summary>
        /// NAME
        /// </summary>
        public new const string NAME = "HeroMediator";
        /// <summary>
        /// 构造函数
        /// </summary>
        public HeroMediator()
        {
            this.mediatorName = NAME;
        }
        /// <summary>
        /// 监听的消息
        /// </summary>
        /// <returns></returns>
        public override string[] listNotificationInterests()
        {
            return new string[]
            {
                NotificationList.GET_USER_HERO_LIST, // 获取用户英雄列表
                NotificationList.GET_USER_HERO_LIST + SUCCESS, // 获取用户英雄列表成功
                NotificationList.UPDATE_HERO_DATA, // 更新英雄数据
                SHOW + NotificationList.HERO_STAGE, // 显示HeroStage
                HIDE +  NotificationList.HERO_STAGE, // 隐藏HeroStage
                NotificationList.GET_HERO_LIST, // 获取系统英雄列表
                NotificationList.GET_HERO_LIST + SUCCESS, // 获取系统英雄列表成功
                NotificationList.SWITCH_HERO, // 切换英雄
                NotificationList.CREATE_HERO, // 创建英雄
                NotificationList.CREATE_HERO + SUCCESS, // 创建英雄成功
                NotificationList.CREATE_HERO + FAILURE // 创建英雄失败
            };
        }
        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="notification"></param>
        public override void HandleNotification( Notification notification )
        {
            Debug.Log( NAME + " : HandleNotification :: " + notification.name );
            switch( notification.name )
            {
                case NotificationList.GET_USER_HERO_LIST: // 获取用户英雄列表
                    heroProxy.GetUserHeroList();
                    break;
                case NotificationList.GET_USER_HERO_LIST + SUCCESS:// 获取用户英雄列表成功
                    // 如何找到heroPanel
                    HeroPanel heroPanel = UIManager.GetPanel<HeroPanel>();
                    // UpdateHeroList
                    heroPanel.UpdateHeroList( notification.data as ArrayList );
                    break;
                case NotificationList.UPDATE_HERO_DATA:// 更新英雄数据
                    HeroStatusBar statusBar = UIManager.GetPanel<HeroStatusBar>( "MainPanel/HeroStatusBar" );
                    statusBar.UpdateData();
                    break;
                case SHOW + NotificationList.HERO_STAGE: // 显示HeroStage
                    // 隐藏HeroPanel
                    UIManager.TogglePanel( Panels.HeroPanel , false );
                    // 隐藏MainObjects
                    UIManager.ToggleObjects( Tags.MainObjects , false );
                    // 显示HeroObjects
                    UIManager.ToggleObjects( Tags.HeroObjects , true );
                    heroStage.Show( notification.data + "");
                    break;
                case HIDE + NotificationList.HERO_STAGE: // 隐藏HeroStage
                    // 显示MainObjects
                    UIManager.ToggleObjects( Tags.MainObjects , true );
                    //隐藏 HeroObjects
                    UIManager.ToggleObjects( Tags.HeroObjects , false );
                    break;
                case NotificationList.GET_HERO_LIST: // 获取系统英雄列表
                    heroProxy.GetHeroList();
                    break;
                case NotificationList.GET_HERO_LIST + SUCCESS: // 获取系统英雄列表成功
                    Debug.Log( "SwitchHero " + notification.data );
                    heroStage.map = notification.data as Dictionary<string , HeroVO>;
                    heroStage.SwitchHero( "Wizard" );
                    break;
                case NotificationList.SWITCH_HERO:// 切换英雄
                    heroStage.SwitchHero( notification.data + "" );
                    break;
                case NotificationList.CREATE_HERO: // 创建英雄
                    heroProxy.CreateHero( notification.data as UserHeroVO );
                    break;
                case NotificationList.CREATE_HERO + SUCCESS: // 创建英雄成功
                    SendNotification( HIDE + NotificationList.HERO_STAGE );
                    break;
                case NotificationList.CREATE_HERO + FAILURE: // 创建英雄失败
                    Alert.Show( "出错了" , notification.data + "" );
                    break;
                default:
                    Debug.LogError( NAME + "未处理的消息:" + notification.name );
                    break;
            }
        }

        protected HeroStage heroStage
        {
            get { return UIManager.GetPanel<HeroStage>(); }
        }
       
        public override string ToString()
        {
            return NAME;
        }

    }
}

