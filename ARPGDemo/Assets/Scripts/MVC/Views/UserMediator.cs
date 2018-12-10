using System.Collections;
using System.Collections.Generic;
using PJWMVC.Patterns;
using TRPG.Module;
using TRPG.MVC.Models;
using UnityEngine;
 
namespace TRPG.MVC.Views
{
    /// <summary>
    /// 用户系统的Mediator
    /// 用户系统UI发出的消息(LoginPanel LOGIN)
    /// 负责监听和处理用户系统相关消息
    /// </summary>
    public class UserMediator:BaseMediator
    {
        /// <summary>
        /// NAME
        /// </summary>
        public new const string NAME = "UserMediator";
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserMediator()
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
                NotificationList.LOGIN,
                NotificationList.LOGIN + SUCCESS,
                NotificationList.LOGIN + FAILURE,
                SHOW + NotificationList.LOGIN,
                SHOW + NotificationList.REGISTER,
                NotificationList.REGISTER,
                NotificationList.REGISTER +SUCCESS,
                NotificationList.REGISTER + FAILURE,
                NotificationList.LOGOUT
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
                case NotificationList.LOGIN: // 登录
                    userProxy.Login( notification.data as UserVO );
                    break;
                case NotificationList.LOGIN + SUCCESS:
                    Debug.Log( "登录成功,隐藏用户界面!" );
                    // 隐藏用户界面
                    UIManager.ToggleObjects( Tags.UserObjects , false );
                    // 显示主城界面
                    UIManager.ToggleObjects( Tags.MainObjects , true );
                    // 自动获取用户英雄列表
                    SendNotification( NotificationList.GET_USER_HERO_LIST );
                    break;
                case NotificationList.LOGIN + FAILURE:
                    Debug.LogError( "用户名或密码错误!" );
                    Alert.Show("登录失败", "用户名或密码错误!" );
                    break;
                case SHOW + NotificationList.LOGIN:
                    Debug.Log( "显示登录面板" );
                    UIManager.TogglePanel( Panels.RegisterPanel , false );
                    UIManager.TogglePanel( Panels.LoginPanel , true );
                    break;
                case SHOW + NotificationList.REGISTER:
                    Debug.Log( "显示注册面板" );
                    UIManager.TogglePanel( Panels.RegisterPanel , true );
                    UIManager.TogglePanel( Panels.LoginPanel , false );
                    break;
                case NotificationList.REGISTER:
                    userProxy.Register( notification.data as UserVO );
                    break;
                case NotificationList.REGISTER + SUCCESS:
                    SendNotification( SHOW + NotificationList.LOGIN );
                    Alert.Show("注册成功", "注册成功，开始战斗吧! ");
                    break;
                case NotificationList.REGISTER + FAILURE:
                    Alert.Show( "注册失败" , notification.data +"");
                    break;
                case NotificationList.LOGOUT:
                    // 显示用户界面
                    UIManager.ToggleObjects( Tags.UserObjects , true );
                    // 隐藏主城界面
                    UIManager.ToggleObjects( Tags.MainObjects , false );
                    break;
                default:
                    Debug.LogError( NAME + "未处理的消息:" + notification.name );
                    break;
            }
        }
        public override string ToString()
        {
            return NAME;
        }
    }
}