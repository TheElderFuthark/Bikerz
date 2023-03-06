/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Graphics;


namespace Player {
    public class PlayerHUD : MonoBehaviour {
        const string GAME_OBJECT_HUD = "Player HUD",
            GAME_OBJECT_HEALTH = "Health",
            GAME_OBJECT_PLAYER = "Player",
            GAME_OBJECT_UI = "Player UI";


        const float HEALTH_Y = 1.00f,
            HUD_RED = 0.00f,
            HUD_GREEN = 255.00f,
            HUD_BLUE = 0.00f,
            HUD_OPACITY = 1.00f,
            
            
            HEALTH_RED = 1.00f,
            HEALTH_GREEN = 0.00f,
            HEALTH_BLUE = 0.00f,
            HEALTH_OPACITY = 1.00f;


        GameObject obj_HUD,
            obj_Health;


        void HUD_Update(
            GameObject obj,
            int width,
            int height,
            float x1, 
            float y1,
            float x2,
            float y2,
            float r,
            float g,
            float b,
            float opacity
        ) {
            obj.GetComponent<DisplaySprite>().DisplayObject(
                obj,
                width,
                height,
                x1, 
                y1,
                x2,
                y2,
                r,
                g, 
                b,
                opacity
            );
        
        }


        GameObject HUD_CreateHealthBar(GameObject obj) {
            GameObject objRef = obj;
            objRef.name = GAME_OBJECT_HEALTH;
            
            
            objRef.AddComponent<Hitbox>();
            objRef.AddComponent<DisplaySprite>();
            objRef.AddComponent<DrawSprite>();


            objRef.GetComponent<Hitbox>().obj_Ref = objRef;


            objRef.GetComponent<Hitbox>().x1 = 6.00f;
            objRef.GetComponent<Hitbox>().y1 = HEALTH_Y;


            objRef.GetComponent<Hitbox>().x2 = 
                GameObject.Find(GAME_OBJECT_PLAYER).GetComponent<PlayerData>().playerHealth;
            
            
            objRef.GetComponent<Hitbox>().y1 = HEALTH_Y;


            objRef.transform.position = new Vector3(
                 objRef.GetComponent<Hitbox>().x1,  
                 objRef.GetComponent<Hitbox>().y1, 
                 1.00f
            );

            objRef = objRef.GetComponent<DrawSprite>().ApplySprite(objRef);
            objRef.transform.parent = GameObject.Find(GAME_OBJECT_HUD).transform;


            return objRef;
        }


        GameObject HUD_CreateHUD(GameObject obj) {
            GameObject objRef = obj;
            objRef.name = GAME_OBJECT_HUD;
            
            
            objRef.AddComponent<Hitbox>();
            objRef.AddComponent<DisplaySprite>();
            objRef.AddComponent<DrawSprite>();


            objRef.GetComponent<Hitbox>().obj_Ref = objRef;


            objRef.GetComponent<Hitbox>().x1 = 6.00f;
            objRef.GetComponent<Hitbox>().y1 = 6.00f;


            objRef.GetComponent<Hitbox>().x2 = 6.00f;
            objRef.GetComponent<Hitbox>().y2 = 2.00f;


            objRef.transform.position = new Vector3(
                 objRef.GetComponent<Hitbox>().x1,  
                 objRef.GetComponent<Hitbox>().y1, 
                 0.00f
            );


            objRef = objRef.GetComponent<DrawSprite>().ApplySprite(objRef);
            objRef.transform.parent = GameObject.Find(GAME_OBJECT_UI).transform;


            return objRef;
        }


        void Start() {  
            if(!(GameObject.Find(GAME_OBJECT_HUD))) {       
                obj_HUD = HUD_CreateHUD(new GameObject());
            } else {
                obj_HUD = GameObject.Find(GAME_OBJECT_HUD);
            }
            

            if(!(GameObject.Find(GAME_OBJECT_HEALTH))) {
                obj_Health = HUD_CreateHealthBar(new GameObject());
            } else {
                obj_Health = GameObject.Find(GAME_OBJECT_HEALTH);
            }

        }


        void Update() {
            /* TODO
            ====================================================
            
            HUD_Update(
                obj_HUD,
                (int) obj_HUD.GetComponent<Hitbox>().x2,
                (int) obj_HUD.GetComponent<Hitbox>().y2,
                obj_HUD.GetComponent<Hitbox>().x1,
                obj_HUD.GetComponent<Hitbox>().y1,
                obj_HUD.GetComponent<Hitbox>().x2,
                obj_HUD.GetComponent<Hitbox>().y2,
                HUD_RED,
                HUD_GREEN,
                HUD_BLUE,
                HUD_OPACITY
            ); 
                

            HUD_Update(
                obj_Health,
                (int) obj_Health.GetComponent<Hitbox>().x2,
                (int) obj_Health.GetComponent<Hitbox>().y2,
                obj_Health.GetComponent<Hitbox>().x1,
                obj_Health.GetComponent<Hitbox>().y1,
                obj_Health.GetComponent<Hitbox>().x2,
                obj_Health.GetComponent<Hitbox>().y2,
                HEALTH_RED,
                HEALTH_GREEN,
                HEALTH_BLUE,
                HEALTH_OPACITY
            );

            ====================================================
            */


        }

    }

}