using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDetection : MonoBehaviour {

    public bool gazingTrue;
    public CameraTeleportation actorEnemyManager = null;
    public CameraTeleportation temperaryActor;
    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {

            actorEnemyManager = hit.transform.GetComponent<CameraTeleportation>();
            
            if (actorEnemyManager != null) //  Checking if we found a component
            {
                temperaryActor = actorEnemyManager;
                actorEnemyManager.OnGazeEnter();
                gazingTrue = true;
            }
            if (actorEnemyManager == null && temperaryActor != null)
            { //  Checking if we found a component
                gazingTrue = false;
                Debug.Log("Nothing is OnGazeExit!!!!!!!!!!!!!!!!!!!");
                temperaryActor.OnGazeExit();
                temperaryActor = null;
            }

        }
       
    }
      
}
