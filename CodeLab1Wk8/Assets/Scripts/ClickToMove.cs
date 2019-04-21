using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour

{
 
 private bool flag = false;

 private Vector3 endingPlace;
 
 public float duration = 75.0f;

 private float yAxis;
 
 void Start(){
  
  yAxis = gameObject.transform.position.y;
 }
  
 
 void Update () {
 
  
  if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
  {
   
   RaycastHit hit;
  
   Ray ray;
 
 
   ray = Camera.main.ScreenPointToRay(Input.mousePosition);
  
  
   ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
          
 
  
   if(Physics.Raycast(ray,out hit))
   {
   
    flag = true;
   
    endingPlace = hit.point;
   
    endingPlace.y = yAxis;
    
   }
    
  }
  
  if(flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endingPlace.magnitude))
  { 
   gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endingPlace, 1/(duration*(Vector3.Distance(gameObject.transform.position, endingPlace))));
  }
  
  else if(flag && Mathf.Approximately(gameObject.transform.position.magnitude, endingPlace.magnitude)) {
   flag = false;
  
  }
   
 }
}