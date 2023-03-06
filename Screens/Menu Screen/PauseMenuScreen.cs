/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Graphics;
using Screens;
using Menus;


namespace Screens {
    public class PauseMenuScreen : MonoBehaviour {
        public bool Open(
            GameObject obj_Manager,
            GameObject obj_Menus
        ) {
            return obj_Menus.GetComponent<PauseMenu>().PauseMenuOptions(obj_Manager, obj_Menus);
        }


        void Start() {
        } // Do nothing...


        void Update() {
        } // Do nothing...

    }

}
