using UnityEngine;
using System.Collections;

public  class SystemHelper : MonoBehaviour
{
    public static SystemHelper instance;
    public SystemHelper ( )
    {
        instance = this;
    }
    public  void DelayActive( GameObject go, bool enable , float delay)
    {
        StartCoroutine(  SetActive(go,enable, delay ) );
    }

    IEnumerator SetActive( GameObject go, bool enable , float delay )
    {
        yield return new WaitForSeconds(delay);
        if( go != null ) go.SetActive( enable );
    }
}
