using System.Collections;
using System.Collections.Generic;
using TarenaMVC.Patterns;
using TRPG.MVC.Models;
using UnityEngine;
 
namespace TRPG.MVC
{
    /// <summary>
    ///  所有Mediator的基类:封装Proxy的获取
    /// </summary>
    public class BaseMediator:Mediator
    {
        // 成功状态
        public const string SUCCESS = "Success"; // 成功
        public const string FAILURE = "Failure"; // 失败
                                                 // 动作(显示和隐藏)
        public const string SHOW = "Show";
        public const string HIDE = "Hide";

        public new const string NAME = "BaseMediator";

        public BaseMediator()
        {
            this.mediatorName = NAME;
        }

        protected ApplicationFacade facade
        {
            get { return ApplicationFacade.I(); }
        }

        private UserProxy _userProxy;
        protected UserProxy userProxy
        {
            get
            {
                if( _userProxy == null )
                    _userProxy = facade.RetrieveProxy( UserProxy.NAME ) as UserProxy;
                return _userProxy;
            }
        }

        private HeroProxy _heroProxy;
        protected HeroProxy heroProxy
        {
            get
            {
                if( _heroProxy == null )
                    _heroProxy = facade.RetrieveProxy( HeroProxy.NAME ) as HeroProxy;
                return _heroProxy;
            }
        }

    }
}

