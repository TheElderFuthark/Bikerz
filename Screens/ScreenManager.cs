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
                    return menu.GetComponent<MainMenuScreen>().Open(manager, menu);
                case PAUSE_MENU:
                    return menu.GetComponent<PauseMenuScreen>().Open(manager, menu);
                case GAME_SCREEN:
                    return gameScreen.GetComponent<GameScreen>().Run(manager);
                default:
                    break;
            }


            return true;
        }


        void Start() {
        } // Do nothing...


        void Update() {
        } // Do nothing...

    }

}
