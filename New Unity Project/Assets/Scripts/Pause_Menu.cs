using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : MonoBehaviour
    {

        public GameObject Pause_UI;

        private bool paused = false;

        private void Start()
        {
            Pause_UI.SetActive(false);
        }

        void Update()
        {
            if (Input.GetButtonDown("Pause"))
            {
                paused = !paused;
            }

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
    }
