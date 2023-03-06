/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using Bikerz;


namespace Menus {
    public class PauseMenu : MonoBehaviour {
        const string PAUSE_MENU = "Pause Menu",
            GAME_SCREEN = "Test Area";


        public bool PauseMenuOptions(
            GameObject obj_Manager,
            GameObject obj_Menus
        ) {
            if(obj_Menus.GetComponent<MenuManager>().escapePressed == true) {
                if(obj_Menus.GetComponent<MenuManager>().active == true) {
                    obj_Menus.GetComponent<MenuManager>().active = false;
                    return false;
                } else {
                    obj_Menus.GetComponent<MenuManager>().active = true;
                    obj_Menus.GetComponent<MenuManager>().menu = PAUSE_MENU;
                    obj_Manager.GetComponent<GameManager>().screen = PAUSE_MENU;
                }


                obj_Menus.GetComponent<MenuManager>().escapePressed = false;
            } else if(obj_Menus.GetComponent<MenuManager>().active == true &&
                obj_Menus.GetComponent<MenuManager>().enterPressed == true
            ) {
                obj_Menus.GetComponent<MenuManager>().Menu_OptionEvent(
                    obj_Menus,
                    obj_Menus.GetComponent<MenuManager>().OptionSelected(
                        obj_Menus.GetComponent<MenuManager>().options_pause,
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
