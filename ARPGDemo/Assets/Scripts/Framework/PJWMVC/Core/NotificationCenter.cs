using System.Collections;
using System.Collections.Generic;
using PJWMVC.Interfaces;
using PJWMVC.Patterns;
using UnityEngine;
 namespace PJWMVC.Core
{
    /// <summary>
    ///  消息中心:负责消息的注册,移除和发送
    /// </summary>
    public class NotificationCenter
    {

        private static NotificationCenter _instance;
        public static NotificationCenter instance
        {
            get
            {
                if( _instance == null ) _instance = new NotificationCenter();
                return _instance;
            }
        }

        public static NotificationCenter I()
        {
            return instance;
        }

        public NotificationCenter()
        {
            if( _instance != null )
                Debug.LogError( "请使用NotificationCenter.instance获取实例" );

            _instance = this;
            observerMap = new Dictionary<string , List<IObserver>>();
        }

        private Dictionary<string , List<IObserver>> observerMap;
        /// <summary>
        ///  添加观察者(注册消息)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="observer"></param>
        public void AddObserver( string name, IObserver observer )
        {
            // 如果List为空
            if( !observerMap.ContainsKey( name ) )
                // 新建List
                observerMap[name] = new List<IObserver>();
            // 添加到List
            observerMap[name].Add( observer );
        }
        /// <summary>
        /// 移除观察者
        /// </summary>
        /// <param name="name"></param>
        /// <param name="observer"></param>
        public void RemoveObserver( string name , IObserver observer )
        {
            // 判断list有无
            if( !observerMap.ContainsKey( name ) ) return;
            // list中有无observer
            if( !observerMap[name].Contains( observer ) ) return;
            // 从list里面移除observer
            observerMap[name].Remove( observer );
            // 如果list被清空,就移除这个list
            if( observerMap[name].Count == 0 )
                observerMap.Remove( name );
        }
        /// <summary>
        /// 消息的发送
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void  SendNotification( string name, object data = null )
        {
            // 找对应的list
            if( !observerMap.ContainsKey( name ) ) return;
            // list
            List<IObserver> list = observerMap[name];
            // 遍历
            foreach( IObserver observer in list )
                observer.HandleNotification( 
                    new Notification( name , data ) );
            // observer
            // 
        }
        /// <summary>
        /// 查看消息的监听对象
        /// </summary>
        public void View()
        {
            string s = "----------------------------Start View----------------------\n";
            // 找到所有消息
            foreach( string name in observerMap.Keys )
            {
                s += name + " :[ ";
                List<IObserver> list = observerMap[name];
                for( int i = 0 ; i < list.Count ; i++ )
                {
                    s += list[i]  ;
                    if( i != list.Count - 1 ) s += " , ";
                }
                s += " ]\n";
            }
            s +=  "----------------------------End View----------------------\n\n\n";
            Debug.Log( s );
        }
    }
}

