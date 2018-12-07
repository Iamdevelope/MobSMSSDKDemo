using System;
using System.Collections;
using System.Collections.Generic;
using TarenaMVC.Interfaces;
using UnityEngine;

namespace TarenaMVC.Core
{
    /// <summary>
    ///  管理Proxy
    /// </summary>
    public class Model : IModel
    {
        #region 单例
        private static Model _instance;
        public static Model instance
        {
            get
            {
                if( _instance == null ) _instance = new Model();
                return _instance;
            }
        }

        public static Model I()
        {
            return instance;
        }

        public Model()
        {
            if( _instance != null )
                Debug.LogError( "请使用Model.instance获取实例" );

            _instance = this;
            proxyMap = new Dictionary<string , IProxy>();
        }
        #endregion

        #region 管理Proxy
        /// <summary>
        /// 存储IProxy
        /// </summary>
        private Dictionary<string , IProxy> proxyMap;
        /// <summary>
        /// 注册IProxy
        /// </summary>
        /// <param name="proxy"></param>
        public void RegisterProxy( IProxy proxy )
        { 
            proxyMap[proxy.proxyName] = proxy;
        }
        /// <summary>
        /// 移除IProxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        public IProxy RemoveProxy( string proxyName )
        {
            IProxy proxy = proxyMap.ContainsKey( proxyName ) ?
                proxyMap[proxyName] : null;
            if( proxy != null ) proxyMap.Remove( proxyName );
            return proxy;
        }
        /// <summary>
        /// 获取IProxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        public IProxy RetrieveProxy( string proxyName )
        {
            IProxy proxy = proxyMap.ContainsKey( proxyName ) ?
                proxyMap[proxyName] : null;
            return proxy;
        }

        #endregion
    }
}

