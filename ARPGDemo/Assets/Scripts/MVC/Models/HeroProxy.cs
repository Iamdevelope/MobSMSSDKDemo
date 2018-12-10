using System.Collections;
using System.Collections.Generic;
using PJWMVC.Patterns;
using UnityEngine;
using System;
 
namespace TRPG.MVC.Models
{
    /// <summary>
    ///  处理角色(英雄)相关数据: 
    /// </summary>
    public class HeroProxy : BaseProxy
    {
        public new const string NAME = "HeroProxy";

        public HeroProxy()
        {
            this.proxyName = NAME;
        }

        /// <summary>
        /// 获取用户英雄列表
        /// </summary>
        public void GetUserHeroList()
        {
            // 打开数据库
            OpenDB();
            // 当前用户的uid
            string uid = GameController.instance.crtUser.uid;
            // 查询当前用户的英雄
            reader = db.Select( "User_Hero" , "UserID" , GetStr( uid ) );
            if( reader.HasRows ) // 有用户英雄
            {
                // ArrayList
                ArrayList list = new ArrayList();
               
                while( reader.Read() )
                {
                    // UserHeroVO
                    UserHeroVO userHero = new UserHeroVO();
                    userHero.userID = reader.GetString( reader.GetOrdinal( "UserID" ) );//UserID STRING,
                    userHero.heroID = reader.GetString( reader.GetOrdinal( "HeroID" ) ); //HeroID    STRING,
                    userHero.name = reader.GetString( reader.GetOrdinal( "Name" ) ); //Name STRING,
                    userHero.type = reader.GetString( reader.GetOrdinal( "Type" ) ); //Type      STRING,
                    userHero.lv = reader.GetInt32( reader.GetOrdinal( "Lv" ) ); //Lv INT,
                    userHero.exp = reader.GetInt32( reader.GetOrdinal( "Exp" ) ); //Exp       INT,
                    userHero.money = reader.GetInt32( reader.GetOrdinal( "Money" ) ); //Money INT,
                    userHero.force = reader.GetInt32( reader.GetOrdinal( "Force" ) ); //Force     INT,
                    userHero.intellect = reader.GetInt32( reader.GetOrdinal( "Intellect" ) ); //Intellect INT,
                    userHero.speed = reader.GetInt32( reader.GetOrdinal( "Speed" ) ); //Speed     INT,
                    userHero.maxHP = reader.GetInt32( reader.GetOrdinal( "MaxHP" ) ); //MaxHP INT,
                    userHero.maxMP = reader.GetInt32( reader.GetOrdinal( "MaxMP" ) ); //MaxMP     INT,
                    userHero.maxDamage = reader.GetInt32( reader.GetOrdinal( "DamageMax" ) ); //DamageMax INT
                    list.Add( userHero );
                }
                // 发送获取用户英雄列表成功  ArrayList
                SendNotification( NotificationList.GET_USER_HERO_LIST + SUCCESS , list );
            } // 如果没有
            else
            {
                // 强制创建英雄
                SendNotification( SHOW + NotificationList.HERO_STAGE , "false");
            }
            CloseDB();
            // 关闭数据库
        }
        /// <summary>
        /// 获取系统用户列表
        /// </summary>
        public void GetHeroList()
        {
            // 打开数据库
            OpenDB();
            // 读取整张表Hero
            reader = db.ReadFullTable( "Hero" );
            // Dic
            Dictionary<string , HeroVO> map = new Dictionary<string , HeroVO>();
            // 遍历数据
            while( reader.Read() )
            {
                HeroVO hero = new HeroVO();
                hero.id = reader.GetInt32( reader.GetOrdinal( "id" ) ) + "";
                hero.uid = reader.GetString( reader.GetOrdinal( "uid" ) ) ;
                hero.name = reader.GetString( reader.GetOrdinal( "name" ) );
                hero.type = reader.GetString( reader.GetOrdinal( "type" ) );
                hero.role = reader.GetString( reader.GetOrdinal( "role" ) );
                hero.weapon = reader.GetString( reader.GetOrdinal( "weapon" ) );
                hero.description = reader.GetString( reader.GetOrdinal( "description" ) );
                map.Add( hero.type , hero );
            }
            // 发送获取成功
            SendNotification( NotificationList.GET_HERO_LIST + SUCCESS , map );
            // 关闭数据库
            CloseDB();
        }
        /// <summary>
        /// 创建用户英雄
        /// </summary>
        /// <param name="user"></param>
        public void CreateHero( UserHeroVO user) {
            // 打开数据库
            OpenDB();
            // 查找是否重名
            reader = db.Select( "User_Hero" , "name" ,
                GetStr( user.name ) );
            if( reader.HasRows ) // 用户已存在
            {
                SendNotification( NotificationList.CREATE_HERO + FAILURE , "用户已存在!" );
                CloseDB();
            }
            // 插入数据库
            db.InsertInto( "User_Hero" , user.GetString() );
            // 发送创建成功
            SendNotification( NotificationList.CREATE_HERO + SUCCESS );
            // 关闭数据库
            CloseDB();
        }
        // 增加金币
        public void AddMoney( int v ) {
            // 当前英雄 crtHero
            // newMoney
            // 打开数据库
            // UpdateInto
            // UpdateHeroData
            // 关闭数据库

        }
        // 增加经验值
        public void AddExp( int v ) { }
    }
}

