/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 19/01/2023
*/
using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


using Mobs;


namespace Levels {
    public class LevelTimer : MonoBehaviour {
        const int EXIT_CODE = 0;


        const string GAME_SCREEN = "Test Area",
            MSG_TITLE = "Level Completed!",
            MSG_DISPLAY = "You have finished this level!!!",
            MSG_RESTART = "Restart",
            MSG_EXIT = "Exit";


        const float TIMER_START = 30.00f,
            TIMER_END = 0.00f;


        float timer = -1.00f;
        bool timeIsUp = false,
            msgResult = false;


        public int givenCount;
        public bool givenLvlResult;


        void Start() {
            timer = TIMER_START; // INIT - Starting time value
        }


        /* TODO
        */
        void Update() {
            if(timeIsUp == true) {
                msgResult = EditorUtility.DisplayDialog(
                    MSG_TITLE,
                    MSG_DISPLAY,
                    MSG_RESTART,
                    MSG_EXIT
                );

                
                if(msgResult == true) {
                    GameObject.Find("Level Manager").GetComponent<LevelManager>().restart = true;
                } else {
                    SceneManager.UnloadSceneAsync(GAME_SCREEN);
                    Application.Quit(EXIT_CODE);
                }


                timer = TIMER_START;
                timeIsUp = false;
                msgResult = false;
            }


            if((timer -= Time.deltaTime) <= TIMER_END) {
                timeIsUp = true;
            }

        }

    }

}
