using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.MVC
{
    /// <summary>
    ///  注销按钮
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class Logout : BaseMonoBehaviour
    {
        private void Awake()
        {
            Button btn = GetComponent<Button>();
            btn.onClick.AddListener( TryLogout );
        }
        /// <summary>
        ///  弹出确认框
        /// </summary>
        private void TryLogout()
        {
            Alert.Show( "确认注销" , "您确定要注销吗?" , HandleLogout );
        }
        /// <summary>
        /// 发送注销消息
        /// </summary>
        /// <param name="arg0"></param>
        private void HandleLogout( object arg0 )
        {
            SendNotification( NotificationList.LOGOUT );
        }
    }
}

