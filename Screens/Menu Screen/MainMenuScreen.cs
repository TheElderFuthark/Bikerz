/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 09/10/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Graphics;
using Screens;
using Menus;


namespace Screens {
    public class MainMenuScreen : MonoBehaviour {
        public bool Open(
            GameObject obj_Manager,
            GameObject obj_Menus
        ) {
            return obj_Menus.GetComponent<MainMenu>().MainMenuOptions(obj_Manager, obj_Menus);
        }


        void Start() {
        } // Do nothing...


        void Update() {
        } // Do nothing...

    }

}
