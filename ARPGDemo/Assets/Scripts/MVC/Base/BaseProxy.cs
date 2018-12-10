using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Mono.Data.Sqlite;
using PJWMVC.Patterns;

namespace TRPG.MVC
{
    /// <summary>
    ///  封装数据库功能
    /// </summary>
    public class BaseProxy:Proxy
    {
        // 成功状态
        public const string SUCCESS = "Success"; // 成功
        public const string FAILURE = "Failure"; // 失败
        // 动作(显示和隐藏)
        public const string SHOW = "Show";
        public const string HIDE = "Hide";

        protected DbAccess db;// 数据库操作类
        private string dbName = "data.db"; // 数据库名称
        private string dbPath; // 数据库路径
        protected SqliteDataReader reader;
        /// <summary>
        /// 打开数据库
        /// </summary>
        protected void OpenDB()
        {
            if( Application.platform == RuntimePlatform.WindowsPlayer
                || Application.platform == RuntimePlatform.WindowsEditor )
                dbPath = Application.streamingAssetsPath + "/" + dbName;
            else if( Application.platform == RuntimePlatform.Android )
            {
                dbPath = Application.persistentDataPath + "/" + dbName;
                Debug.Log( File.Exists( dbPath ) + " " + dbPath );
                if( !File.Exists( dbPath ) ) // 如果数据库不存在,则复制到持久化目录下
                    GameController.instance.StartCoroutine( CopyDB() );
            }
            db = new DbAccess( "URI=file:" + dbPath );
        }
        /// <summary>
        /// 复制文件到持久化目录
        /// </summary>
        /// <returns></returns>
        private IEnumerator CopyDB()
        {
            // 从StreamingAssets目录使用WWW下载data.db
            WWW www = new WWW( Application.streamingAssetsPath + "/" + dbName ); 
            yield return www; // 等待下载完毕
            Debug.Log( "下载完毕" );
            //下载完毕后写到persistentDataPath路径
            File.WriteAllBytes( dbPath , www.bytes );
            Debug.Log( "写入完毕" );
            CloseDB();
        }
        /// <summary>
        /// 关闭数据库
        /// </summary>
        protected void CloseDB()
        {
            db.CloseSqlConnection();
            reader = null;
        }
        /// <summary>
        /// 在对象前后加上单引号
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected string GetStr( object o )
        {
            return "'" + o + "'";
        }
    }
}

