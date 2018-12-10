using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TRPG.Module
{
    /// <summary>
    ///  技能释放器
    /// </summary>
    [RequireComponent(typeof(Animation))]
    public class SkillManager : MonoBehaviour
    {
        private Animation animation;
        private void Awake()
        {
            animation = GetComponent<Animation>();
        }
        /// <summary>
        /// 释放技能
        /// </summary>
        /// <param name="skill"></param>
        public void Fire( SkillInfo skill , UnityAction<int> callback =null)
        {
            // 技能释放处于冷却
            if( skill.coding == true ) return;
            // 开始冷却
            if( skill.cd > 0 )
                StartCoroutine( ColdDown( skill , skill.cd , callback) );
            // 播放技能释放动画
            if( skill.animation != null )
                animation.Play( skill.animation.name );
            // 启动计算伤害值协程
            StartCoroutine( DoAttack( skill ) );
            // 技能开始特效
            if( skill.startEffect != null )
            {
                GameObject startEffect = Instantiate( 
                    skill.startEffect , 
                    transform.position + skill.startEffectOffset , 
                    transform.rotation );
                Destroy( startEffect , 5 ); // 5秒之后自动销毁
            }
            // 打击特效
            if( skill.hitEffect != null )
                StartCoroutine( DelayCreate( skill ) );
        }
        /// <summary>
        /// 延迟创建
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        private IEnumerator DelayCreate( SkillInfo skill )
        {
            yield return new WaitForSeconds( skill.hitDelay );
            GameObject hitEffect = Instantiate(
                    skill.hitEffect ,
                    transform.position ,
                    transform.rotation );
            Destroy( hitEffect , 5 ); // 5秒之后自动销毁
        }
        /// <summary>
        /// 计算伤害值
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        private IEnumerator DoAttack( SkillInfo skill )
        {
            // 延迟时间
            yield return new WaitForSeconds( skill.damageDelay );
            // 找到所有攻击对象
            Collider[] colliders = Physics.OverlapSphere(
                transform.position , skill.range , skill.target );
            // 遍历对象
            foreach( Collider c in colliders )
            {
                // 计算距离
                float distance = Vector3.Distance( transform.position , c.transform.position );
                // 计算伤害值
                float damage = (1 - distance / skill.range) * skill.damage;
                // 伤害
                Health health = c.gameObject.GetComponent<Health>();
                health.TakeDamage( damage );
            }

        }
        /// <summary>
        /// 技能冷却
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="cd"></param>
        /// <returns></returns>
        private IEnumerator ColdDown( SkillInfo skill, int cd, UnityAction<int> callback )
        {
            // 调用回调函数
            if( callback !=null ) callback( cd );
            // 更新冷却状态
            skill.coding = cd > 0;
            // 等待一秒
            yield return new WaitForSeconds( 1 );
            // 冷却时间递减
            cd--;
            // 释放需要继续冷却
            if( cd >= 0 ) StartCoroutine( ColdDown( skill , cd ,callback ) );
        }
    }
}

