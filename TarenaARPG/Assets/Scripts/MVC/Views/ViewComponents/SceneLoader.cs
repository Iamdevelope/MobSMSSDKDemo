using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TRPG.MVC
{
    /// <summary>
    ///  场景加载器
    /// </summary>
    public class SceneLoader : BaseMonoBehaviour
    {
        private AsyncOperation async;
        public Slider proBar;
        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="scene"></param>
        public void LoadScene( string scene )
        {
            // 显示进度条
            proBar.gameObject.SetActive( true );
            // 开始异步加载
            StartCoroutine( LoadSceneAsync( scene ) );
        }
        /// <summary>
        /// 异步加载场景
        /// </summary>
        /// <param name="scene"></param>
        /// <returns></returns>
        IEnumerator LoadSceneAsync( string scene )
        {
            async = SceneManager.LoadSceneAsync( scene , LoadSceneMode.Additive );
            async.allowSceneActivation = false; // 开始时不激活,加载完毕激活
            yield return async;
        }

        private void Update()
        {
            if( async == null ) return;
            //Debug.Log( async.progress );
            // 0-1
            // 更新进度条进度
            proBar.value = async.progress;
            // 加载完毕
            if( async.progress >= 0.9f )
            {
                proBar.value = 1;
                // 隐藏进度条
                proBar.gameObject.SetActive( false );              
                // 激活场景
                async.allowSceneActivation = true;
                // 发送加载完毕消息
                SendNotification( NotificationList.LEVEL_LOADED );
                // async = null
                async = null;
            }

        }
        /// <summary>
        /// 卸载场景
        /// </summary>
        /// <param name="scene"></param>
        public void UnloadScene( string scene )
        {
            SceneManager.UnloadSceneAsync( scene );
        }
    }
}