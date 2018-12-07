using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 namespace TarenaMVC.Patterns
{
    /// <summary>
    /// 消息的数据结构
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// 消息名称
        /// </summary>
        public string name;
        /// <summary>
        /// 消息数据
        /// </summary>
        public object data;
        /// <summary>
        ///  构造函数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public Notification( string name, object data=null)
        {
            this.name = name;
            this.data = data;
        }
    }
}

