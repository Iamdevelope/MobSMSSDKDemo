using System;
using System.Collections;
using System.Collections.Generic;
using PJWMVC.Interfaces;
using UnityEngine;

namespace PJWMVC.Core
{
    /// <summary>
    ///  7大功能:无处不在,无所不能
    /// </summary>
    public class Facade:IFacade
    {
        // 单例
        #region 单例
        protected static Facade _instance;
        public static Facade instance
        {
            get
            {
                if( _instance == null ) _instance = new Facade();
                return _instance;
            }
        }

        public static Facade I()
        {
            return instance;
        }

        public Facade()
        {
            if( _instance != null )
                Debug.LogError( "请使用Facade.instance获取实例" );

            _instance = this;
        }
        #endregion
        #region 管理Mediator
        /// <summary>
        /// 注册Mediator
        /// </summary>
        /// <param name="mediator"></param>
        public void RegisterMediator( IMediator mediator )
        {
            View.I().RegisterMediator( mediator );
        }
        /// <summary>
        /// 移除Mediator
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns></returns>
        public IMediator RemoveMediator( string mediatorName )
        {
            return View.I().RemoveMediator( mediatorName );
        }
        /// <summary>
        /// 获取Mediator
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns></returns>
        public IMediator RetrieveMediator( string mediatorName )
        {
            return View.I().RetrieveMediator( mediatorName );
        }
        #endregion

        #region  管理Proxy
        /// <summary>
        /// 注册Proxy
        /// </summary>
        /// <param name="proxy"></param>
        public void RegisterProxy( IProxy proxy )
        {
            Model.I().RegisterProxy( proxy );
        }
        /// <summary>
        /// 移除Proxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        public IProxy RemoveProxy( string proxyName )
        {
            return Model.I().RemoveProxy( proxyName );
        }
        /// <summary>
        /// 获取Proxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        public IProxy RetrieveProxy( string proxyName )
        {
            return Model.I().RetrieveProxy( proxyName );
        }


        #endregion



        /// <summary>
        ///  发送消息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void SendNotification( string name , object data =null )
        {
            NotificationCenter.I().SendNotification( name , data );
        }
    }
}

