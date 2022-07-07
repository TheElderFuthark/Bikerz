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
                    return gameScreen.GetComponent<MainMenuScreen>().Open(menu);
                case PAUSE_MENU:
                    return gameScreen.GetComponent<PauseMenuScreen>().Open(menu);
                case GAME_SCREEN:
                    return gameScreen.GetComponent<GameScreen>().Run();
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
