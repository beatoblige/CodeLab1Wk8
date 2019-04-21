using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
   
    private Transform xTransCamera;

    private Transform xTransParent;

    private Vector3 localRotation;

    private float cameraDistance = 10f;

    public float mouseSensitivity = 4f;

    public float scrollSensitivty = 3f;

    public float orbitspeed = 9f;

    public float scrollSpeed = 6f;

    public bool cameraOff = false;

    // Start is called before the first frame update
    void Start()
    {
        this.xTransCamera = this.transform;
        this.xTransParent = this.transform;

    }
    
   


    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            cameraOff = !cameraOff;

        if (!cameraOff)
        {
            //Rotation of the Camera based on the x/y axis of the camera pointer 
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                localRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

                if (localRotation.y < 0f)
                    localRotation.y = 0f;
                else if (localRotation.y > 90f)
                    localRotation.y = 90f;

            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivty;
                scrollAmount *= (this.cameraDistance * 0.4f);
                this.cameraDistance += scrollAmount * -1f;
                this.cameraDistance =
                    Mathf.Clamp(this.cameraDistance, 5f, 100f); //clamps the cam >5m away, avoids flipping
            }

        }

        Quaternion QTerion = Quaternion.Euler(localRotation.y, localRotation.x, 0); //avoiding  "gimble lock"
        this.xTransParent.rotation = Quaternion.Lerp(this.xTransParent.rotation, QTerion, Time.deltaTime * orbitspeed);

        if (this.xTransCamera.localPosition.z != this.cameraDistance * -1f)
        {
            this.xTransCamera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this.xTransCamera.localPosition.z, this.cameraDistance * -1f, Time.deltaTime * scrollSpeed));
        }
    } //setting scroll distance and rotation of camera to values, not every frame. Properties are between frames.
}
    

