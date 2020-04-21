using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {

public static float TimeLeft = 0f;


	void Update(){

		TimeLeft -= Time.deltaTime;
	}

	void OnGUI () {
		
		GUI.TextArea (new Rect (10, 10, 150, 50), "TextBox");
	

	}


}
