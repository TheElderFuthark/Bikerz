using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Menus;


namespace Screens {
    public class ScreenManager : MonoBehaviour {
        const string MAIN_MENU = "Main Menu Screen",
            PAUSE_MENU = "Pause Menu Screen",
            GAME_SCREEN = "Test Area";


        public bool SelectScreen(
            GameObject menu,
            GameObject gameScreen,
            string select
        ) {
            switch(select) {
                case MAIN_MENU:
                    menu.GetComponent<MenuManager>().MainMenuManager(menu); 
                    return false;
                case PAUSE_MENU:
                    menu.GetComponent<MenuManager>().PauseMenuManager(menu); 
                    return false;
                case GAME_SCREEN:
                    gameScreen.GetComponent<GameScreen>().Run();
                    return true;
                default:
                    break;
            }
            

            return false;
        }


        void Start() {    
        } // Do nothing...

        
        void Update() {
        } // Do nothing...
    
    }

}