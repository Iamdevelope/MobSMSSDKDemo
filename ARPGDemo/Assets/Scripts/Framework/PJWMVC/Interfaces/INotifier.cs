using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 namespace PJWMVC.Interfaces
{
    /// <summary>
    ///  消息发送接口
    /// </summary>
    public interface INotifier
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        void SendNotification( string name , object data );
    }
}

