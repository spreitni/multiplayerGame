using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class Player : MonoBehaviourPunCallbacks
{

    public GameObject gun;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject pauseMenu;
    private Camera m_Camera;
    private bool PauseMenuStatus = false;
    private float x;
    private float z;
    private float y;
    // Start is called before the first frame update
    void Start()
    {

        m_Camera = Camera.main;
        gun2.SetActive(false);
        gun3.SetActive(false);
        if(!photonView.IsMine)
        {
            m_Camera.enabled = false;

        }
    }
    // Update is called once per frame
    void Update()
    {   

        if(photonView.IsMine)
        {   
            if(pauseMenu.activeSelf == false)
            {
            x = Input.GetAxis("Horizontal") * 10f * Time.deltaTime;
            z = Input.GetAxis("Vertical") * 10f* Time.deltaTime;
            y = Input.GetAxis("Jump") * 10f* Time.deltaTime;
            if(Input.GetKeyDown("1"))
            {
                gun.SetActive(true);
                gun2.SetActive(false);
                gun3.SetActive(false);
                
            }
            if(Input.GetKeyDown("2"))
            {
                gun.SetActive(false);
                gun2.SetActive(true);
                gun3.SetActive(false);
            }
            if(Input.GetKeyDown("3"))
            {
                gun.SetActive(false);
                gun2.SetActive(false);
                gun3.SetActive(true);
            }
            }
            if(pauseMenu.activeSelf == true) //stops player dead in tracks when game pauses
            {
            x = Input.GetAxis("Horizontal") * 0f * Time.deltaTime;
            z = Input.GetAxis("Vertical") * 0f* Time.deltaTime;
            y = Input.GetAxis("Jump") * 0f* Time.deltaTime;
            }
            /* added a pause menu
            if(Input.GetKeyDown("escape"))
            {
                Application.Quit();
            }*/
            transform.Translate(x,y,z);
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(PauseMenuStatus == true)
                {
                     pauseMenu.SetActive(false);
                     PauseMenuStatus = false;
                }
                else{
                pauseMenu.SetActive(true);   
                PauseMenuStatus = true;                    
                }
                /*
                if(PauseMenuStatus == false)
                {
                pauseMenu.SetActive(true);   
                PauseMenuStatus = true;
                }*/


                


            }
        }
    }
}


