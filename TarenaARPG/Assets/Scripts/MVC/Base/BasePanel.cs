using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.MVC
{
    /// <summary>
    ///  面板的显示和隐藏
    /// </summary>
    public class BasePanel : BaseMonoBehaviour
    {
        protected Button closeButton;
        protected virtual void Awake()
        {
            closeButton = Find<Button>( "closeButton" );
            if( closeButton != null )
                closeButton.onClick.AddListener( Hide );
        }
        /// <summary>
        /// 显示
        /// </summary>
        public virtual void Show()
        {
            gameObject.SetActive( true );
        }
        /// <summary>
        ///  隐藏
        /// </summary>
        public virtual void Hide()
        {
            gameObject.SetActive( false );
        }
    }
}

