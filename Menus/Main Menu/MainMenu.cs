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
        const string MAIN_MENU = "Main Menu";
        const string GAME_SCREEN = "Test Area";
        const string DEBUG_ERROR = "ERROR! Could not load/exit main menu screen...";


        public bool CloseMainMenu(
            GameObject obj
        ) {
            GameObject objRef = obj;


            try {
                objRef.GetComponent<MenuManager>().menu = "";
                objRef.GetComponent<MenuManager>().active = false;


                return true;
            } catch {
            } // Do nothing...


            return false;
        }


        public bool StartMainMenu(
            GameObject obj
        ) {
            GameObject objRef = obj;


            try {
                SceneManager.LoadScene(MAIN_MENU);
                objRef.GetComponent<MenuManager>().menu = MAIN_MENU;
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
