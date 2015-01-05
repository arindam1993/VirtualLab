using UnityEngine;
using System.Collections;

public class BuretteControl : MonoBehaviour, IVirtualButtonEventHandler {

	public ParticleSystem drops;
	// Use this for initialization
	void Start () {
		VirtualButtonBehaviour vbuttonBehavior = (VirtualButtonBehaviour) gameObject.GetComponent(typeof(VirtualButtonBehaviour));
		vbuttonBehavior.RegisterEventHandler(this);
		Debug.Log("I'm registered!");
		drops.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnButtonPressed(VirtualButtonAbstractBehaviour v)
	{
		Debug.Log("Pressed"+v.VirtualButtonName);
		drops.Play();
	}
	
	public void OnButtonReleased(VirtualButtonAbstractBehaviour v1)
	{
		Debug.Log("Released");
		drops.Stop();
	}
}
