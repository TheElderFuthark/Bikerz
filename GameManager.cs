/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Levels;


namespace Bikerz {
    public class GameManager : MonoBehaviour {
        const string DEBUG_SUCCESS = "Game started...",
            DEBUG_FAIL = "ERROR: Failed to start game...";


        const string GAME_OBJECT_MANAGER = "Game Manager",
            GAME_OBJECT_HANDLER = "Game Handler",
            GAME_OBJECT_LEVELS = "Level Manager";


        GameObject StartLevelManager(
            GameObject obj
        ) {
            GameObject objRef = obj;
            objRef.name = GAME_OBJECT_LEVELS;


            objRef.AddComponent<LevelManager>();
            objRef.transform.position = new Vector3(
                2.00f, 
                0.00f, 
                0.00f
            );


            objRef.transform.parent = GameObject.Find(GAME_OBJECT_MANAGER).transform;
            return objRef;
        }


        GameObject StartGame(
            GameObject obj
        ) {
            GameObject objRef = obj;
            objRef.name = GAME_OBJECT_MANAGER;


            objRef.transform.position = new Vector3(
                0.00f, 
                0.00f, 
                0.00f
            );


            objRef.transform.parent = GameObject.Find(GAME_OBJECT_HANDLER).transform;
            return objRef;
        }


        void Start() {
            if(GameObject.Find(GAME_OBJECT_HANDLER)) {
                if( StartGame(new GameObject()) && 
                    StartLevelManager(new GameObject())
                ) {
                    Debug.Log(DEBUG_SUCCESS);
                }
            } else {
                Debug.Log(DEBUG_FAIL);
                Application.Quit();
            }

        }


        void Update() {
        } // Do nothing...

    }

}