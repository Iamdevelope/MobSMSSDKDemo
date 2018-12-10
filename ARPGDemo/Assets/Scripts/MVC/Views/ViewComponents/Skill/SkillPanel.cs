using System;
using System.Collections;
using System.Collections.Generic;
using TRPG.Module;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.MVC {
    
    /// <summary>
    /// 技能面板
    /// </summary>
    public class SkillPanel : BasePanel {
        private Text infoText;
        /// <summary>
        ///  SkillItem预设体
        /// </summary>
        public SkillItem skillItemPrefab;
        /// <summary>
        /// SkillItem的容器
        /// </summary>
        public Transform container;
        /// <summary>
        /// 技能信息列表
        /// </summary>
        public SkillInfo[] skills;
        private SkillSelect skillSelect;
        private void Start()
        {
            InitSkill();
        }
        /// <summary>
        /// 初始化技能
        /// </summary>
        private void InitSkill()
        {
            infoText = Find<Text>("infoText");
            skillSelect = GetComponent<SkillSelect>();
            for (int i = 0; i < skills.Length; i++) {
                SkillItem tempSkillItem = Instantiate(skillItemPrefab, container);
                tempSkillItem.data = skills[i] as SkillInfo;
                tempSkillItem.GetComponent<Button>().onClick.AddListener(
                    delegate { Select(tempSkillItem); });
                //默认选中第一个技能
                if (i == 0) 
                    Select(tempSkillItem);
            }
        }
        /// <summary>
        /// 当前选中的SkillItem
        /// </summary>
        private SelectableButton crtItem;
        /// <summary>
        /// SkillItem点击处理
        /// </summary>
        /// <param name="item"></param>
        private void Select(SkillItem item)
        {
            // 将现在选中Item的状态切换为不选中
            if (crtItem != null) {
                crtItem.selected = false;
                //将上一个技能信息清空
                skillSelect.SkillData = null;
            }
            // 保存item
            crtItem = item.GetComponent<SelectableButton>();
            // 将新的item状态切换为选中
            crtItem.selected = true;
            //将当前技能的信息保存到skillData中
            skillSelect.SkillData = item.data;
            // 显示当前英雄信息
            infoText.text = item.data.ToString();
        }
    }
}