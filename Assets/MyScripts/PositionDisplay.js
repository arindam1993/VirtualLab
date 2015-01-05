#pragma strict
var b:Transform;
var g:Transform;
function Start () {

}

function Update () {
var beakerRot=b.eulerAngles; 
var groundRot=g.eulerAngles;
gameObject.guiText.text="Beaker Angle: "+beakerRot.x+" Ground Angle:"+groundRot.x;
/*if(beakerRot.x>45 && beakerRot.x<90)
{	
	if(water.isStopped)
	{
		water.Play();
		Debug.Log("Pour");
	}
	initialLiquid=initialLiquid-(1*Time.deltaTime);
	infoText.text="Amount:"+initialLiquid;
}
else
{
	if(water.isPlaying)
	{
		water.Stop();
		Debug.Log("NotPour");
	}
}
	*/
}