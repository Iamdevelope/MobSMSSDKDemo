using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.Module
{
    /// <summary>
    ///  玩家攻击
    /// </summary>
    public class PlayerAttack : MonoBehaviour
    {
        private SkillManager sm;
        public SkillInfo[] skill;
        public SkillInfo normal;
        private SkillInfo s1;
        private SkillInfo s2;
        private Text cdText1;
        private Text cdText2;
        private Image skill1;
        private Image skill2;
        private string skill1Sprite;
        private string skill2Sprite;
        private void Awake()
        {
            sm = GetComponent<SkillManager>();
            // 找到ETCButton
            ETCButton[] btns = GameObject.FindObjectsOfType<ETCButton>();
            // 监听OnDown事件
            foreach( ETCButton btn in btns )
            {
                btn.onDown.AddListener( OnDown );
                if( btn.name == "skill1") {
                    cdText1 = btn.GetComponentInChildren<Text>();
                    skill1 = btn.transform.Find("icon").GetComponent<Image>();
                }
                if( btn.name == "skill2") {
                    cdText2 = btn.GetComponentInChildren<Text>();
                    skill2 = btn.transform.Find("icon").GetComponent<Image>();
                }
            }
            //从持久化数据中拿到场景中保存的技能信息
            if (PlayerPrefs.HasKey("skill1") && PlayerPrefs.HasKey("skill2")) {
                skill1Sprite = PlayerPrefs.GetString("skill1");
                skill2Sprite = PlayerPrefs.GetString("skill2");
            }
            //将持久化中的数据拿到，并设置到对应按钮上
            for (int i = 0; i < skill.Length; i++) {
                if (skill[i].name == skill1Sprite) {
                    s1 = skill[i];
                    skill1.sprite = skill[i].icon;
                }
                if (skill[i].name == skill2Sprite) {
                    s2 = skill[i];
                    skill2.sprite = skill[i].icon;
                }
            }
            // 重置冷却状态
            if (s1 != null) s1.coding = false;
            if (s2 != null) s2.coding = false;
        }
        /// <summary>
        /// 技能按钮OnDown事件处理
        /// </summary>
        /// <param name="s"></param>
        private void OnDown( string s )
        {
            Debug.Log( "OnDown: " + s );
            switch( s )
            {
                case "normal":
                    sm.Fire( normal );// 释放普攻技能
                    break;
                case "skill1":
                    if (s1 != null) sm.Fire(s1, Skill1CD);
                    break;
                case "skill2":
                    if (s2 != null) sm.Fire(s2, Skill2CD);
                    break;
            }
        }
        /// <summary>
        /// 技能1冷却
        /// </summary>
        /// <param name="cd"></param>
        private void Skill1CD( int cd )
        {
            print( "Skill1CD: " + cd );
            cdText1.text = cd > 0 ? cd + "" : "" ;
        }
        /// <summary>
        /// 技能2冷却
        /// </summary>
        /// <param name="cd"></param>
        private void Skill2CD( int cd )
        {
            print( "Skill2CD: " + cd );
            cdText2.text = cd > 0 ? cd + "" : "";
        }
    }
}

