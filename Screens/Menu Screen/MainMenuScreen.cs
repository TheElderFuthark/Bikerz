/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Graphics;


namespace Screens {
    public class MainMenuScreen : MonoBehaviour {
        const string MAIN_MENU = "Main Menu";


        public bool Close() {
            Destroy(GameObject.Find(MAIN_MENU));
            return true;
        }


        public bool Open(
            GameObject obj
        ) {
            GameObject objRef = obj;
            objRef.name = "Main Menu Screen";
            
            
            objRef.AddComponent<DisplaySprite>();
            objRef.AddComponent<DrawSprite>();
            
            
            if(objRef == GameObject.Find(objRef.name)) {
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