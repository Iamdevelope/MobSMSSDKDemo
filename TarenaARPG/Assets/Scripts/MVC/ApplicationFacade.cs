using System.Collections;
using System.Collections.Generic;
using TarenaMVC.Core;
using TRPG.MVC.Models;
using TRPG.MVC.Views;
using UnityEngine;
 
namespace TRPG.MVC
{
    /// <summary>
    ///  TarenaMVC的入口
    /// </summary>
    public class ApplicationFacade:Facade
    {
        public static ApplicationFacade instance
        {
            get
            {
                if( _instance == null ) _instance = new ApplicationFacade();
                return _instance as ApplicationFacade;
            }
        }

        public static ApplicationFacade I()
        {
            return instance;
        }
        /// <summary>
        /// 启动MVC框架
        /// 注册Proxy
        /// 注册Mediator
        /// </summary>
        public void Startup()
        {
            Debug.Log( "MVC框架启动..." );
            //注册Proxy
            RegisterProxy( new UserProxy() );
            RegisterProxy( new HeroProxy() );
            //注册Mediator
            RegisterMediator( new UserMediator() );
            RegisterMediator( new MainMediator() );
            RegisterMediator( new HeroMediator() );
            // 查看消息的监听
            NotificationCenter.I().View();
            // 移除MainMediator
            //RemoveMediator( MainMediator.NAME );
            // 查看消息的监听
            //NotificationCenter.I().View();

            //NotificationCenter.I().SendNotification( NotificationList.LOGOUT );
        }
    }
}

