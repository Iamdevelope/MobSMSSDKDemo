using UnityEngine;
using System.Collections;

namespace TRPG.Module
{
    /// <summary>
    /// 鼠标旋转功能
    /// </summary>
    public class MouseRotate : MonoBehaviour
    {
        /// <summary>
        /// 起始位置
        /// </summary>
        private Vector3 startPostion;
        /// <summary>
        /// 鼠标按下的之前位置
        /// </summary>
        private Vector3 previousPosition;
        /// <summary>
        /// 鼠标按下之后的滑动距离
        /// </summary>
        private Vector3 offset;
        /// <summary>
        /// 鼠标抬起后距离初始位置的位置
        /// </summary>
        private Vector3 finalOffset;

        private bool isSlide;
        private float angle;

        void Update( )
        {
            if ( Input.GetMouseButtonDown( 0 ) )    // Input.GetMouseButtonDown(0) 当0键被按下一次
            {
                startPostion = Input.mousePosition;
                previousPosition = Input.mousePosition;
            }
            if ( Input.GetMouseButton( 0 ) )       // Input.GetMouseButton(0) 当0键被按住持续侦测(包含down和up各一次)
            {
                offset = Input.mousePosition - previousPosition;
                previousPosition = Input.mousePosition;
                //transform.Rotate(Vector3.Cross(offset, Vector3.forward).normalized, offset.magnitude, Space.World);
                transform.Rotate( Vector3.up, -offset.x, Space.World );
            }
            if ( Input.GetMouseButtonUp( 0 ) )  //Input.GetMouseButtonUp(0) 当0键放开一次
            {
                finalOffset = Input.mousePosition - startPostion;
                isSlide = true;
                angle = finalOffset.magnitude;
            }
            if ( isSlide )
            {
                //transform.Rotate(Vector3.Cross(finalOffset, Vector3.forward).normalized, angle * 2 * Time.deltaTime, Space.World);
                //transform.Rotate(Vector3.up, angle * 2 * Time.deltaTime, Space.World);
                if ( angle > 0 )angle -= 5;
                else angle = 0;
            }
        }
    }
}
