/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 09/10/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using Bikerz;


namespace Menus {
    public class MainMenu : MonoBehaviour {
        const string MAIN_MENU = "Main Menu",
            GAME_SCREEN = "Test Area";


        public bool MainMenuOptions(
            GameObject obj_Manager,
            GameObject obj_Menus
        ) {
            if(obj_Menus.GetComponent<MenuManager>().escapePressed == true) {
                if(obj_Menus.GetComponent<MenuManager>().active == true) {
                    obj_Menus.GetComponent<MenuManager>().active = false;
                    return false;
                } else {
                    obj_Menus.GetComponent<MenuManager>().active = true;
                    obj_Menus.GetComponent<MenuManager>().menu = MAIN_MENU;
                    obj_Manager.GetComponent<GameManager>().screen = MAIN_MENU;
                }


                obj_Menus.GetComponent<MenuManager>().escapePressed = false;
            } else if(obj_Menus.GetComponent<MenuManager>().active == true &&
                obj_Menus.GetComponent<MenuManager>().enterPressed == true
            ) {
                obj_Menus.GetComponent<MenuManager>().Menu_OptionEvent(
                    obj_Menus,
                    obj_Menus.GetComponent<MenuManager>().OptionSelected(
                        obj_Menus.GetComponent<MenuManager>().options_main,
                        obj_Menus.GetComponent<MenuManager>().index
                    )

                );


                obj_Menus.GetComponent<MenuManager>().enterPressed = false;
            }


            return true;
        }


        void Start() {
        } // Do nothing...


        void Update() {
        } // Do nothing...

    }

}
