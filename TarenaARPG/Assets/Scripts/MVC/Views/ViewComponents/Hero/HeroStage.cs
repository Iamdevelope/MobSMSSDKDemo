using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.MVC
{
    /// <summary>
    ///  英雄面板: 显示和切换系统英雄,创建新英雄
    /// </summary>
    public class HeroStage : BasePanel
    {
        public Dictionary<string , HeroVO> map;
        private SelectableButton wizardButton;
        private SelectableButton warriorButton;
        public GameObject wizardHero;
        public GameObject warriorHero;
        private Text infoText;
        private Button createButton;
        private InputField nameInput;
        private string heroType;
        protected override void Awake()
        {
            infoText = Find<Text>( "HeroInfo/infoText" );
            wizardButton = Find<SelectableButton>( "HeroList/wizardButton" );
            warriorButton = Find<SelectableButton>( "HeroList/warriorButton" );
            closeButton = Find<Button>( "NamePanel/closeButton" );
            createButton = Find<Button>( "NamePanel/createButton" );
            nameInput = Find<InputField>( "NamePanel/nameInput" );
            createButton.onClick.AddListener( CreateHero );
        }
        // 显示时获取系统英雄列表
        public  void Show( string s)
        {
            SendNotification( NotificationList.GET_HERO_LIST );
            closeButton.gameObject.SetActive( s == "true" );
        }
        /// <summary>
        /// 切换英雄
        /// </summary>
        /// <param name="type"></param>
        public void SwitchHero( string type )
        {
            heroType = type;
            Debug.Log( "SwitchHero " + type );
            switch( type )
            {
                case "Wizard":
                    wizardButton.selected = true;
                    warriorButton.selected = false;
                    warriorHero.SetActive( false );
                    wizardHero.SetActive( true );
                    break;
                case "Warrior":
                    wizardButton.selected = false;
                    warriorButton.selected = true;
                    warriorHero.SetActive( true );
                    wizardHero.SetActive( false );
                    break;
            }
            // 按钮选中状态
            // 3d英雄
            // 英雄信息
            HeroVO hero = map[type];
            infoText.text = hero.ToString();
            // 英雄类型
        }

        /// <summary>
        /// 创建新英雄
        /// </summary>
        private void CreateHero()
        {
            if( nameInput.text == "" )
            {
                Alert.Show( "出错了" , "名称不能为空" ); return;
            }
            if( StringHelper.CheckBadWord( nameInput.text ) ||
                !StringHelper.IsSafeSqlString( nameInput.text ) )
            {
                Alert.Show( "出错了" , "不允许非法字符" ); return;
            }
            UserHeroVO userHero = new UserHeroVO();
            userHero.userID = GameController.instance.crtUser.uid;
            userHero.heroID = Guid.NewGuid().ToString( "N" );
            userHero.name = nameInput.text;
            userHero.type = heroType;
            SendNotification( NotificationList.CREATE_HERO , userHero );

        }
    }
}