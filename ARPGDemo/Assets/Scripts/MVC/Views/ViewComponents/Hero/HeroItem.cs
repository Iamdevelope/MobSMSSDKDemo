using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.MVC
{
    /// <summary>
    /// 用户英雄Item
    /// </summary>
    public class HeroItem : BaseMonoBehaviour
    {
        private Text nameText;
        private Text lvText;
        private void Awake()
        {
            nameText = Find<Text>( "nameText" );
            lvText = Find<Text>( "lvText" );
        }

        private UserHeroVO _data;
        public UserHeroVO data
        {
            get { return _data; } 
            set {
                _data = value;
                nameText.text = _data.name;
                lvText.text = "等级: " + _data.lv;
            }
        }
    }
}

