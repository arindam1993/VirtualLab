using UnityEngine;
using System.Collections;
using System;

public class RayBehaviour : MonoBehaviour {

	// Use this for initialization
	private bool isHit;
	private bool isHitC;
	private Collider rayPt;
	public Transform rayStart;
	public Transform ray;
	public Transform lensPoint;
	public Transform lensPointC;
	public Transform rayEnd;
	public Transform lensStart;
	public Transform lensStartc;
		//public static Transform lensStart_sta;
	//public static Transform lensStartc_sta;
	//public static Transform ray_sta;
	public static float length;
	public static float lengthc;
	void OnTriggerEnter(Collider rayPoint)
	{
		if(rayPoint.gameObject.tag=="convex")
		{
			isHit=true;
			Debug.Log("ConvexHit");
		}
		if(rayPoint.gameObject.tag=="concave")
		{
			isHitC=true;
			Debug.Log("ConcaveHit");
		}


	}
	void OnTriggerExit(Collider rayPoint)
	{
		if(rayPoint.gameObject.tag=="convex")
		{
			isHit=false;
		}
		if(rayPoint.gameObject.tag=="concave")
		{
			isHitC=false;
		}

		rayRescale();
		
	}
	public void rayRescale()
	{
		ray.transform.localScale=new Vector3((float)0.1,(float)0.1,(float)0.1);
		lensStart.FindChild("ray_top_lens").renderer.enabled=false;
		lensStartc.FindChild("ray_top_lens").renderer.enabled=false;
	}

	void Start()
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		isHit = false;
		isHitC = false;

	}

	
	// Update is called once per frame
	void Update () {

			if(isHit)
			{
				Ray ray1=new Ray(ray.position,ray.forward);
				
				length=Vector3.Distance(rayStart.transform.position,lensPoint.transform.position);
				//Debug.Log(length);
				float scale=length/20;
				ray.transform.localScale=new Vector3((float)0.1,(float)0.1,(float)scale*(float)0.1);
				lensStart.position=rayEnd.position;
				lensStart.FindChild("ray_top_lens").renderer.enabled=true;


			}
			if(!isHit && !isHitC)
			{
				

			}


			if(isHitC)
			{
				lengthc=Vector3.Distance(rayStart.transform.position,lensPointC.transform.position);
				//Debug.Log(lengthc);
				float scalec=lengthc/20;
				ray.transform.localScale=new Vector3((float)0.1,(float)0.1,(float)scalec*(float)0.1);
				lensStartc.position=rayEnd.position;
				lensStartc.FindChild("ray_top_lens").renderer.enabled=true;
				
				
			}
		if (ConvexTracker.convexTracked == false && ConcaveTracker.concaveTracked==false) {
			rayRescale();
				}

		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKey (KeyCode.Escape)) 
			{
				Application.LoadLevel(0);
				return;
			}
		}


	
	}
}
