/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 09/10/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using Player;


namespace Menus {
    public class MenuManager : MonoBehaviour {
        const string MAIN_MENU = "Main Menu",
            PAUSE_MENU = "Pause Menu";


        const int MENU_DEFAULT = 0,
            MENU_GOTO_MAIN_MENU = 4,
            MENU_EXIT_GAME = 5;


        const string MAIN_NEW_GAME = "New Game",
            MAIN_LAST_LEVEL = "Load Last Game",
            MAIN_LEVEL_MENU = "Load Level",
            MAIN_OPTIONS_MENU = "Options",
            MAIN_CREDITS_SCREEN = "Credits",
            MAIN_EXIT_GAME = "Exit Game";


        const string PAUSE_RESTART = "Restart",
            PAUSE_OPTIONS_MENU = "Options",
            PAUSE_SAVE_GAME = "Save Checkpoint",
            PAUSE_LEVEL_MENU = "Load Level",
            PAUSE_EXIT_GAME = "Exit To Main Menu";


        // Var list/array input of ALL consts related to the main menu
        public List <string> options_main = new List <string> {
            MAIN_NEW_GAME,
            MAIN_LAST_LEVEL,
            MAIN_LEVEL_MENU,
            MAIN_OPTIONS_MENU,
            MAIN_CREDITS_SCREEN,
            MAIN_EXIT_GAME
        };


        // Var list/array input of ALL consts related to the pause menu
        public List <string> options_pause = new List<string> {
            PAUSE_RESTART,
            PAUSE_OPTIONS_MENU,
            PAUSE_SAVE_GAME,
            PAUSE_LEVEL_MENU,
            PAUSE_EXIT_GAME
        };


        // Trigger value/s
        public string menu = "",
            menuOption = "";


        // Process event trigger/s
        public bool active = false,
            optionEvent = false,
            enterPressed = false,
            escapePressed = false,
            credits = false,
            loadOptionsMenu = false,
            loadLevelMenu = false,
            loadLastSave = false,
            saveGame = false,
            newGame = false;


        public int index = 0;


        GameObject obj_Player,
            obj_Menu_Manager;


        void DisplayMenu() {
            /*  1) Draw Sprites
                2) Scale menus
                3) update menu option selected, and
                other UI features/animations
            */
        }


        public void Menu_OptionEvent(
            GameObject menuActions,
            string option
        ) {
            switch(option) {
                case MAIN_NEW_GAME:
                    menuActions.GetComponent<MenuActions>().NewGame();
                    break;
                case MAIN_LAST_LEVEL:
                    menuActions.GetComponent<MenuActions>().LoadLastSave();
                    break;
                case MAIN_LEVEL_MENU:
                    menuActions.GetComponent<MenuActions>().LoadLevelMenu();
                    break;
                case MAIN_OPTIONS_MENU:
                    menuActions.GetComponent<MenuActions>().LoadOptionsMenu();
                    break;
                case MAIN_CREDITS_SCREEN:
                    menuActions.GetComponent<MenuActions>().LoadCreditsScreen();
                    break;
                case MAIN_EXIT_GAME:
                    menuActions.GetComponent<MenuActions>().ExitGame();
                    break;
                case PAUSE_RESTART:
                    menuActions.GetComponent<MenuActions>().RestartLevel();
                    break;
                case PAUSE_SAVE_GAME:
                    menuActions.GetComponent<MenuActions>().SaveGame();
                    break;
                case PAUSE_EXIT_GAME:
                    //menuActions.GetComponent<MenuActions>().ExitToMainMenu();
                    break;
                default:
                    break;
            }

        }


        public string OptionSelected(
            List<string> options,
            int index
        ) {
            return options[index];
        }


        GameObject MenuControls_DisablePlayerControls(
            GameObject obj_Player
        ) {
            GameObject objRef = obj_Player;
            Destroy(objRef.GetComponent<PlayerControls>());            
            
            
            return objRef;
        }


        GameObject MenuControls_EnablePlayerControls(
            GameObject obj_Player
        ) {
            GameObject objRef= obj_Player;
            objRef.AddComponent<PlayerControls>();
            
            
            return objRef;
        }


        bool MenuControls_Escape(
            GameObject obj_Menus
        ) {
            GameObject objRef = obj_Menus;
            
            
            if(objRef.GetComponent<MenuControls>().EscapePressed() == true) {
                return true;
            }
            
            
            return false;
        }


        bool MenuControls_Enter(
            GameObject obj_Menus
        ) {
            GameObject objRef = obj_Menus;


            if(objRef.GetComponent<MenuControls>().EnterPressed() == true) {
                return true;
            }


            return false;
        }


        int MenuControls_Down(
            GameObject obj_Menus,
            string menu,
            int index
        ) {
            GameObject objRef = obj_Menus;
            int result = index;


            if(objRef.GetComponent<MenuControls>().DownPressed() == true && menu == MAIN_MENU) {
               if(result > 5) {
                    result = 5;
                } else {
                    result++;
                }
            } else if(objRef.GetComponent<MenuControls>().DownPressed() == true && menu == PAUSE_MENU) {
               if(result > 6) {
                    result = 6;
                } else {
                    result++;
                }

            }


            return result;
        }


        int MenuControls_Up(
            GameObject obj_Menus, 
            string menu,
            int index
        ) {
            GameObject objRef = obj_Menus;
            int result = index;


            if(objRef.GetComponent<MenuControls>().UpPressed() == true && menu == MAIN_MENU) {
               if(result < 0) {
                    result = 0;
                } else {
                    result--;
                }
            } else if(objRef.GetComponent<MenuControls>().UpPressed() == true && menu == PAUSE_MENU) {
               if(result < 0) {
                    result = 0;
                } else {
                    result--;
                }

            }


            return result;
        }


        void Start() {
            menu = MAIN_MENU;
            obj_Menu_Manager = GameObject.Find("Menu Manager");
            obj_Player = GameObject.Find("Player");
        }


        void Update() {                    
            index = MenuControls_Up(obj_Menu_Manager, menu, index);
            index = MenuControls_Down(obj_Menu_Manager, menu, index);
            enterPressed = MenuControls_Enter(obj_Menu_Manager);
            escapePressed = MenuControls_Escape(obj_Menu_Manager);
        }

    }

}
