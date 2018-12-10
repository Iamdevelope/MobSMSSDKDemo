using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.MVC
{
    /// <summary>
    ///  可以发送消息的按钮
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class NotiButton : BaseMonoBehaviour
    {
        /// <summary>
        ///  消息名称
        /// </summary>
        public string notificationName;
        /// <summary>
        /// 消息数据
        /// </summary>
        public string data;

        protected void Awake()
        {
            Button btn = GetComponent<Button>();
            btn.onClick.AddListener( Send );
            Image img = GetComponent<Image>();
            img.alphaHitTestMinimumThreshold = 0.1f;
        }
        /// <summary>
        ///  点击时发送消息
        /// </summary>
        private void Send()
        {
            SendNotification( notificationName , data );
        }
    }
}

