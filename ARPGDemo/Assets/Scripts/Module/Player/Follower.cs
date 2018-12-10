using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
///  相机跟随玩家移动
/// </summary>
public class Follower : MonoBehaviour 
{
    /// <summary>
    /// 跟随的玩家
    /// </summary>
    private Transform player;
    /// <summary>
    /// 玩家和相机对象的距离
    /// </summary>
    private Vector3 distance;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag( "Player" ).transform;
        distance = player.position - transform.position;
    }
    /// <summary>
    /// 目标坐标
    /// </summary>
    private Vector3 tmp;
    /// <summary>
    /// 变化速度
    /// </summary>
    private Vector3 speed;
    private void Update()
    {
        tmp = player.position - distance;
        // 限制范围
        tmp.y = 0;
        //x -35 - 0   
        tmp.x = Mathf.Max(-35, tmp.x);
        tmp.x = Mathf.Min(0, tmp.x);
        //z 0 - 35
        tmp.z = Mathf.Max(0, tmp.z);
        tmp.z = Mathf.Min(35, tmp.z);
        // 缓动效果
        transform.position = Vector3.SmoothDamp(
            transform.position, // 当前位置
            tmp,    // 目标位置
            ref speed, // 移动速度
            0.2f); // 时间
    }
}
