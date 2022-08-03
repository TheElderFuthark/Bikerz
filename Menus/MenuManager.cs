/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
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
        public static List <string> options_main = new List <string> {
            MAIN_NEW_GAME,
            MAIN_LAST_LEVEL,
            MAIN_LEVEL_MENU,
            MAIN_OPTIONS_MENU,
            MAIN_CREDITS_SCREEN,
            MAIN_EXIT_GAME
        };


        // Var list/array input of ALL consts related to the pause menu
        public static List <string> options_pause = new List<string> {
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
            enterPressed = false,
            credits = false,
            loadOptionsMenu = false,
            loadLevelMenu = false,
            loadLastSave = false,
            saveGame = false,
            newGame = false;


        int index = 0;


        GameObject obj_Menu_Actions;


        void Menu_OptionEvent(
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
                    menuActions.GetComponent<MenuActions>().ExitToMainMenu();
                    break;
                default:
                    break;
            }

        }


        string OptionSelected(
            List<string> options,
            int index
        ) {
            return options[index];
        }


        void DisplayMenu() {
            /*  1) Draw Sprites
                2) Scale menus
                3) update menu option selected, and
                other UI features/animations
            */
        }


        void Start() {
            obj_Menu_Actions = GameObject.Find("Menu Manager");
        }


        void Update() {
            if(GameObject.Find("Player").GetComponent<PlayerControls>().Menu_EnterPressed() == true) {
                enterPressed = true;
            }


            if(enterPressed == true) {
                active = true;
                enterPressed = false;
            }


            if(active == true) {
                if(menu == MAIN_MENU) {
                    menuOption = OptionSelected(options_main, index);
                } else if(menu == PAUSE_MENU) {
                    menuOption = OptionSelected(options_pause, index);
                }


                if(GameObject.Find("Player").GetComponent<PlayerControls>().Menu_EnterPressed() == true) {
                    Menu_OptionEvent(
                        obj_Menu_Actions,
                        menuOption
                    );


                    DisplayMenu();
                }
            }

        }

    }

}
