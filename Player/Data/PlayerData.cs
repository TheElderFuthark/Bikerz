/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 24/01/2023
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEngine.SceneManagement;


using Bikerz;
using Menus;
using Levels;
using Graphics;


namespace Player {
    public class PlayerData : MonoBehaviour {
        const string GAME_SCREEN = "Game Screen";


        const string SPRITE_DIRECTORY_PLAYER = "/Content/Sprites/Player/Player",
            SPRITE_DIRECTORY_PLAYER_MOTORCYCLE = "/Content/Sprites/Player/PlayerMotorcycle";


        const string SPRITE_TITLE_PLAYER = "Player",
            SPRITE_TITLE_PLAYER_MOTORCYCLE = "PlayerMotorcycle";


        const string MSG_DEATH_TITLE = "YOU DIED!!!",
            MSG_DEATH_TEXT = "Game Over... ",
            MSG_DEATH_OK = "Restart",
            MSG_DEATH_CANCEL = "Quit";


        const float PLAYER_MAX_HEALTH = 100.00f;


        const int PLAYER_WIDTH = 2,
            PLAYER_HEIGHT = 1,
            MOTORCYCLE_WIDTH = 4,
            MOTORCYCLE_HEIGHT = 1;


        const int EXIT_CODE = 0;


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


        private bool msgResult;


        void DrawSprites(
            GameObject player,
            GameObject motorcycle
        ) {
            GameObject objPlayerRef = player,
                objMotorcycleRef = motorcycle;


            // PLAYER OBJ
            /*objPlayerRef.GetComponent<DisplaySprite>().DisplayObject(
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
            );*/


            objPlayerRef.GetComponent<DisplaySprite>().DisplayObject_Sprite(
                objPlayerRef,
                SPRITE_TITLE_PLAYER,
                SPRITE_DIRECTORY_PLAYER,
                PLAYER_WIDTH,
                PLAYER_HEIGHT,
                objPlayerRef.GetComponent<PlayerData>().x1,
                objPlayerRef.GetComponent<PlayerData>().y1,
                objPlayerRef.GetComponent<PlayerData>().x2,
                objPlayerRef.GetComponent<PlayerData>().y2,
                255.00f, // RED
                0.00f,
                0.00f,
                1.00f,
                100.00f
            );


            // MOTORCYCLE OBJ
            /*objMotorcycleRef.GetComponent<DisplaySprite>().DisplayObject(
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
            );*/


            objMotorcycleRef.GetComponent<DisplaySprite>().DisplayObject_Sprite(
                objMotorcycleRef,
                SPRITE_TITLE_PLAYER_MOTORCYCLE,
                SPRITE_DIRECTORY_PLAYER_MOTORCYCLE,
                MOTORCYCLE_WIDTH,
                MOTORCYCLE_HEIGHT,
                objMotorcycleRef.GetComponent<PlayerMotorcycle>().x1,
                objMotorcycleRef.GetComponent<PlayerMotorcycle>().y1,
                objMotorcycleRef.GetComponent<PlayerMotorcycle>().x2,
                objMotorcycleRef.GetComponent<PlayerMotorcycle>().y2,
                0.00f,
                255.00f, // GREEN
                0.00f,
                1.00f,
                108.00f
            );

        }


        void Start() {
            obj_Player_Ref =
                GameObject.Find("Player");


            obj_Player_Motorcycle_Ref =
                GameObject.Find("Player Motorcycle");


            x2 = 2.00f;
            y2 = 1.00f;


            playerHealth = PLAYER_MAX_HEALTH;


            if (obj_Player_Ref &&
                obj_Player_Motorcycle_Ref
               ) {
                DrawSprites(
                    obj_Player_Ref,
                    obj_Player_Motorcycle_Ref
                );

            }

        }


        void Update() {
            if (playerHealth <= 0.00f ||
                !(GameObject.Find(obj_Player_Ref.name))) {
                msgResult = EditorUtility.DisplayDialog(
                    MSG_DEATH_TITLE,
                    MSG_DEATH_TEXT,
                    MSG_DEATH_OK,
                    MSG_DEATH_CANCEL);


                if (msgResult == true) { // Resets player health & level
                    GameObject.Find("Level Manager").GetComponent<LevelManager>().restart = true;
                    playerHealth = PLAYER_MAX_HEALTH;
                    msgResult = false;
                }

            }

        }
        
    }

}
