using System;
using System.Collections;
using System.Collections.Generic;
using TRPG.Module;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.MVC
{
    /// <summary>
    ///  显示面板的按钮
    /// </summary>
    [RequireComponent( typeof( Button ) )]
    public class PanelButton : MonoBehaviour
    {
        /// <summary>
        /// 要显示的面板
        /// </summary>
        public Panels panel;
        private void Awake()
        {
            Button btn = GetComponent<Button>();
            btn.onClick.AddListener( ShowPanel );
        }
        /// <summary>
        /// 显示面板
        /// </summary>
        private void ShowPanel()
        {
            UIManager.TogglePanel( panel , true );
        }
    }
}

