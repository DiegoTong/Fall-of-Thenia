using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject PauseMenuUI;
    public Camera MainCamera;
   

    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetKeyDown(KeyCode.P)) //if P is pressed pause game, will have to switch this for x1 to buttondown
        {
            if(IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();

            }

        }

        if (Input.GetKeyDown(KeyCode.Escape)) //in theory if the back button on the android is clicked it should open the menu, might change this to a section of the touch screen
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();

            }
        }

    }

    void Resume()
    {
        PauseMenuUI.SetActive(false); //Activates Pause Menu
        Time.timeScale = 1f; // releases the frame freeze? thats what im calling it 
        IsPaused = false;
    }

   void Pause()
    {
        PauseMenuUI.SetActive(true); //Activates Pause Menu
        Time.timeScale = 0f; // its suppose to the freeze the frame D:
        IsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    

        

    }
}
