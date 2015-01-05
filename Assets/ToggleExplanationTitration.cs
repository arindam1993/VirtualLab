using UnityEngine;
using System.Collections;

public class ToggleExplanationTitration : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (VBSteamControl.isExpComplete == true) {
			if(Input.GetTouch(0).phase==TouchPhase.Began)
			{
				gameObject.guiTexture.enabled=!(gameObject.guiTexture.enabled);
			}
			
		}
		
	}
}
