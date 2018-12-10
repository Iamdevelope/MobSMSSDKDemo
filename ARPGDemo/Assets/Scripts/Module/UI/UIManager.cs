using System;
using System.Collections;
using System.Collections.Generic;
using TRPG.MVC;
using UnityEngine;
namespace TRPG.Module
{
    /// <summary>
    ///  UI管理器
    /// </summary>
    public class UIManager
    {
        #region 单例
        /// <summary>
        /// 存储实例
        /// </summary>
        private static UIManager _instance;
        /// <summary>
        /// 获取实例
        /// </summary>
        public static UIManager instance
        {
            get
            {
                if( _instance == null ) _instance = new UIManager();
                return _instance;
            }
        }
        /// <summary>
        /// instance的简写,方便使用
        /// </summary>
        /// <returns></returns>
        public static UIManager I()
        {
            return instance;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public UIManager()
        {
            if( _instance != null )
                Debug.LogError( "请使用UIManager.instance获取实例" );

            _instance = this;
            mainCanvas = GameObject.FindGameObjectWithTag( "MainCanvas" ).transform;
            panels = new Dictionary<string , GameObject>();
            tagMap = new Dictionary<string , GameObject[]>();
            // 自动存储tag对象
            Array tags = Enum.GetValues( typeof( Tags ) );
            foreach( var tag in tags)
                tagMap[tag.ToString()] = GameObject.FindGameObjectsWithTag( tag.ToString() );
            // MainObjects UserObjects
            //tagMap[Tags.MainObjects.ToString()] = GameObject.FindGameObjectsWithTag( Tags.MainObjects.ToString() );
            //tagMap[Tags.UserObjects.ToString()] = GameObject.FindGameObjectsWithTag( Tags.UserObjects.ToString() );
        }
        #endregion
        /// <summary>
        /// 面板的父容器
        /// </summary>
        private Transform mainCanvas;
        /// <summary>
        /// 存储面板
        /// </summary>
        private Dictionary<string , GameObject> panels;
        /// <summary>
        /// 存储tag对象
        /// </summary>
        private Dictionary<string , GameObject[]> tagMap;
       /// <summary>
       /// 获取面板
       /// </summary>
       /// <typeparam name="T">面板类型</typeparam>
       /// <param name="name">面板名称,可以为空,如果为空则使用类型名称</param>
       /// <returns></returns>
        public static T GetPanel<T>(string name = null )
        {
            string key = name == null ? typeof( T ).Name : name;
            // panels里面如果没有
            if( !instance.panels.ContainsKey( key ) )
                // 找到panel,放到字典里面
                instance.panels[key] = instance.mainCanvas.Find( key ).gameObject;
            // 然后字典里面的对象
            return instance.panels[key].GetComponent<T>();
        }
        /// <summary>
        /// 显示或隐藏面板
        /// </summary>
        /// <param name="s">面板名称</param>
        /// <param name="active">显示或隐藏</param>
        public static void TogglePanel( string s, bool active )
        {
            BasePanel p = GetPanel<BasePanel>( s );
            if( active ) p.Show();
            else p.Hide();
        }
        /// <summary>
        /// 显示或隐藏面板
        /// </summary>
        /// <param name="p">面板</param>
        /// <param name="active"></param>
        public static void TogglePanel( Panels p, bool active )
        {
            TogglePanel( p.ToString() , active );
        }

        /// <summary>
        /// 显示或隐藏某些tag对象
        /// </summary>
        /// <param name="tag">tag名称</param>
        /// <param name="active">显示或隐藏</param>
        public static void ToggleObjects(string tag, bool active )
        {
            //
            foreach( GameObject go in instance.tagMap[tag] )
                go.SetActive( active );
        }
        /// <summary>
        /// 显示或隐藏某些tag对象
        /// </summary>
        /// <param name="tag">tag名称</param>
        /// <param name="active">显示或隐藏</param>
        public static void ToggleObjects( Tags tag , bool active )
        {
            ToggleObjects( tag.ToString() , active );
        }
    }
}