using System;
using System.Collections;
using System.Collections.Generic;
using TRPG.Module;
using TRPG.MVC;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  游戏主循环逻辑
/// </summary>
public class Game : BaseMonoBehaviour 
{
    public Health[] monsters; // 所有怪兽
    public Text taskText; // 任务文本
    private void Start()
    {
        StartCoroutine( GameLoop() );
    }
    /// <summary>
    /// 游戏主循环
    /// </summary>
    /// <returns></returns>
    IEnumerator GameLoop()
    {
        // 判断怪兽有没有都挂断
        while( !AllMonstersDead() )
            yield return null; // 一直循环
        // 副本任务完成
        // 获得奖励 500 金币
        SendNotification( NotificationList.ADD_MONEY , 500 );
        // 获得奖励 500 经验值
        SendNotification( NotificationList.ADD_EXP , 500 );
        // Alert.Show
        Alert.Show( "副本任务完成" , "恭喜获得500金币和500经验值!" ,
            ExitGame , "11" , false );
    }
    /// <summary>
    ///  退出副本
    /// </summary>
    /// <param name="arg0"></param>
    private void ExitGame( object arg0 )
    {
        SendNotification( NotificationList.UNLOAD_LEVEL , arg0 );
    }

    // 判断怪兽是否都已经挂断
    private bool AllMonstersDead()
    {
        int amount = monsters.Length; // 总数
        int n = 0; // n 挂掉的monster个数
        // 遍历Monsters数组
        foreach( Health health in monsters )
        {
            if( health == null || health.dead )
                n += 1;
        }
        taskText.text = "当前任务: 击杀小怪( " + n + " / " + amount + " )";
        return n == amount;
    }
}
