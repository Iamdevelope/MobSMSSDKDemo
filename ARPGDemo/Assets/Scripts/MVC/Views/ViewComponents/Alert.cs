using System;
using System.Collections;
using System.Collections.Generic;
using TRPG.MVC;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TRPG.MVC
{
    /// <summary>
    ///  全局弹出框
    /// </summary>
    public class Alert : BasePanel
    {
        /// <summary>
        /// 标题文本
        /// </summary>
        private Text titleText;
        /// <summary>
        /// 内容文本
        /// </summary>
        private Text lblText;
        /// <summary>
        /// 缺点按钮
        /// </summary>
        private Button okButton;
        /// <summary>
        /// 回调函数
        /// </summary>
        private UnityAction<object> callback;
        /// <summary>
        /// 数据
        /// </summary>
        private object data;
        /// <summary>
        /// 获取组件
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            titleText = Find<Text>( "titleText" );
            lblText = Find<Text>( "lblText" );
            okButton = Find<Button>( "okButton" );
            okButton.onClick.AddListener( TryCallback );
            instance = this;
            Hide();
        }
        /// <summary>
        /// 调用回调函数
        /// </summary>
        private void TryCallback()
        {
            // 如果有回调函数,则调用回调函数
            if( callback != null ) callback( data );// 
            Hide();
        }
        /// <summary>
        ///  显示弹出框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="label">内容</param>
        /// <param name="callback">回调函数</param>
        /// <param name="data">数据</param>
        /// <param name="showCloseButton">是否显示关闭按钮</param>
        public void ShowIt( string title , string label ,
            UnityAction<object> callback = null ,
            object data = null , bool showCloseButton = true )
        {
            titleText.text = title;
            lblText.text = label;
            this.callback = callback;
            this.data = data;
            closeButton.gameObject.SetActive( showCloseButton );
            Show();
        }
        /// <summary>
        /// Alert实例
        /// </summary>
        private static Alert instance;
        /// <summary>
        ///  显示弹出框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="label">内容</param>
        /// <param name="callback">回调函数</param>
        /// <param name="data">数据</param>
        /// <param name="showCloseButton">是否显示关闭按钮</param>
        public static void Show( string title , string label ,
            UnityAction<object> callback = null ,
            object data = null , bool showCloseButton = true )
        {
            instance.ShowIt( title , label , callback , data , showCloseButton );
        }
    }
}