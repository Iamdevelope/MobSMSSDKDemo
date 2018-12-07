using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace TarenaMVC.Interfaces
{
    /// <summary>
    ///  UI和数据之间的桥梁: 监听和处理消息
    /// </summary>
    public interface IMediator:IObserver,INotifier
    {
       /// <summary>
       /// 名称
       /// </summary>
        string mediatorName { get; set; }
        /// <summary>
        /// 监听的消息数组
        /// </summary>
        /// <returns></returns>
        string[] listNotificationInterests();
    }
}

