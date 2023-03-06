/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 28/01/2023
*/
using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.SceneManagement;


using Bikerz;


namespace Mobs {
    public class MobsDifficulty : MonoBehaviour {
        const string DEBUG_MSG_DONE = "Max Level reached.\n";


        const float MOB_SPEED_INIT = 0.0005f,
            MOB_SPEED_MAX = 1.25f;


        const float MOB_SPEED_STEP = 2.00f;


        const int LEVEL_INCREASE_MIN = 0,
            LEVEL_INCREASE_MAX = 4;


        public float speedValue = MOB_SPEED_INIT,
            multipleValue = MOB_SPEED_MAX;
            
            
        public float result = 0.00f;
        public int levelCount;
        public bool levelUp;


        void Start() {
            levelCount = LEVEL_INCREASE_MIN;
            levelUp = false;
        }

        
        void Update() {
            if(levelUp == true) {
                if(levelCount < LEVEL_INCREASE_MAX) {
                    speedValue *= MOB_SPEED_STEP;
                    multipleValue *= MOB_SPEED_STEP;


                    levelUp = false;
                } 

            } 
            

            result = speedValue * multipleValue;
        }

    }

}