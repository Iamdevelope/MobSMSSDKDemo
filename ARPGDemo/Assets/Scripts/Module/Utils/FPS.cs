using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TRPG.Module
{
    public class FPS : MonoBehaviour
    {
        public float fpsMeasuringDelta = 0.1f;

        private float timePassed;
        private int m_FrameCount = 0;
        private float m_FPS = 0.0f;

        private void Start( )
        {
            timePassed = 0.0f;
        }

        private void Update( )
        {
            m_FrameCount = m_FrameCount + 1;
            timePassed = timePassed + Time.deltaTime;

            if ( timePassed > fpsMeasuringDelta )
            {
                m_FPS = m_FrameCount / timePassed;

                timePassed = 0.0f;
                m_FrameCount = 0;
            }
        }

        private void OnGUI( )
        {
            GUIStyle bb = new GUIStyle( );
            bb.normal.background = null;    //这是设置背景填充的
            bb.normal.textColor = new Color( 1.0f, 1f, 1.0f,0.8f );   //设置字体颜色的
            bb.fontSize = 10;       //当然，这是字体大小
            // 右上角显示
            GUI.Label( new Rect(  Screen.width-60 , 0, 200, 200 ), "FPS: " + Mathf.Floor( m_FPS ), bb );
            //居中显示FPS
            //GUI.Label( new Rect( ( Screen.width / 2 ) - 40, 0, 200, 200 ), "FPS: " + Mathf.Floor( m_FPS ), bb );
        }
    }
}
