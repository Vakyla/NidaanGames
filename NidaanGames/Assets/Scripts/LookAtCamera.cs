using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    public enum addRotation { none,up,down,left,right,xAt0,yAt0,zAt0 }
    public addRotation rotationType;
    public Transform target;
    public Transform centerPanel;
    public float damping;
    public float dist;
    public float allowMargin;
    public bool rotateWhenClose;
    void Update()
    {
        if (target)
        {
            dist = Vector3.Distance(target.position, centerPanel.position);
            //print("Distance to other: " + dist);
            if (dist > allowMargin && rotateWhenClose == false)
            {
                Rotate();
            }
            else if (dist < allowMargin && rotateWhenClose == true)
            {
                Rotate();
            }

        }
    }
    public void RotateWhenOpen()
    {
        
            for (int i =0; i <= 100; i++)
            {
            Rotate();
            }
       
     
    }
    // Update is called once per frame
    public void Rotate()
    {
        switch (rotationType)
        {
            case addRotation.none:
                transform.LookAt(target);
                    break;
            case addRotation.up:
                transform.LookAt(target,Vector3.up);

                    break;
            case addRotation.down:
                transform.LookAt(target, Vector3.down);
                break;
            case addRotation.left:
                transform.LookAt(target, Vector3.left);
                break;
            case addRotation.right:
                transform.LookAt(target, Vector3.right);
                break;
            case addRotation.xAt0:
                var lookPosX = target.position - transform.position;
                lookPosX.x = 0;
                var rotationX = Quaternion.LookRotation(lookPosX);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotationX, Time.deltaTime * damping);
                break;
            case addRotation.yAt0:
                var lookPosY = target.position - transform.position;
                lookPosY.y = 0;
                var rotationY = Quaternion.LookRotation(lookPosY);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotationY, Time.deltaTime * damping);
                break;
            case addRotation.zAt0:
                var lookPosZ = target.position - transform.position;
                lookPosZ.z = 0;
                var rotationZ = Quaternion.LookRotation(lookPosZ);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotationZ, Time.deltaTime * damping);
                break;
        }
    }
}
