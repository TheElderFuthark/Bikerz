/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using Bikerz;
using Levels;


namespace Screens {
    public class GameScreen : MonoBehaviour {
        const string GAME_OBJECT_HANDLER = "Game Handler",
            GAME_OBJECT_LEVELS = "Level Manager",
            GAME_OBJECT_MANAGER = "Game Manager";


        public bool set = false;


        public bool Run(
            GameObject handler
        ) {
            if(set == true) {
                return false;
            }


            if((!GameObject.Find(GAME_OBJECT_MANAGER)) &&
                (!GameObject.Find(GAME_OBJECT_LEVELS))
            ) {
                if((handler
                        .GetComponent<GameManager>()
                        .StartGame(new GameObject())) &&
                    (handler
                        .GetComponent<GameManager>()
                        .StartLevelManager(new GameObject()))
                ) {
                    set = true;
                }
            } else {
                set = true;
            }


            return false;
        }


        void Start() {
        }


        void Update() {
        }

    }

}
