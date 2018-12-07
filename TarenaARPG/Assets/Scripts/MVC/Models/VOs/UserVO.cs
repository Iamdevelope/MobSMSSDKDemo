using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
/// 
/// </summary>
public class UserVO
{
    public string uid;
    public string username;
    public string password;

    public UserVO(){  }
    /// <summary>
    ///  构造函数
    /// </summary>
    /// <param name="name"></param>
    /// <param name="pwd"></param>
    public UserVO(string name, string pwd)
    {
        this.username = name;
        this.password = pwd;
    }
}
