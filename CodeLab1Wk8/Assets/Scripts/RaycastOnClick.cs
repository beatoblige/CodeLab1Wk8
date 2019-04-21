using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaycastOnClick : MonoBehaviour
{
    void Update()
    {
     //Ray variable 
        Ray rayCast = Camera.main.ScreenPointToRay( Input.mousePosition );

       
        Debug.DrawRay( rayCast.origin, rayCast.direction * 1000f, Color.red );

        //raycast info in scene
        RaycastHit myRaycastHitInfo = new RaycastHit();

        if ( Input.GetMouseButtonDown( 0 ) ) {
           
            if ( Physics.Raycast( rayCast, out myRaycastHitInfo, 1000f ) ) {
                
                //Destroy( myRaycastHitInfo.collider.gameObject );

            
                myRaycastHitInfo.transform.Translate( -1.0f, 1f, 0f);

                
                myRaycastHitInfo.transform.GetComponent<Renderer>().material.color = new Color(1f, 0f, 1f, 1f);
            }
        }
    }

    

}
