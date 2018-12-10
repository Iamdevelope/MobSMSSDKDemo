using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
 
namespace TRPG.Module
{
    /// <summary>
    ///  创建SkillInfo的Asset文件
    /// </summary>
    public class SkillUtility
    {
        [MenuItem( "Tools/Skill/Create SkillInfo" )]
        static void Create()
        {
            // 在内存中生成SkillInfo的实例
            SkillInfo info = ScriptableObject.CreateInstance<SkillInfo>();
            // 将实例写到本地文件中
            AssetDatabase.CreateAsset( info , "Assets/Skills/skill.asset" );
            // 自动选中生成的文件
            Selection.activeObject = info;
        }
    }
}