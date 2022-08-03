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
    public class MainMenu : MonoBehaviour {
        const string MAIN_MENU = "Main Menu",
            GAME_SCREEN = "Test Area";


        public bool CloseMainMenu(
            GameObject obj
        ) {
            GameObject objRef = obj;


            if(objRef.GetComponent<MenuManager>().enterPressed == true) {
                objRef.GetComponent<MenuManager>().menu = GAME_SCREEN;
                objRef.GetComponent<MenuManager>().active = false;


                return false;
            }


            return true;
        }


        public bool StartMainMenu(
            GameObject obj
        ) {
            GameObject objRef = obj;


            if(objRef.GetComponent<MenuManager>().enterPressed == false) {
                SceneManager.LoadScene(MAIN_MENU);
                objRef.GetComponent<MenuManager>().menu = MAIN_MENU;
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
