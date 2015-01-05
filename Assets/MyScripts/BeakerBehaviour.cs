using UnityEngine;
using System.Collections;
using System;

public class BeakerBehaviour : MonoBehaviour {

	public ParticleSystem pourEffect;
	public float initialLiquid;
	public float drainRate;
	public TextMesh infoText;
	private Vector3 beakerRot;
	// Use this for initialization
	void Start () {
	

	}

	// Update is called once per frame
	void Update () {
		beakerRot=transform.eulerAngles;
		if(beakerRot.x>45 && beakerRot.x<90)
		{	
			if(pourEffect.isStopped)
			{
				pourEffect.Play();
				Debug.Log("Pour");
			}
			initialLiquid=initialLiquid-(drainRate*Time.deltaTime);
			infoText.text="Amount:"+Math.Round(initialLiquid,1)+"ml";
		}
		else
		{
			if(pourEffect.isPlaying)
			{
				pourEffect.Stop();
				Debug.Log("NotPour");
			}
		}
	
	}
}
