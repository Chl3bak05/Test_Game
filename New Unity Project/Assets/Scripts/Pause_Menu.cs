using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
    {
    //References
        public GameObject Pause_UI;
    //Boolean
        private bool paused = false;

        
    
        private void Start()
        {
        //Default off Pause screen
        Pause_UI.SetActive(false);
        }

        void Update()
        {
            //On off pause screen
            if (Input.GetButtonDown("Pause"))
            {
                paused = !paused;
            }
            //Time switch
            if (paused)
            {
                Pause_UI.SetActive(true);
                Time.timeScale = 0;

            }
            if (!paused)
            {
                Pause_UI.SetActive(false);
                Time.timeScale = 1;

            }
        }
    //Pause Buttons
    public void Resume()
    {
        paused = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
