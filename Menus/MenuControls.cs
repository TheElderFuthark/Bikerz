/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 08/10/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Menus {
    public class MenuControls : MonoBehaviour {
        public bool DownPressed() {
            if(Input.GetKeyDown("down")) {
                return true;
            }


            return false;
        }


        public bool UpPressed() {
            if(Input.GetKeyDown("up")) {
                return true;
            }


            return false;
        }

        
        public bool EnterPressed() {
            if(Input.GetKey("enter")) {
                return true;
            }


            return false;
        }


        public bool EscapePressed() {
            if(Input.GetKey("escape")) {
                return true;
            }


            return false;
        }


        void Start() {
        }


        void Update() {
            
        }

    }

}