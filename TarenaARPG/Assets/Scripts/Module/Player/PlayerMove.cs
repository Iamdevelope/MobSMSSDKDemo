using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  玩家动画状态的切换
/// </summary>
public class PlayerMove : MonoBehaviour 
{
    private Animation animation;

    private void Awake()
    {
        animation = GetComponent<Animation>();
        // ETC Move
        ETCJoystick moveStick = GameObject.FindObjectOfType<ETCJoystick>();
        moveStick.onMoveStart.AddListener( OnMoveStart );
        moveStick.onMove.AddListener( OnMove );
        moveStick.onMoveEnd.AddListener( OnMoveEnd );
    }
    /// <summary>
    /// 开始移动
    /// </summary>
    private void OnMoveStart()
    {
        animation.CrossFade( "run" );
    }
    /// <summary>
    /// 一直处于移动状态
    /// </summary>
    /// <param name="arg0"></param>
    private void OnMove( Vector2 arg0 )
    {
        animation.Play( "run" );
    }
    /// <summary>
    /// 停止移动
    /// </summary>
    private void OnMoveEnd()
    {
        animation.CrossFade( "idle" );
    }
}
