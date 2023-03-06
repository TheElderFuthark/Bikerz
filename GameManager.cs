/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 09/10/2022
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
            GAME_OBJECT_DATA = "Game Data Tracker",
            GAME_OBJECT_HANDLER = "Game Handler",
            GAME_OBJECT_LEVELS = "Level Manager",
            GAME_OBJECT_MENUS = "Menu Manager";


        const string MAIN_MENU = "Main Menu",
            PAUSE_MENU = "Pause Menu",
            GAME_SCREEN = "Test Area";


        GameObject obj_Game,
            obj_Screen_Manager,
            obj_Screens,
            obj_Screen_Game,
            obj_Screen_Menu,
            obj_Menus;


        public string screen = "";


        public bool playerDead = false, 
            reset = false;


        public GameObject ResetGame(
            GameObject obj
        ) {
            GameObject objRef = obj;
            objRef.name = GAME_OBJECT_MANAGER;


            objRef.AddComponent<GameManager>();
            objRef.transform.parent = GameObject.Find(GAME_OBJECT_HANDLER).transform;


            return objRef;
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
            objRef.AddComponent<MenuActions>();
            objRef.AddComponent<MenuControls>();
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
            /*  WARNING: Game won't start unless there is already an 
                object called "Game Handler in the scene... This is a deliberate
                feature for testing purposes. 
            */
            if(GameObject.Find(GAME_OBJECT_HANDLER)) {
                obj_Game = GameObject.Find(GAME_OBJECT_HANDLER);
                DontDestroyOnLoad(obj_Game);


                // Prevents duplicate instance/s...
                if(!(GameObject.Find("Screen Manager")) && 
                    !(GameObject.Find(GAME_OBJECT_MENUS))
                ) {
                    obj_Screens = GetScreenManager(new GameObject());
                    obj_Menus = GetMenuManager(new GameObject());
                }

                /* Sets first screen */
                screen = GAME_SCREEN;
            }

        }


        void Update() {
            /*  Prevents disconnection from the 
                overall flow of the program/game.
            */
            if(!obj_Screens && 
                !obj_Menus
            ) {
                obj_Screens = GameObject.Find("Screen Manager");
                obj_Menus = GameObject.Find(GAME_OBJECT_MENUS);
            }


            if(obj_Screens.GetComponent<ScreenManager>().SelectScreen(
                obj_Game, // WARNING: THIS IS THE ENTIRE GAME INSTANCE...
                obj_Menus,
                obj_Screens,
                screen
            ) == true) {
                obj_Screens.GetComponent<GameScreen>().set = false;
                if(obj_Menus.GetComponent<MenuManager>().menu == MAIN_MENU) {
                    screen = MAIN_MENU;
                } else if(obj_Menus.GetComponent<MenuManager>().menu == PAUSE_MENU) {
                    screen = PAUSE_MENU;
                }
            } else {
                obj_Screens.GetComponent<GameScreen>().set = true;
                screen = GAME_SCREEN;
            }

        }

    }

}
