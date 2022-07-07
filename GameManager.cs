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
using Player;


namespace Bikerz {
    public class GameManager : MonoBehaviour {
        const string DEBUG_SUCCESS = "Game started...",
            DEBUG_FAIL = "ERROR: Failed to start game...";


        const string GAME_OBJECT_MANAGER = "Game Manager",
            GAME_OBJECT_HANDLER = "Game Handler",
            GAME_OBJECT_LEVELS = "Level Manager",
            GAME_OBJECT_MENUS = "Menu Manager";


        const string MAIN_MENU = "Main Menu",
            PAUSE_SCREEN = "Pause Menu",
            GAME_SCREEN = "Test Area";


        GameObject obj_Game,
            obj_Screens,
            obj_Menus;


        string screen = "";


        void HandleGameError() {
            Debug.Log(DEBUG_FAIL);
            Application.Quit();
        }


        public GameObject StartGame(
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


        public GameObject StartLevelManager(
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


        GameObject GetScreenManager(GameObject obj) {
            GameObject objRef = obj;
            objRef.name = "Screen Manager";


            objRef.AddComponent<ScreenManager>();
            objRef.AddComponent<PauseMenuScreen>();
            objRef.AddComponent<MainMenuScreen>();
            objRef.AddComponent<GameScreen>();


            objRef.transform.parent = GameObject.Find(GAME_OBJECT_HANDLER).transform;
            return objRef;
        }


        void Start() {
            if(GameObject.Find(GAME_OBJECT_HANDLER)) {
                obj_Screens = GetScreenManager(new GameObject());
                obj_Menus = GetMenuManager(new GameObject());


                /* Sets first screen */
                screen = GAME_SCREEN;


                if(obj_Screens.GetComponent<ScreenManager>().SelectScreen(
                    obj_Menus,
                    obj_Screens,
                    screen
                ) == false) {
                    HandleGameError();
                }
            } else {
                HandleGameError();
            }

        }


        void Update() {
            if(GameObject.Find("Player").GetComponent<PlayerControls>().PauseGame() == true) {
                screen = PAUSE_SCREEN;
            } else {
                screen = GAME_SCREEN;
            }


            obj_Screens.GetComponent<ScreenManager>().SelectScreen(
                obj_Menus,
                obj_Screens,
                screen
            );

        }

    }

}
