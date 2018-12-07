using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
namespace TarenaMVC.Interfaces
{
    /// <summary>
    ///  管理IMediator
    /// </summary>
    public interface IView
    {    
        /// <summary>
        /// 注册IMediator
        /// </summary>
        /// <param name="mediator"></param>
        void RegisterMediator( IMediator mediator );
        /// <summary>
        /// 移除IMediator
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns></returns>
        IMediator RemoveMediator( string mediatorName );
        /// <summary>
        /// 获取IMediator
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns></returns>
        IMediator RetrieveMediator( string mediatorName );
    }
}

