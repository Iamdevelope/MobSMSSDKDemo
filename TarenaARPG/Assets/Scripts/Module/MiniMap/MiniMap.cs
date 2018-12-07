using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
///  小地图
/// </summary>
public class MiniMap : MonoBehaviour 
{
    private Transform player; // 玩家对象
    private RectTransform mark; // 玩家标识
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag( "Player" ).transform;
        mark = transform.Find( "mark" ).GetComponent<RectTransform>();
    }
    private Vector2 tmp; // mark的位置
    private Quaternion rotation;// mark旋转角度
    private void Update()
    {
        // 位置
        tmp.x = player.position.x * 2;
        tmp.y = player.position.z * 2;
        mark.anchoredPosition = tmp;
        // 旋转
        rotation = Quaternion.Euler( 0 , 0 ,
            -player.rotation.eulerAngles.y );
        mark.rotation = rotation;

    }
}
