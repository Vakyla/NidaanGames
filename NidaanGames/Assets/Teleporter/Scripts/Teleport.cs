using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour {
    public bool TeleportEnabled {
        get { return teleportEnabled; }
    }
    public int levenNumber;
    public Transform cameraTarget;
    public Transform pointer;
    public Bezier bezier;
    public GameObject teleportSpriteFloor;
    public GameObject teleportSpriteWall;
    public GameObject teleportSpriteDoor;
    public GameObject teleportSpriteIssue;
    public GameObject teleportSpriteUnknown;
    public GameObject teleportSpriteUI;
    public GameObject teleportSprite;
    public LookAtCamera lookAtCamera;
    public OVRScreenFade oVRScreenFade;//alocating of fade script
    private bool teleportEnabled;
    public bool menuOpen;
    public float cameraHight = 1f;
    public List <GameObject> disableObjects;
    public string currentTag;
    public GameObject userInterface;
    public bool activateTeleportation = true;
    public bool test;
    public BeingHitByRay actorManager = null;
    public BeingHitByRay temperaryActor;
    public List<BeingHitByRay> beingHitByRaysList;
    public List<GameObject> disableForMenu;
    public List<GameObject> disableForHouse;
    public bool testClick;
    public bool interactionPointOpen;
    public List<GameObject> interActionPoints;
    public List<GameObject> resetMenu;
    public List<GameObject> defaltMenu;
    public List<GameObject> tutorials;
    public bool tutorialFloor;
    public SFX_Controller sFX_Controller;
    public GameController gameController;
    bool oneTime = false;

    void Start() {
        teleportEnabled = false;
        menuOpen = false;
        disableObjects.Add(teleportSpriteFloor);
        disableObjects.Add(teleportSpriteWall);
        disableObjects.Add(teleportSpriteDoor);
        disableObjects.Add(teleportSpriteIssue);
        disableObjects.Add(teleportSpriteUnknown);
        disableObjects.Add(teleportSpriteUI);
        UpdateSprite();
    }
	
	void Update ()
    {
        UpdateTeleportEnabled();
        string tag = bezier.TeleportSprite;

        if (teleportEnabled)
        {
            HandleBezier();
            HandleTeleport();

            if (currentTag != tag)
                {
                    currentTag = tag;
                    //ConsolOutput.text = tag;
                    UpdateSprite();
                    TagCheck();
                }
        }
        else if (interactionPointOpen == true)
        {
             foreach(GameObject obj in interActionPoints)
            {
                obj.SetActive(true);
            }  
        }
    }
    private void FixedUpdate()
    {
        actorManager = bezier.actorManagerBezier;
        
       
       if (actorManager != null) //  Checking if we found a component
        {

            temperaryActor = actorManager;
            if (actorManager != beingHitByRaysList.Contains(actorManager) )
            {
                beingHitByRaysList.Add(actorManager);
            }
            else if ( beingHitByRaysList.Count > 1 || actorManager != temperaryActor)
            {
                GazeExit();
            }
            temperaryActor.OnGazeEnter();
        }
        else if (actorManager == null && temperaryActor != null)
        {
            GazeExit();
        }
       


    }

    public void GazeExit()
    {
        if (temperaryActor != null)
        {
            temperaryActor.OnGazeExit();
            if (beingHitByRaysList.Count >= 0)
            {
                foreach(BeingHitByRay bhr in beingHitByRaysList)
                {
                    bhr.OnGazeExit();
                }
            }
        }
        
    }
       
    void UpdateSprite()
    {
        foreach(GameObject dis in disableObjects)
        {
            dis.SetActive(false);
        }
    }
    void TagCheck()
    {
        switch (currentTag)
        {
            case "Floor":
                teleportSpriteFloor.SetActive(true);
                teleportSprite = teleportSpriteFloor;
                bezier.SEGMENT_COUNT = 10;
                break;
            case "Wall":
                teleportSpriteWall.SetActive(true);
                teleportSprite = teleportSpriteWall;
                bezier.SEGMENT_COUNT = 2;
                break;
            case "Door":
                teleportSpriteDoor.SetActive(true);
                teleportSprite = teleportSpriteDoor;
                bezier.SEGMENT_COUNT = 2;
                break;
            case "Issue":
                teleportSpriteIssue.SetActive(true);
                teleportSprite = teleportSpriteIssue;
                bezier.SEGMENT_COUNT = 2;
                break;
            case "Untagged":
                teleportSpriteUnknown.SetActive(true);
                teleportSprite = teleportSpriteUnknown;
                bezier.SEGMENT_COUNT = 2;
                break;
            case "UI":
                teleportSpriteUI.SetActive(true);
                teleportSprite = teleportSpriteUI;
                bezier.SEGMENT_COUNT = 2;
                break;

        }
    }
    // On double-click, toggle teleport mode on and off.
    void UpdateTeleportEnabled() {
     
        if (activateTeleportation)
        {
            activateTeleportation = false;
            ToggleTeleportMode();
        }
        if(levenNumber == 1)
            {
                if (OVRInput.GetDown(OVRInput.Button.One)  || test )
                {
                    test = false;
                    if (!menuOpen)
                    {
                        oVRScreenFade.FadeIn();
                        userInterface.GetComponent<Animator>().SetTrigger("open");
                        ActivateDiscoverPoint();
                        DeActivate();
                        lookAtCamera.RotateWhenOpen();
                        menuOpen = true;
                    }
                    else
                    {
                        userInterface.GetComponent<Animator>().SetTrigger("close");
                        Activate();
                        menuOpen = false;
                        ResetMenu();
                        oVRScreenFade.FadeIn();
                    }
                }
                
            }
        
      
    }

    void HandleTeleport() {
        if (bezier.endPointDetected) { // There is a point to teleport to.
            // Display the teleport point.
            teleportSprite.SetActive(true);
            teleportSprite.transform.position = bezier.EndPoint;
            if(currentTag != "Floor")
            {
                teleportSprite.transform.LookAt(cameraTarget);
            }

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)|| testClick == true)
            {
                // Teleport to the position.
                if (currentTag == "Floor")
                {
                    TeleportToPosition(bezier.EndPoint);
                    sFX_Controller.PlayTeleportation();
                    if (tutorialFloor == false)
                    {
                        tutorials[0].SetActive(false);
                        tutorialFloor = true;
                    }
                       
                }
                if (actorManager != null && currentTag == "UI")
                {
                    actorManager.Click();
                }
                testClick = false;
            }
        } else {
            teleportSprite.SetActive(false);
        }
    }
 
    void TeleportToPosition(Vector3 teleportPos) {
        gameObject.transform.position = teleportPos + Vector3.up * cameraHight;
        oVRScreenFade.FadeIn();
    }

    // Optional: use the touchpad to move the teleport point closer or further.
    void HandleBezier() {
        Vector2 touchCoords = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        if (Mathf.Abs(touchCoords.y) > 0.8f) {
            bezier.ExtensionFactor = touchCoords.y > 0f ? 1f : -1f;
        } else {
            bezier.ExtensionFactor = 0f;
        }
    }

    void ToggleTeleportMode() {
        teleportEnabled = !teleportEnabled;
        bezier.ToggleDraw(teleportEnabled);
        if (!teleportEnabled) {
            teleportSprite.SetActive(false);
        }
    }

    void DeActivate()
    {
        foreach(GameObject obj in disableForMenu)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in disableForHouse)
        {
            obj.SetActive(true);
        }
    }
    void Activate()
    {
        foreach (GameObject obj in disableForMenu)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in disableForHouse)
        {
            obj.SetActive(false);
        }
    }
    public void OpenMenu()
    {
        test = true;
    }
    public void StartChapter3(float time)
    {
        StartCoroutine(StartHouseLevel(time));

    }
    public void AddInteractionPoint(bool pointOpen)
    {
       
        if(interActionPoints.Count > 0 && interactionPointOpen == true)
        {
            foreach(GameObject obj in interActionPoints)
            {
                obj.GetComponent<AnimationScript>().PlayEffect(3);
            }
        }
        interActionPoints.Clear();

        interActionPoints.Add(bezier.interactionPoint);
       
        
        interactionPointOpen = pointOpen;
    }
    public void ActivateDiscoverPoint()
    {
        foreach(GameObject obj in interActionPoints)
        {
            obj.GetComponent<Collider>().enabled = true;
        }
    }
    public void ResetMenu()
    {
        foreach(GameObject obj in resetMenu)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in defaltMenu)
        {
            obj.SetActive(true);
        }
    }

    public void OpenMenuAfterSomeTime(float time)
    {
       
        if(oneTime == false)
        {
            StartCoroutine(OpenMenuTimer(time));
            oneTime = true;

        }
       
    }
    IEnumerator OpenMenuTimer(float time)
    {
        yield return new WaitForSeconds(time);
        OpenMenu();

    }
    IEnumerator StartHouseLevel(float time)
    {
        yield return new WaitForSeconds(time);
        oVRScreenFade.FadeIn();
        Activate();
        gameController.ChangeLevel(1);
    }
}
