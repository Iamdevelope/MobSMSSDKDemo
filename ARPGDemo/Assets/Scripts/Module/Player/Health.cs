using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace TRPG.Module
{
    /// <summary>
    ///  血值控制
    /// </summary>
    public class Health : MonoBehaviour
    {
        public float maxHP = 100; // 最大血值
        [HideInInspector]
        public float hp;// 当前血值
        private Blackboard bb;
        private EnemyHP showHp;
        private void Awake()
        {
            hp = maxHP;
            bb = GetComponent<Blackboard>();
            showHp = GetComponentInChildren<EnemyHP>();
        }
        /// <summary>
        /// 承受伤害
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage( float damage )
        {
            hp -= damage;
            Debug.Log( hp );
            //将血量显示在血量条上
            showHp.SetEnemyHp(hp, maxHP);
            if( bb != null ) bb.SetValue( "hp" , hp );
        }

        private void Update()
        {
           // if( hp > 0 ) TakeDamage( 1f );
        }
        /// <summary>
        /// 是否已经挂断
        /// </summary>
        public bool dead
        {
            get { return hp <= 0; }
        }
    }
}

