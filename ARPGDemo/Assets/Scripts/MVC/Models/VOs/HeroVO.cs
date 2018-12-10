using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace TRPG.MVC
{
    /// <summary>
    ///  系统英雄数据结构
    /// </summary>
    public class HeroVO
    {
        public string id; // id INTEGER PRIMARY KEY AUTOINCREMENT,
        public string uid; // uid STRING,
        public string type; // Warrior Wizard, 英雄类型
        public string name; // name STRING,
        public string weapon; // weapon      STRING,
        public string role; // role STRING,
        public string description; // description TEXT

        public override string ToString()
        {
            return "名称: " + name + "\n描述信息: " + description;
        }
    }
}

