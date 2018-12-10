using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.MVC
{
    /// <summary>
    ///  角色列表面板: 显示用户英雄列表
    /// </summary>
    public class HeroPanel : BasePanel
    {
        private Text infoText;
        /// <summary>
        ///  HeroItem预设体
        /// </summary>
        public HeroItem heroItemPrefab;
        /// <summary>
        /// Heroitem的容器
        /// </summary>
        public Transform container;

        private Button selectButton;

        protected override void Awake()
        {
            base.Awake();
            infoText = Find<Text>( "infoText" );
            selectButton = Find<Button>( "selectButton" );
            selectButton.onClick.AddListener( ChangeHero );
        }
        /// <summary>
        /// 切换英雄
        /// </summary>
        private void ChangeHero()
        {
            UserHeroVO crtHero = crtItem.GetComponent<HeroItem>().data;
            GameController.instance.crtHero = crtHero;
            SendNotification( NotificationList.UPDATE_HERO_DATA );
        }

        // 显示时获取用户英雄列表
        public override void Show()
        {
            base.Show();
            SendNotification( NotificationList.GET_USER_HERO_LIST );
        }
        // 获取用户英雄列表
        public void UpdateHeroList( ArrayList list )
        {
            Debug.Log( "UpdateHeroList: " + list.Count );
            // 有数据,默认选择第一个
            if( list.Count > 0 )
            {
                GameController.instance.crtHero = list[0] as UserHeroVO;
                SendNotification( NotificationList.UPDATE_HERO_DATA );
            }
            // 判断HeroPanel是否处于激活状态,如果不是则返回
            if( gameObject.activeSelf == false ) return;

            // 移除现有的HeroItem
            for( int i = container.childCount - 1 ; i >= 0 ; i-- )
            {
                Destroy( container.GetChild( i ).gameObject );
            }
            // 添加新的Item
            for( int i = 0 ; i < list.Count ; i++ )
            {
                HeroItem item = Instantiate( heroItemPrefab , container );
                item.data = list[i] as UserHeroVO;
                item.GetComponent<Button>().onClick.AddListener(
                    delegate { Select( item ); }
                    );
                if( i == 0 ) Select( item );
            }
        }
        /// <summary>
        /// 当前选中的HeroItem
        /// </summary>
        private SelectableButton crtItem;
        /// <summary>
        /// HeroItem点击处理
        /// </summary>
        /// <param name="item"></param>
        private void Select( HeroItem item )
        {
            // 将现在选中Item的状态切换为不选中
            if( crtItem != null )
                crtItem.selected = false;
            // 保存item
            crtItem = item.GetComponent<SelectableButton>();
            // 将新的item状态切换为选中
            crtItem.selected = true;
            // 显示当前英雄信息
            infoText.text = item.data.ToString();
        }
        // 如果设置选中状态
    }
}