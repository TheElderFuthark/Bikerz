/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Menus {
    public class PauseMenu : MonoBehaviour {
        const string PAUSE_MENU = "Pause Menu",
            GAME_SCREEN = "Test Area";


        const string DEBUG_ERROR = "ERROR: Could not load/exit Pause Menu...";


        public bool ClosePauseMenu(
            GameObject obj
        ) {
            GameObject objRef = obj;
            try{
                SceneManager.LoadScene(GAME_SCREEN);
                objRef.GetComponent<MenuManager>().menu = "";
                objRef.GetComponent<MenuManager>().active = false;


                return true;
            } catch {
            } // Do nothing...


            return false;
        }


        public bool StartPauseMenu(
            GameObject obj
        ) {
            GameObject objRef = obj;


            try {
                SceneManager.LoadScene(PAUSE_MENU);
                objRef.GetComponent<MenuManager>().menu = PAUSE_MENU;
                objRef.GetComponent<MenuManager>().active = true;


                return true;
            } catch {
            } // Do nothing...


            return false;
        }


        void Start() {
        } // Do nothing...


        void Update() {
        } // Do nothing...

    }

}
