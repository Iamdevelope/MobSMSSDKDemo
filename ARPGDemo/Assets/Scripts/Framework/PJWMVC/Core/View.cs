using System;
using System.Collections;
using System.Collections.Generic;
using PJWMVC.Interfaces;
using UnityEngine;

namespace PJWMVC.Core
{
    /// <summary>
    ///  管理Mediator
    /// </summary>
    public class View : IView
    {
        #region 单例
        private static View _instance;
        public static View instance
        {
            get
            {
                if( _instance == null ) _instance = new View();
                return _instance;
            }
        }

        public static View I()
        {
            return instance;
        }

        public View()
        {
            if( _instance != null )
                Debug.LogError( "请使用View.instance获取实例" );

            _instance = this;
            mediatorMap = new Dictionary<string , IMediator>();
        }
        #endregion

        #region 管理Mediator
        /// <summary>
        /// 存储IMediator
        /// </summary>
        private Dictionary<string , IMediator> mediatorMap;
        /// <summary>
        /// 注册IMediator
        /// </summary>
        /// <param name="mediator"></param>
        public void RegisterMediator( IMediator mediator )
        { 
            // 存放到字典里面
            mediatorMap[mediator.mediatorName] = mediator;
            // 找到所有的监听消息
            string[] notifications = mediator.listNotificationInterests();
            // 遍历所有消息
            for( int i = 0 ; i < notifications.Length ; i++ )
            {
                NotificationCenter.I().AddObserver( notifications[i] ,
                    mediator );
            }
            // 添加IObserver
        }
        /// <summary>
        /// 移除IMediator
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns></returns>
        public IMediator RemoveMediator( string mediatorName )
        {
            IMediator mediator = mediatorMap.ContainsKey( mediatorName ) ?
                mediatorMap[mediatorName] : null;
            if( mediator != null )
            {
                mediatorMap.Remove( mediatorName );
                // 找到所有的监听消息
                string[] notifications = mediator.listNotificationInterests();
                // 遍历所有消息
                for( int i = 0 ; i < notifications.Length ; i++ )
                {
                    NotificationCenter.I().RemoveObserver( notifications[i] ,
                        mediator );
                }
                // 移除IObserver
            }
            return mediator;
        }
        /// <summary>
        /// 获取IMediator
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns></returns>
        public IMediator RetrieveMediator( string mediatorName )
        {
            IMediator mediator = mediatorMap.ContainsKey( mediatorName ) ?
                mediatorMap[mediatorName] : null;
            return mediator;
        }

        #endregion
    }
}

