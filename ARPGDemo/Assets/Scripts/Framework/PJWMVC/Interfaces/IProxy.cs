using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PJWMVC.Interfaces
{


    /// <summary>
    ///  处理数据的接口
    /// </summary>
    public interface IProxy:INotifier
    {
        /// <summary>
        /// proxy的名称
        /// </summary>
        string proxyName { get; set; }
    }
}
