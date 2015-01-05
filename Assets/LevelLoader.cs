using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
		if(Physics.Raycast(ray,out hit))
		{
			if(hit.transform.name=="titration")
			{
				Application.LoadLevel(1);
			}
			if(hit.transform.name=="lenses")
			{
				Application.LoadLevel(2);
			}
		}
		if (Application.platform == RuntimePlatform.Android)
		{
						if (Input.GetKey (KeyCode.Escape)) 
						{
								Application.Quit ();
								return;
						}
		}
	
	}
}
