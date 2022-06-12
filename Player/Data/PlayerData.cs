/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;


using Graphics;


namespace Player {
    public class PlayerData : MonoBehaviour {
        const string DIALOG_TITLE = "YOU DIED",
            DIALOG_MSG = "Game Over",
            DIALOG_OK = "Restart",
            DIALOG_CANCEL = "Exit"; 


        const int PLAYER_WIDTH = 2,
            PLAYER_HEIGHT = 1,
            MOTORCYCLE_WIDTH = 4,
            MOTORCYCLE_HEIGHT = 1;


        GameObject obj_Player_Ref,
            obj_Player_Motorcycle_Ref;


        public int gridSnap_y = 0;
        public float x1, 
            y1, 
            x2, 
            y2;


        public string key;
        public bool firePressed = false;


        public float playerHealth;


        void DrawSprites(
            GameObject player, 
            GameObject motorcycle
        ) {
            GameObject objPlayerRef = player,
                objMotorcycleRef = motorcycle;


            // PLAYER OBJ
            objPlayerRef.GetComponent<DisplaySprite>().DisplayObject(
                objPlayerRef,
                PLAYER_WIDTH, 
                PLAYER_HEIGHT, 
                objPlayerRef.GetComponent<PlayerData>().x1, 
                objPlayerRef.GetComponent<PlayerData>().y1, 
                objPlayerRef.GetComponent<PlayerData>().x2, 
                objPlayerRef.GetComponent<PlayerData>().y2, 
                255.00f, // RED
                0.00f, 
                0.00f, 
                1.00f
            );


            // MOTORCYCLE OBJ
            objMotorcycleRef.GetComponent<DisplaySprite>().DisplayObject(
                objMotorcycleRef, 
                MOTORCYCLE_WIDTH, 
                MOTORCYCLE_HEIGHT, 
                objMotorcycleRef.GetComponent<PlayerMotorcycle>().x1, 
                objMotorcycleRef.GetComponent<PlayerMotorcycle>().y1, 
                objMotorcycleRef.GetComponent<PlayerMotorcycle>().x2, 
                objMotorcycleRef.GetComponent<PlayerMotorcycle>().y2, 
                0.00f, 
                255.00f, // GREEN
                0.00f, 
                1.00f
            );

        }


        void Start() {
            obj_Player_Ref = 
                GameObject.Find("Player");
            
            
            obj_Player_Motorcycle_Ref = 
                GameObject.Find("Player Motorcycle");


            x2 = 2.00f;     
            y2 = 1.00f;


            playerHealth = 100.00f;


            if(obj_Player_Ref && 
                obj_Player_Motorcycle_Ref
            ) {
                DrawSprites(
                    obj_Player_Ref,
                    obj_Player_Motorcycle_Ref
                );

            }

        } 
        

        void Update() {
            if(playerHealth <= 0.00f) {
                EditorUtility.DisplayDialog(
                    DIALOG_TITLE,
                    DIALOG_MSG,
                    DIALOG_OK,
                    DIALOG_CANCEL
                );


                Destroy(obj_Player_Motorcycle_Ref);
                Destroy(obj_Player_Ref);


                /*Time.timeScale = 0.00f;
                if(Time.timeScale == 4.00f) {
                    Application.LoadLevel(Application.loadedLevel);
                }*/

            }

        }

    }

}
