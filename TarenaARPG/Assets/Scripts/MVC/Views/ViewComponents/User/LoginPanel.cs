using System;
using System.Collections;
using System.Collections.Generic;
using TarenaMVC.Core;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.MVC.Views
{
    /// <summary>
    ///  登录面板
    /// </summary>
    public class LoginPanel : BasePanel
    {
        private InputField userInput;
        private InputField pwdInput;
        private Button loginButton;
        private Button registerButton;

        override protected void Awake()
        {
            userInput = Find<InputField>( "userInput" );
            pwdInput = Find<InputField>( "pwdInput" );
            loginButton = Find<Button>( "loginButton" );
            registerButton = Find<Button>( "registerButton" );

            loginButton.onClick.AddListener( Login );
            registerButton.onClick.AddListener( ShowRegister );
            // 读取保存的用户名和密码
            if( PlayerPrefs.HasKey( "username" ) )
            {
                userInput.text = PlayerPrefs.GetString( "username" );
                pwdInput.text = PlayerPrefs.GetString( "password" );
            }
        }
        /// <summary>
        /// 显示注册面板
        /// </summary>
        private void ShowRegister()
        {
            SendNotification( SHOW + NotificationList.REGISTER );
        }

        /// <summary>
        /// 登录
        /// </summary>
        private void Login()
        {
            // 判断用户名和密码均不为空
            if( userInput.text == "" || pwdInput.text == "" )
            {
                Alert.Show("出错了", "用户名和密码均不能为空" );
                Debug.LogError( "判断用户名和密码均不能为空" );
                return;
            }
            // 判断用户名和密码没有非法字符
            if( !StringHelper.IsSafeSqlString(userInput.text) ||
                StringHelper.CheckBadWord( userInput.text) || 
                !StringHelper.IsSafeSqlString( pwdInput.text ) ||
                StringHelper.CheckBadWord( pwdInput.text ) )
            {
                Alert.Show( "出错了" , "不允许非法字符!" );
                Debug.LogError( "不允许非法字符!" );
                return;
            }
            // 发送Login消息
            UserVO user = new UserVO( userInput.text, pwdInput.text);
            SendNotification( NotificationList.LOGIN , user );
        }
    }
}