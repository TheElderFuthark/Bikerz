/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Screens;
using Levels;
using Menus;
using Graphics;


namespace Bikerz {
    public class GameManager : MonoBehaviour {
        const string DEBUG_SUCCESS = "Game started...",
            DEBUG_FAIL = "ERROR: Failed to start game...";


        const string GAME_OBJECT_MANAGER = "Game Manager",
            GAME_OBJECT_HANDLER = "Game Handler",
            GAME_OBJECT_LEVELS = "Level Manager",
            GAME_OBJECT_MENUS = "Menu Manager";


        const string GAME_SCREEN = "Test Area";


        GameObject obj_Screens,
            obj_Menus;


        void HandleGameError() {
            Debug.Log(DEBUG_FAIL);
            Application.Quit();
        }


        GameObject GetMenuManager(
            GameObject obj
        ) {
            GameObject objRef = obj;
            objRef.name = GAME_OBJECT_MENUS;
            
            
            objRef.AddComponent<MenuManager>();
            objRef.AddComponent<MainMenu>();
            objRef.AddComponent<PauseMenu>();
            objRef.AddComponent<DisplaySprite>();
            objRef.AddComponent<DrawSprite>();


            objRef.transform.parent = GameObject.Find(GAME_OBJECT_HANDLER).transform;
            return objRef;
        }


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


            objRef.transform.parent = GameObject.Find(GAME_OBJECT_HANDLER).transform;
            return objRef;
        }


        GameObject GetScreenManager(GameObject obj) {
            GameObject objRef = obj;
            objRef.name = "Screen Manager";
            
            
            objRef.AddComponent<ScreenManager>();
            objRef.AddComponent<GameScreen>();
            
            
            objRef.transform.parent = GameObject.Find(GAME_OBJECT_HANDLER).transform;
            return objRef;
        }


        bool SpawnAll(
            GameObject gameManager,
            GameObject levelManager
        ) {
            if( GameObject.Find(gameManager.name) && 
                GameObject.Find(levelManager.name)) {
                return true;
            }


            return false;
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
                obj_Screens = GetScreenManager(new GameObject());
                obj_Menus = GetMenuManager(new GameObject());


                if(obj_Screens.GetComponent<ScreenManager>().SelectScreen(
                    obj_Menus,
                    obj_Screens,
                    GAME_SCREEN // Test input
                )) {
                    if(SpawnAll(
                        StartGame(new GameObject()),
                        StartLevelManager(new GameObject())
                    )) {
                        Debug.Log(DEBUG_SUCCESS);
                    } else {
                        HandleGameError();
                    }

                }
            } else {
                HandleGameError();
            }

        }


        void Update() {
        } // Do nothing...

    }

}