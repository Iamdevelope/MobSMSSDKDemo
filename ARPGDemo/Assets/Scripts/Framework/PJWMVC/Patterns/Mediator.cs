using System;
using System.Collections;
using System.Collections.Generic;
using PJWMVC.Core;
using PJWMVC.Interfaces;
using UnityEngine;

namespace PJWMVC.Patterns
{
    /// <summary>
    ///  UI和数据之间的桥梁: 监听和处理消息
    /// </summary>
    public class Mediator : IMediator
    {
        /// <summary>
        /// NAME
        /// </summary>
        public const string NAME = "Mediator";
        /// <summary>
        ///  构造函数
        /// </summary>
        public Mediator()
        {
            this.mediatorName = NAME;
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string mediatorName { get; set; }


        /// <summary>
        /// 监听消息数组
        /// </summary>
        /// <returns></returns>
        public virtual string[] listNotificationInterests()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="notification"></param>
        public virtual void HandleNotification( Notification notification )
        {
            
        }
        /// <summary>
        ///  发送消息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void SendNotification( string name , object data = null )
        {
            Facade.I().SendNotification( name , data );
        }
    }
}

