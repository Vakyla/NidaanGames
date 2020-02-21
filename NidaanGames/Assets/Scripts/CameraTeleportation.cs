using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class CameraTeleportation : MonoBehaviour{

	public bool gazedAtSomething = false;
	public bool cameraReset = false;
	public float timerDuration = 2f;	//how long to look at the  menu before taking action
	public float lookTimer = 0f;		// this starting value for duration of the count down
	public GameObject mainCamera;
	public GameObject [] materials;
	public Transform directionIn;
	public Transform directionOut;
    public Transform currentDirectionActive;
    public bool whentThrou = false;
    public bool coolDown = false;
    public bool floor;
    public OVRScreenFade oVRScreenFade;

    public void Reset() {

        foreach (GameObject objectMaterial in materials)
        {
            objectMaterial.GetComponent<TexureEffects>().activate = false;
            objectMaterial.GetComponent<Renderer>().material.color = Color.white;
            objectMaterial.GetComponent<TexureEffects>().rotationOffsetX = 0.0f;
            objectMaterial.GetComponent<TexureEffects>().rotationOffsetY = 0.5f;
            objectMaterial.GetComponent<TexureEffects>().activate = true;
        }
        currentDirectionActive = whentThrou == true ? currentDirectionActive = directionOut : currentDirectionActive = directionIn;
    }
		

	// Update is called once per frame
	void Update () 
	{
		if (gazedAtSomething) //if gazing at something start the timer
		{
			lookTimer += Time.deltaTime;

			if (lookTimer > timerDuration / 4 && lookTimer < timerDuration / 2)
            {//if been hazing at somethig for over half of lookTimer change the button colot to red
				foreach (GameObject objectMaterial in materials)
                {
                    objectMaterial.GetComponent<Renderer>().material.color = Color.yellow;
                    objectMaterial.GetComponent<TexureEffects>().rotationOffsetX = 5.0f;
                    objectMaterial.GetComponent<TexureEffects>().rotationOffsetY = 0.0f;
                    cameraReset = true;
                }
			}
			if (lookTimer > timerDuration / 2 && lookTimer < timerDuration)
            {
					
				foreach (GameObject objectMaterial in materials)
                {
                    objectMaterial.GetComponent<Renderer>().material.color = Color.red;
                    objectMaterial.GetComponent<TexureEffects>().scaleOffsetX = 0.10f;
                    objectMaterial.GetComponent<TexureEffects>().scaleOffsetY = 0.10f;
                    objectMaterial.GetComponent<TexureEffects>().ChangeScale();
                }
			}
            if(lookTimer > timerDuration)
            {
                oVRScreenFade.FadeIn();
                mainCamera.transform.position = currentDirectionActive.transform.position;
                if (floor == false)
                {
                    mainCamera.transform.rotation = currentDirectionActive.transform.rotation;
                }
                gazedAtSomething = false;
                whentThrou = whentThrou == true ? whentThrou = false : whentThrou = true;
                StartCoroutine(CoolDownTime());
                Reset();
            }
			
		}
		else 
		{
            lookTimer = 0;
		}
	}
	
	public void OnGazeEnter()
    {
        if (coolDown == false)
        {
            gazedAtSomething = true;
        }
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter was already called.
	public void OnGazeExit()
    {
        if (coolDown == false)
        {
            gazedAtSomething = false;
            if (cameraReset)
            {

                Reset();
                cameraReset = false;

            }
        }
		
    }
    IEnumerator CoolDownTime()
    {
        coolDown = true;
        yield return new WaitForSeconds(2f);
        coolDown = false;
    }

}

