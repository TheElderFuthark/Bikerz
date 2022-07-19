using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Levels {
    public class LevelTimer : MonoBehaviour {
        const string GAME_SCREEN = "Test Area";


        const float TIMER_START = 30.00f,
            TIMER_END = 0.00f;


        float timer = -1.00f;
        bool timeIsUp = false;


        void Start() {
            timer = TIMER_START; // INIT - Starting time value
        }


        /* TODO
        */
        void Update() {
            if (timeIsUp == true) {
                SceneManager.LoadScene(GAME_SCREEN);
            }


            if((timer -= Time.deltaTime) <= TIMER_END) {
                timeIsUp = true;
            }

        }

    }

}
