using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Levels {
    public class LevelTimer : MonoBehaviour {
        const float TIMER_START = 0.00f,
            TIMER_END = 0.00f;
        

        float timer = 0.00f;
        bool isTimeUp = false;

        
        void Start() {
            timer = TIMER_START; // INIT - Starting time value
        }

        
        /* TODO
        */
        void Update() {  
            GameObject.Find("Level Timer").GetComponent<LevelTimer>();
            
            /*
            if((timer += Time.deltaTime) >= TIMER_END) {
                Application.Quit();
            }
            */
        }

    }

}