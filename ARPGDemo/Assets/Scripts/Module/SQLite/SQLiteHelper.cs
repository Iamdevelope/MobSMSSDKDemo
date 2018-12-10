using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  打开和关闭数据库
/// </summary>
public class SQLiteHelper : MonoBehaviour 
{
    protected DbAccess db;// 数据库操作类
    private string dbName = "test.db"; // 数据库名称
    private string dbPath // 数据库路径
    {
        get { if( Application.platform == RuntimePlatform.Android )
                return Application.persistentDataPath + "/" + dbName;
            return Application.streamingAssetsPath + "/" + dbName;
        }
    }
    /// <summary>
    /// 打开数据库
    /// </summary>
    protected void OpenDB()
    {
        // 根据不同平台,设置filePath不同路径
        // Android平台
        // data.db
        // 查看persistentDataPath有没有data.db
        // 如果没有,复制data.db StartCoroutine( CopyDB() );
       
//打开



        db = new DbAccess( "URI=file:" + dbPath );
    }

    private IEnumerator CopyDB()
    {
        WWW www = new WWW( "" );  // 从StreamingAssets目录使用WWW下载data.db
        yield return www;
      
      //下载完毕后写到persistentDataPath路径
    }
    /// <summary>
    /// 关闭数据库
    /// </summary>
    protected void CloseDB()
    {
        db.CloseSqlConnection();
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

