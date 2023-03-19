using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPuaseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
       
            if(Input.GetKeyDown("escape"))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
                //Application.Quit();
            }
        

    }
    
    void Resume ()
    {
        //movement.enabled = true;
        //cameralook.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    void Pause ()
    {
        //movement.enabled = false;
        //cameralook.enabled = false;
        pauseMenuUI.SetActive(true);
        //Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
