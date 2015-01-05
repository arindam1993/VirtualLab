using UnityEngine;
using System.Collections;
using System;

public class VBSteamControl : MonoBehaviour,IVirtualButtonEventHandler {
	public ParticleSystem s;
	public float initialLiquid;
	public float drainRate;
	private float currentLiquid;
	public TextMesh qty;
	private bool pressed;
	public Transform waterLevel;
	private Vector3 scaleRate=new Vector3((float)0.0,(float)0.000025,(float)0.0);
	public Transform buttonMesh;
	public Material redColor;
	public GameObject flaskWater;
	public Transform buretteTip;
	public Transform flaskCenter;
	public GUITexture step1;
	public GUITexture step2;
	public GUITexture step3;
	public GUITexture step4;
	public GUITexture step5;
	public GUITexture expl;
	public static bool isExpComplete = false;
	private double dist;
	public GUIText inst;

	//public VirtualButton vb;

	// Use this for initialization
	void Start () {
		VirtualButtonBehaviour vbuttonBehavior = (VirtualButtonBehaviour) gameObject.GetComponent(typeof(VirtualButtonBehaviour));
		vbuttonBehavior.RegisterEventHandler(this);
		Debug.Log("I'm registered!");
		s.Stop();
		currentLiquid=initialLiquid;
	}
	
	// Update is called once per frame
	void Update () {
		float zdist,xdist;
		zdist=buretteTip.position.z-flaskCenter.position.z;
		xdist=buretteTip.position.x-flaskCenter.position.x;
		dist=Math.Sqrt(xdist*xdist+zdist*zdist);
	
		if(dist<=2)
		{
			Debug.Log("placed");
			if(step2.enabled)
			{
				step3.enabled=true;
				inst.text = "Press the red Button till liquid turns pink";
			}
			if(pressed)
			{

				currentLiquid=currentLiquid-(drainRate*Time.deltaTime);
				qty.text=Math.Round(currentLiquid,1)+" ml";
				waterLevel.transform.localScale-=scaleRate;
				buttonMesh.renderer.enabled=false;
				if(s.isStopped)
				{
					s.Play();
				}
			}
		}
		if(currentLiquid<40)
		{
			flaskWater.renderer.material=redColor;
			step5.enabled=true;
			inst.text = "Obsereve the reading on burette";
			expl.enabled=true;
			isExpComplete=true;
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

	public void OnButtonPressed(VirtualButtonAbstractBehaviour v)
	{
		pressed=true;
		Debug.Log("Pressed"+v.VirtualButtonName);
		if(step3.enabled && dist<=2)
		{
			step4.enabled=true;
		}


	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour v1)
	{
		Debug.Log("Released");
		s.Stop();
		pressed=false;
		buttonMesh.renderer.enabled=true;
	}

}
