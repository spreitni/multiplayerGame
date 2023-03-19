using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class MouseLook : MonoBehaviourPunCallbacks
{
    public float mouseSensitivity = 100f;
    public GameObject pauseMenu;
    public Transform playerBody;
    public GameObject pauseMenuUI;
    float xRotation = 0f;

 
    // Start is called before the first frame update
    void Start()
    {
        if(photonView.IsMine)
        {
        Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {   

        if(photonView.IsMine)
        {
            
        if(pauseMenu.activeSelf == false)
        {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f,90f);
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        playerBody.Rotate(Vector3.up * mouseX);
        }

        }


    }
}
