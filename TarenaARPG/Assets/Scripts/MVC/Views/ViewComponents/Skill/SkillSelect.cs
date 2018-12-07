using System;
using System.Collections;
using System.Collections.Generic;
using TRPG.Module;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.MVC {
    /// <summary>
    /// 选择技能
    /// </summary>
    public class SkillSelect : BaseMonoBehaviour {
        private Button SkillButton1;
        private Button SkillButton2;
        private Dictionary<string, SkillInfo> skillBtn;
        private Button ExitBtn;

        private SkillInfo _data;
        public SkillInfo SkillData
        {
            set { _data = value; }
        }
        private void Start()
        {
            skillBtn = new Dictionary<string, SkillInfo>();
            SkillButton1 = Find<Button>("skill1");
            SkillButton2 = Find<Button>("skill2");
            ExitBtn = Find<Button>("closeButton");
            SkillButton1.onClick.AddListener(SelectSkill1);
            SkillButton2.onClick.AddListener(SelectSkill2);
            ExitBtn.onClick.AddListener(ExitOnclickEvent);
        }
        /// <summary>
        /// 设置好技能点击退出按钮时所引发的事件
        /// </summary>
        private void ExitOnclickEvent()
        {
            if (skillBtn.Count <= 0)
                Alert.Show("设置技能失败", "请设置好技能再开始游戏!");
            else {
                PlayerPrefs.SetString("skill1", skillBtn["skill1"].name);
                PlayerPrefs.SetString("skill2", skillBtn["skill2"].name);
                Debug.Log("主场景中的技能1:" + skillBtn["skill1"].name);
                Debug.Log("主场景中的技能2:" + skillBtn["skill2"].name);
            }
            //每次关闭设置技能面板时，将字典中的技能数据清空
            skillBtn.Clear();
        }

        private void SelectSkill2()
        {
            if (_data != null) {
                SkillButton2.transform.Find("Skill2Img").GetComponent<Image>().sprite = _data.icon;
                if (skillBtn.ContainsKey("skill2")) return;
                skillBtn["skill2"] = _data;
            }
        }

        private void SelectSkill1()
        {
            if (_data != null) {
                SkillButton1.transform.Find("Skill1Img").GetComponent<Image>().sprite = _data.icon;
                if (skillBtn.ContainsKey("skill1")) return;
                skillBtn["skill1"] = _data;
            }
        }
    }
}