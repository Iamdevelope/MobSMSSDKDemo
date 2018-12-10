var mySkin : GUISkin;
var effect01 : GameObject;
var effect02 : GameObject;
var effect03 : GameObject;
var effect04 : GameObject;
var effect05 : GameObject;
var effect06 : GameObject;
var effect07 : GameObject;
var effect08 : GameObject;
var effect09 : GameObject;
var effect10 : GameObject;
var effect11 : GameObject;
var effect12 : GameObject;
var effect13 : GameObject;
var effect14 : GameObject;
var effect15 : GameObject;
var effect16 : GameObject;
var effect17 : GameObject;
var effect18 : GameObject;
var effect19 : GameObject;
var effect20 : GameObject;
var effect21 : GameObject;
var effect22 : GameObject;
var effect23 : GameObject;
var effect24 : GameObject;
var effect25 : GameObject;
var effect26 : GameObject;
var effect27 : GameObject;
var effect28 : GameObject;
var effect29 : GameObject;
var effect30 : GameObject;
var effect31 : GameObject;
var effect32 : GameObject;
var effect33 : GameObject;
var effect34 : GameObject;
var effect35 : GameObject;
var effect36 : GameObject;
var effect37 : GameObject;
var effect38 : GameObject;
var effect39 : GameObject;
var effect40 : GameObject;
var effect41 : GameObject;


function OnGUI ()
{
	GUI.skin = mySkin;
	
	GUI.Label (Rect (70,10,100,20), "test");

	if(GUI.Button (Rect (10,40,20,20), GUIContent ("", "ArrowFX_Fire")))
	{	Instantiate(effect01, new Vector3(0, 1.5, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (40,40,20,20), GUIContent ("", "ArrowFX_FireRain")))
	{	Instantiate(effect02, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (70,40,20,20), GUIContent ("", "ArrowFX_Ground")))
	{	Instantiate(effect03, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (100,40,20,20), GUIContent ("", "ArrowFX_Ice")))
	{	Instantiate(effect04, new Vector3(0, 1.5, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (130,40,20,20), GUIContent ("", "ArrowFX_IceRain")))
	{	Instantiate(effect05, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (160,40,20,20), GUIContent ("", "ArrowFX_Lightning")))
	{	Instantiate(effect06, new Vector3(0, 1.5, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (190,40,20,20), GUIContent ("", "ArrowFX_LightningRain")))
	{	Instantiate(effect07, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	
	if(GUI.Button (Rect (10,70,20,20), GUIContent ("", "ArrowFX_Rain")))
	{	Instantiate(effect08, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (40,70,20,20), GUIContent ("", "ArrowFX_SkullRain")))
	{	Instantiate(effect09, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (70,70,20,20), GUIContent ("", "BarrierFX")))
	{	Instantiate(effect10, new Vector3(0, 1.5, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (100,70,20,20), GUIContent ("", "ChargeFX_Normal")))
	{	Instantiate(effect11, new Vector3(0, 1.5, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (130,70,20,20), GUIContent ("", "ChargeFX_Wind01")))
	{	Instantiate(effect12, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (160,70,20,20), GUIContent ("", "ChargeFX_Wind02")))
	{	Instantiate(effect13, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (190,70,20,20), GUIContent ("", "CircleFX_Dark")))
	{	Instantiate(effect14, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}

	if(GUI.Button (Rect (10,100,20,20), GUIContent ("", "CircleFX_Fire")))
	{	Instantiate(effect15, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (40,100,20,20), GUIContent ("", "CircleFX_Ice")))
	{	Instantiate(effect16, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (70,100,20,20), GUIContent ("", "CircleFX_Lightning")))
	{	Instantiate(effect17, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (100,100,20,20), GUIContent ("", "CircleFX_Line")))
	{	Instantiate(effect18, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (130,100,20,20), GUIContent ("", "CloudFlashFX")))
	{	Instantiate(effect19, new Vector3(0, 1.5, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (160,100,20,20), GUIContent ("", "ExplosionFX")))
	{	Instantiate(effect20, new Vector3(0, 1.5, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (190,100,20,20), GUIContent ("", "GroundFX_Dark01")))
	{	Instantiate(effect21, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}

	if(GUI.Button (Rect (10,130,20,20), GUIContent ("", "GroundFX_Dark02")))
	{	Instantiate(effect22, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (40,130,20,20), GUIContent ("", "GroundFX_Dark03")))
	{	Instantiate(effect23, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (70,130,20,20), GUIContent ("", "GroundFX_Fire01")))
	{	Instantiate(effect24, new Vector3(0, 0.3, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (100,130,20,20), GUIContent ("", "GroundFX_Fire02")))
	{	Instantiate(effect25, new Vector3(0, 0.3, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (130,130,20,20), GUIContent ("", "GroundFX_Ice01")))
	{	Instantiate(effect26, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (160,130,20,20), GUIContent ("", "GroundFX_Ice02")))
	{	Instantiate(effect27, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (190,130,20,20), GUIContent ("", "GroundFX_Ice03")))
	{	Instantiate(effect28, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	
	if(GUI.Button (Rect (10,160,20,20), GUIContent ("", "GroundFX_Lightning01")))
	{	Instantiate(effect29, new Vector3(0, 0.3, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (40,160,20,20), GUIContent ("", "GroundFX_Lightning02")))
	{	Instantiate(effect30, new Vector3(0, 0.3, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (70,160,20,20), GUIContent ("", "GroundFX_Lightning03")))
	{	Instantiate(effect31, new Vector3(0, 0.3, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (100,160,20,20), GUIContent ("", "GroundFX_Line01")))
	{	Instantiate(effect32, new Vector3(0, 1.5, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (130,160,20,20), GUIContent ("", "GroundFX_Line02")))
	{	Instantiate(effect33, new Vector3(0, 0.3, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (160,160,20,20), GUIContent ("", "GroundFX_Line03")))
	{	Instantiate(effect34, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (190,160,20,20), GUIContent ("", "HitFX_Dark")))
	{	Instantiate(effect35, new Vector3(0, 1.5, 0), Quaternion.Euler(0, 0, 0));	}
	
	if(GUI.Button (Rect (10,190,20,20), GUIContent ("", "HitFX_Fire")))
	{	Instantiate(effect36, new Vector3(0, 1.5, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (40,190,20,20), GUIContent ("", "HitFX_Ice")))
	{	Instantiate(effect37, new Vector3(0, 1.5, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (70,190,20,20), GUIContent ("", "HitFX_Lightning")))
	{	Instantiate(effect38, new Vector3(0, 1.5, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (100,190,20,20), GUIContent ("", "HitFX_Normal01")))
	{	Instantiate(effect39, new Vector3(0, 1.5, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (130,190,20,20), GUIContent ("", "LightDustFX")))
	{	Instantiate(effect40, new Vector3(0, 1.5, 0), Quaternion.Euler(0, 0, 0));	}
	if(GUI.Button (Rect (160,190,20,20), GUIContent ("", "LineSphereFX")))
	{	Instantiate(effect41, new Vector3(0, 1.5, 0), Quaternion.Euler(0, 0, 0));	}




	
	GUI.Label (Rect (10,Screen.height-30,200,30), GUI.tooltip);
}