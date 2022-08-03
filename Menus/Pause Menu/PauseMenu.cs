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


        public bool ClosePauseMenu(
            GameObject obj
        ) {
            GameObject objRef = obj;


            if(objRef.GetComponent<MenuManager>().enterPressed == true) {
                SceneManager.LoadScene(GAME_SCREEN);
                objRef.GetComponent<MenuManager>().menu = GAME_SCREEN;
                objRef.GetComponent<MenuManager>().active = false;


                return false;
            }


            return true;
        }


        public bool StartPauseMenu(
            GameObject obj
        ) {
            GameObject objRef = obj;


            if(objRef.GetComponent<MenuManager>().enterPressed == false) {
                SceneManager.LoadScene(PAUSE_MENU);
                objRef.GetComponent<MenuManager>().menu = PAUSE_MENU;
                objRef.GetComponent<MenuManager>().active = true;


                return true;
            }


            return false;
        }


        void Start() {
        } // Do nothing...


        void Update() {
        } // Do nothing...

    }

}
