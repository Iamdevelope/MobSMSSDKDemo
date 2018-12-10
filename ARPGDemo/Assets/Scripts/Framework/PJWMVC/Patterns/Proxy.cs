using System;
using System.Collections;
using System.Collections.Generic;
using PJWMVC.Core;
using PJWMVC.Interfaces;
using UnityEngine;
namespace PJWMVC.Patterns
{
    /// <summary>
    ///  处理数据
    /// </summary>
    public class Proxy : IProxy
    {
        /// <summary>
        /// Proxy NAME
        /// </summary>
        public const string NAME = "Proxy";

        public Proxy()
        {
            this.proxyName = NAME;
        }
        /// <summary>
        /// proxy的名称
        /// </summary>
        public string proxyName { get; set; }
        /// <summary>
        ///  发送消息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void SendNotification( string name , object data =null)
        {
            Facade.I().SendNotification( name , data );
        }
    }
}

