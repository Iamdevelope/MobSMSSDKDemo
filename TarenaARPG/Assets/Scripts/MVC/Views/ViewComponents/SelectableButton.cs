using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TRPG.MVC;

namespace TRPG.MVC
{
    /// <summary>
    ///  有选中状态的组件
    /// </summary>
    public class SelectableButton : BaseMonoBehaviour
    {
        /// <summary>
        /// 选中效果图片
        /// </summary>
        private Image selectBorder;
        private void Awake()
        {
            selectBorder = Find<Image>( "selectBorder" );
        }
        /// <summary>
        /// 设置选中状态
        /// </summary>
        public bool selected
        {
            set { selectBorder.gameObject.SetActive( value ); }
        }
    }
}

