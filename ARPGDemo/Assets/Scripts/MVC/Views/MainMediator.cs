using System;
using System.Collections;
using System.Collections.Generic;
using PJWMVC.Patterns;
using TRPG.Module;
using TRPG.MVC.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TRPG.MVC.Views
{
    /// <summary>
    /// 主城系统的Mediator
    /// </summary>
    public class MainMediator:Mediator
    {
        /// <summary>
        /// NAME
        /// </summary>
        public new const string NAME = "MainMediator";
        /// <summary>
        /// 构造函数
        /// </summary>
        public MainMediator()
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
                NotificationList.LOGOUT, // 注销
                NotificationList.PLAY_LEVEL, // 加载场景
                NotificationList.LEVEL_LOADED, // 场景加载完毕
                NotificationList.UNLOAD_LEVEL, // 卸载场景
                NotificationList.TRY_EXIT_GAME // 尝试退出游戏
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
                case NotificationList.PLAY_LEVEL: // 加载场景
                    loader.LoadScene( notification.data + "" );
                    break;
                case NotificationList.LEVEL_LOADED: // 场景加载完毕
                    // 关闭Map
                    UIManager.TogglePanel( Panels.Map , false );
                    // 隐藏MainObjects
                    UIManager.ToggleObjects( Tags.MainObjects , false );
                    break;
                case NotificationList.UNLOAD_LEVEL:
                    loader.UnloadScene( notification.data + "" );
                    // 显示MainObjects
                    UIManager.ToggleObjects( Tags.MainObjects , true );
                    break;
                case NotificationList.TRY_EXIT_GAME:
                    Alert.Show( "退出副本" , "中途退出副本没有任何奖励!" , 
                        TryExitGame , notification.data );
                    break;
                default:
                    Debug.LogError( NAME + "未处理的消息:" + notification.name );
                    break;
            }
        }

        private void TryExitGame( object arg )
        {
            SendNotification( NotificationList.UNLOAD_LEVEL , arg );
        }

        protected SceneLoader _loader;
        protected SceneLoader loader
        {
            get
            {
                if( _loader == null ) _loader = GameController.instance.GetComponent<SceneLoader>();
                return _loader;
            }
        }
        protected ApplicationFacade facade
        {
            get { return ApplicationFacade.I(); }
        }

        private UserProxy _userProxy;
        protected UserProxy userProxy
        {
            get
            {
                if( _userProxy == null )
                    _userProxy = facade.RetrieveProxy( UserProxy.NAME ) as UserProxy;
                return _userProxy;
            }
        }

        public override string ToString()
        {
            return NAME;
        }

    }
}

