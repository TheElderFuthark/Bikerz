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
    public class MenuManager : MonoBehaviour {
        const string MAIN_MENU = "Main Menu",
            PAUSE_MENU = "Pause Menu";


        public string menu = "";
        public bool active = false;


        void DisplayPauseMenu() {
            Debug.Log("Pause Menu Active...");
        }


        void DisplayMainMenu() {
            Debug.Log("Main Menu Active...");
        }


        void Start() {
        } // Do nothing...


        void Update() {
            if(active == true) {
                if(menu == MAIN_MENU) {
                    DisplayMainMenu();
                } else if(menu == PAUSE_MENU) {
                    DisplayPauseMenu();
                } else {
                    active = false;
                }

            }

        }

    }

}
