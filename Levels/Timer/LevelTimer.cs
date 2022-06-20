using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Levels {
    public class LevelTimer : MonoBehaviour {
        const float TIMER_START = 3.00f,
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
                Application.Quit();
            }

            
            if((timer -= Time.deltaTime) <= TIMER_END) {
                timeIsUp = true;
            }
            
        }

    }

}