using UnityEngine;
using System.Collections;

public class RayDiverge : MonoBehaviour {
	
	// Use this for initialization
	public Transform r1;
	public Transform r2;
	public Transform r3;
	public Transform r1d;
	public Transform r2d;
	public Transform r3d;
	public Transform midray;
	public Transform topray;
	public Transform botray;
	private bool isHit=false;
	void OnTriggerEnter(Collider RayHit)
	{
		isHit=true;
		r1.renderer.enabled=true;
		r2.renderer.enabled=true;
		r3.renderer.enabled=true;
		
	}
	
	void OnTriggerExit(Collider RayHit)
	{
		r1.renderer.enabled=false;
		r2.renderer.enabled=false;
		r3.renderer.enabled=false;
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isHit)
		{
			Ray mr=new Ray(midray.position,midray.forward);
			Ray tr=new Ray(topray.position,topray.forward);
			Ray br=new Ray(botray.position,botray.forward);
			Debug.DrawRay(mr.origin, mr.direction*22, Color.green);
			RaycastHit mhit;
			RaycastHit thit;
			RaycastHit bhit;
			if(Physics.Raycast(mr, out mhit))
			{
				r2d.position=mhit.point;
			}
			if(Physics.Raycast(tr, out thit))
			{
				r1d.position=thit.point;
			}
			if(Physics.Raycast(br, out bhit))
			{
				r3d.position=bhit.point;
			}
			
			r1d.LookAt(mr.GetPoint(RayBehaviour.length-2));
			r2d.LookAt(mr.GetPoint(RayBehaviour.length-2));
			r3d.LookAt(mr.GetPoint(RayBehaviour.length-2));
		}
		
	}
}
