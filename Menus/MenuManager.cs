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
        public void MainMenuManager(GameObject obj) {
            GameObject objRef = obj;
            objRef.GetComponent<MainMenu>().StartMainMenuScreen();
        }


        public void PauseMenuManager(GameObject obj) {
            GameObject objRef = obj;
            objRef.GetComponent<PauseMenu>().StartPauseMenuScreen();
        }


        void Start() {
        } // Do nothing...


        void Update() {
        } // Do nothing...

    }

}