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
        public bool Close(
            GameObject obj
        ) {
            return obj.GetComponent<PauseMenu>().ClosePauseMenu(obj);
        }


        public bool Open(
            GameObject obj
        ) {
            return obj.GetComponent<PauseMenu>().StartPauseMenu(obj);
        }


        void Start() {
        }


        void Update() {
        }

    }

}
