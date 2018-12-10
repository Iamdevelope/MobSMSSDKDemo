using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.MVC
{
    /// <summary>
    /// 用户英雄状态栏
    /// </summary>
    public class HeroStatusBar : BaseMonoBehaviour
    {
        private Text nameText;
        private Text lvText;
        private Text moneyText;
        private Text expText;
        private void Awake()
        {
            nameText = Find<Text>( "nameText" );
            lvText = Find<Text>( "lvText" );
            moneyText = Find<Text>( "moneyText" );
            expText = Find<Text>( "expText" );
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        public void UpdateData()
        {
            UserHeroVO userHero = GameController.instance.crtHero;
            if( userHero == null ) return;
            nameText.text = userHero.name;
            lvText.text = "等级: " + userHero.lv;
            moneyText.text = "金币: " + userHero.money;
            expText.text = "经验值: " + userHero.exp;
        }

    }
}