using UnityEngine;
using System.Collections;

public class ActiveTime : MonoBehaviour 
{
	public float activeTime = 0f;

	float timeStart = 0f;

	Transform Tr;

	void Awake ()
	{
		Tr = transform;

		int childs = Tr.childCount;
		for (int i = 0; i < childs; ++i)
		{
			Transform child = Tr.GetChild(i);
			child.gameObject.SetActive(false);
		}
	}

	void Start ()
	{		
		timeStart = Time.realtimeSinceStartup;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Time.realtimeSinceStartup > timeStart + activeTime) 
		{
			int childs = Tr.childCount;
			for (int i = 0; i < childs; ++i)
			{
				Transform child = Tr.GetChild(i);
				child.gameObject.SetActive(true);
			}

			this.enabled = false;
		}
	}
}
