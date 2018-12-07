using System.Collections;
using System.Collections.Generic;
using TRPG.Module;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.MVC {
    public class SkillItem : BaseMonoBehaviour {
        private Text nameText;
        private Text damageText;
        private Image avatar;
        private void Awake()
        {
            nameText = Find<Text>("nameText");
            damageText = Find<Text>("damageText");
            avatar = Find<Image>("avatar");   
        }

        private SkillInfo _data;
        public SkillInfo data
        {
            get { return _data; }
            set { _data = value;
                nameText.text = _data.name;
                damageText.text = "伤害值："+_data.damage.ToString();
                avatar.sprite = _data.icon;
            }
        }
    }
}