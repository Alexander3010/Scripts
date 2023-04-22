using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform transformCamera;
    private Transform transformPlayer;

    // camera control values
    private float mouseY;  
    private float mouseX;
    [SerializeField] private float maxRotationX;
    [SerializeField] private float minRotationX;
    private float rotationX = 0f;
    public bool rotationCameraACtive = true;

    private void Start(){
        transformPlayer = GetComponent<Transform>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update(){
        if(rotationCameraACtive){
            mouseY = Input.GetAxis("Mouse Y")*mouseSensitivity;
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, minRotationX, maxRotationX);
            mouseX = Input.GetAxis("Mouse X")*mouseSensitivity;

            transformPlayer.Rotate(0f,mouseX,0f);
            transformCamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        }
    }
}
