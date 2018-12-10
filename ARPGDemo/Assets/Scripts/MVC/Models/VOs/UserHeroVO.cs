using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
///  用户英雄数据结构
/// </summary>
public class UserHeroVO
{
    public string userID; //UserID STRING,
    public string heroID; //    //HeroID    STRING,
    public string name; //                      //Name STRING,
    public string type; //                      //Type      STRING,
    public int lv; //Lv INT,
    public int exp; //Exp       INT,
    public int money; //Money INT,
    public int force; //Force     INT,
    public int intellect; //Intellect INT,
    public int speed; //Speed     INT,
    public int maxHP; //MaxHP INT,
    public int maxMP; //MaxMP     INT,
    public int maxDamage; //DamageMax INT


    public string[] GetString()
    {
        return new string[]
        {
            GetStr( this.userID ),
            GetStr( this.heroID ),
            GetStr( this.name ),
            GetStr( this.type ),
            GetStr( this.lv ),
             GetStr( this.exp ),
            GetStr( this.money ),
            GetStr( this.force ),
            GetStr( this.intellect ),
            GetStr( this.speed ),
             GetStr( this.maxHP ),
            GetStr( this.maxMP ),
            GetStr( this.maxDamage )
        };
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
    public override string ToString()
    {
        return "名称: " + name + "\n等级: " + lv;
    }
}
