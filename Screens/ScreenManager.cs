/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Menus;


namespace Screens {
    public class ScreenManager : MonoBehaviour {
        const string MAIN_MENU = "Main Menu",
            PAUSE_MENU = "Pause Menu",
            GAME_SCREEN = "Test Area";


        public bool SelectScreen(
            GameObject manager,
            GameObject menu,
            GameObject gameScreen,
            string select
        ) {
            switch(select) {
                case MAIN_MENU:
                    if(gameScreen.GetComponent<MainMenuScreen>().Open(menu) == false) {
                        return gameScreen.GetComponent<MainMenuScreen>().Close(menu);
                    }


                    return true;
                case PAUSE_MENU:
                    if(gameScreen.GetComponent<PauseMenuScreen>().Open(menu) == false) {
                        return gameScreen.GetComponent<PauseMenuScreen>().Close(menu);
                    }


                    return true;
                case GAME_SCREEN:
                    return gameScreen.GetComponent<GameScreen>().Run(manager);
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
