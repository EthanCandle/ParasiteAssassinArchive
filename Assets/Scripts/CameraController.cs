using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody, pivotPoint, cameraObject;
    float xRotation = 0f, yRotation = 0f;
    public float negClamp = -20, posClamp = 20;
    public PlayerMovement pm;
    public bool Locked;
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(LateStart(1f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(pm.dashing || Locked)
        {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, negClamp, posClamp);
        //  yRotation -= mouseX;
        // yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        pivotPoint.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
         playerBody.Rotate(Vector3.up * mouseX);
        //pivotPoint.Rotate(Vector3.right * mouseY);
       
        // playerBody.rotation = Quaternion.Euler(0, mouseX, 0);
        // transform.LookAt(pivotPoint);
        //pivotPoint.rotation = Quaternion.Euler(mouseY, mouseX, 0);
      
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Locked = false;
        //Your Function You Want to Call
    }

}
