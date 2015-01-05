using UnityEngine;
using System.Collections;

public class ToggleExplanation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ConvexTracker.isComplete == true) {
			if(Input.GetTouch(0).phase==TouchPhase.Began)
			{
				gameObject.guiTexture.enabled=!(gameObject.guiTexture.enabled);
			}
			
		}
	
	}
}
