using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AndroidExitGame : MonoBehaviour {
	public Text msgText;
	float fadingSpeed = 1;
	bool fading;
	float startFadingTimep;
	Color originalColor;
	Color transparentColor;

	void Start () {
		originalColor = msgText.color;
		transparentColor = originalColor;
		transparentColor.a = 0;
		msgText.text = "再次按下返回键退出游戏";
		msgText.color = transparentColor;
	}   

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (startFadingTimep==0)
			{
				msgText.color = originalColor;
				startFadingTimep = Time.time;
				fading = true;
			}
			else
			{
				Application.Quit();
			}
		}
		if (fading)
		{
			msgText.color = Color.Lerp(originalColor, transparentColor, (Time.time - startFadingTimep) * fadingSpeed);
			if (msgText.color.a<2.0/255)
			{
				msgText.color = transparentColor;
				startFadingTimep = 0;
				fading = false;
			}
		}
	}
}