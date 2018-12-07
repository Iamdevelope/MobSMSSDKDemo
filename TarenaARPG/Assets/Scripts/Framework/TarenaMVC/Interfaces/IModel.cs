﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
namespace TarenaMVC.Interfaces
{
    /// <summary>
    ///  管理IProxy
    /// </summary>
    public interface IModel
    {    
        /// <summary>
        /// 注册IProxy
        /// </summary>
        /// <param name="proxy"></param>
        void RegisterProxy( IProxy proxy );
        /// <summary>
        /// 移除IProxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        IProxy RemoveProxy( string proxyName );
        /// <summary>
        /// 获取IProxy
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns></returns>
        IProxy RetrieveProxy( string proxyName );
    }
}

