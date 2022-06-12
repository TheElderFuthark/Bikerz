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
    public class PlayerProjectile : MonoBehaviour {    
        const int WIDTH = 1, 
            HEIGHT = 1;    
        
        
        public float x1, 
            y1,
            x2,
            y2;
        

        GameObject obj_Player_Ref,
            obj_Player_Projectile_Ref,
            obj_Player_Projectiles_Ref;


        void Start() {
            /* INIT */
            obj_Player_Ref =
                GameObject.Find("Player");
            
            
            obj_Player_Projectiles_Ref = 
                GameObject.Find("Player Projectiles");

            
            obj_Player_Projectile_Ref = 
                GameObject.Find("Player Projectile " + (
                    obj_Player_Projectiles_Ref
                    .GetComponent<PlayerProjectiles>()
                    .iteration - 1
                ));


            x2 = 1.00f;     
            y2 = 1.00f;
        }

        
        void Update() {            
            if(obj_Player_Projectile_Ref) {
                x1 = obj_Player_Projectile_Ref.GetComponent<Hitbox>().x1;
                y1 = obj_Player_Projectile_Ref.GetComponent<Hitbox>().y1;


                obj_Player_Projectile_Ref.GetComponent<DisplaySprite>().DisplayObject(
                    obj_Player_Projectile_Ref,
                    WIDTH,
                    HEIGHT,
                    x1,
                    y1,
                    x2,
                    y2,
                    0.00f,
                    255.00f,
                    0.00f,
                    1.00f
                );
                                
            }

        }

    }

}