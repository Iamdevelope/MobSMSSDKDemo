using System.Collections;
using System.Collections.Generic;
using TarenaMVC.Core;
using UnityEngine;
 
namespace TRPG.MVC
{
    /// <summary>
    /// 发送消息
    /// </summary>
    public class BaseMonoBehaviour : MonoBehaviour
    {
        // 动作(显示和隐藏)
        public const string SHOW = "Show";
        public const string HIDE = "Hide";
        /// <summary>
        ///  发送消息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void SendNotification( string name , object data = null )
        {
            Facade.I().SendNotification( name , data );
        }

        /// <summary>
        /// 找到指定类型和名称的子对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="s">名称</param>
        /// <returns></returns>
        protected T Find<T>( string s )
        {
            if( transform.Find( s ) == null )
            {
                Debug.LogError( this + " 子对象 " + s + "未找到!" );
                return default( T );
            }
            return transform.Find( s ).GetComponent<T>();
        }

    }
}

