using System.Collections;
using System.Collections.Generic;
using PJWMVC.Patterns;
using UnityEngine;
using System;
 
namespace TRPG.MVC.Models
{
    /// <summary>
    ///  处理用户相关数据: 登录和注册
    /// </summary>
    public class UserProxy : BaseProxy
    {
        public new const string NAME = "UserProxy";


        // 成功状态
        public const string SUCCESS = "Success"; // 成功
        public const string FAILURE = "Failure"; // 失败

        public UserProxy()
        {
            this.proxyName = NAME;
            OpenDB();
        }
        // 用户登录
        public void Login( UserVO user ) {
            // 打开数据库
            OpenDB();
            // 查询用户
            reader = db.SelectWhere( "User" ,
                new string[] { "uid" } ,
                new string[] { "username" , "password" } ,
                new string[] { "=" , "=" } ,
                new string[] { user.username , user.password } );
            // 有结果 发送 登录成功消息
            if(  reader.HasRows )
            {
                // 记住密码
                PlayerPrefs.SetString( "username" , user.username );
                PlayerPrefs.SetString( "password" , user.password );
                // uid
                reader.Read();
                user.uid = reader.GetString( reader.GetOrdinal( "uid" ) );
                // 当前用户
                GameController.instance.crtUser = user;
                SendNotification( NotificationList.LOGIN + SUCCESS );
            }else
                SendNotification( NotificationList.LOGIN + FAILURE );
            // 没有 发送 登录失败的消息
            // 关闭数据库
            CloseDB();

        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        public void Register( UserVO user ) {
            // 打开数据库
            OpenDB();
            // 查找是否有重名
            reader = db.Select( "User" , "username" , 
                GetStr( user.username ) );
            // 如果有,发送 注册失败 消息
            if( reader.HasRows )
            {
                SendNotification( NotificationList.REGISTER + FAILURE , "用户已存在!" );
                CloseDB();return;
            }
            // 插入数据库
            db.InsertInto( "User" ,
                new string[]
                {
                    GetStr( user.uid),
                    GetStr( user.username),
                    GetStr( user.password),
                    GetStr( DateTime.Now )
                } );
            // 发送注册成功消息
            SendNotification( NotificationList.REGISTER + SUCCESS );
            // 关闭数据库
            CloseDB();
           // DateTime.Now
        }

    }
}

