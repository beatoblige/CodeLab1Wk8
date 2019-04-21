using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform lookAtTarget; 

    void Update()
    { 
        if ( lookAtTarget == null ) 
        {
            return; 
        }
        Vector3 forward = lookAtTarget.position - transform.position; 
        
        Quaternion targetRotation = Quaternion.LookRotation( forward );
    
        transform.rotation = Quaternion.Slerp( transform.rotation, targetRotation, 10f * Time.deltaTime );
    }

}
