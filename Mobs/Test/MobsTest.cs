/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Mechanics;
using Player;
using Graphics;


namespace Mobs {
    public class MobsTest : MonoBehaviour {
        const float MOB_SPEED = 0.0025f,
            Z = 0.00f,
            AXIS_OFFSET = 4.00f;


        public float x1, 
            y1, 
            x2,
            y2;


        public int count = 0;

        
        GameObject obj_Player_Ref,
            obj_Mobs,
            obj_Mobs_Copy;


        GameObject AttackPlayer_New(
            GameObject mob,
            GameObject player,
            float x,
            float y
        ) {
            GameObject playerRef = player,
                mobRef = mob;


            mobRef.transform.position = new Vector3(
                mobRef.GetComponent<Hitbox>().x1 = x,
                mobRef.GetComponent<Hitbox>().y1 = y,
                Z
            );


            return mobRef;
        }


        GameObject AttackPlayer(
            GameObject mob, 
            GameObject player,
            float x, 
            float y
        ) {
            GameObject playerRef = player,
                mobRef = mob;
                             

            /* Move towards player... */
            mobRef.transform.position = Vector3.Lerp(
                new Vector3(
                    x,
                    y,
                    Z
                ),
                new Vector3(
                    playerRef.transform.position.x + AXIS_OFFSET,
                    playerRef.transform.position.y,
                    Z
                ),
                MOB_SPEED
            );

         
            return mobRef;
        }


        float GetCurrentPosition_y(
            GameObject obj
        ) {
            return obj.transform.position.y;
        }


        float GetCurrentPosition_x(
            GameObject obj
        ) {
            return obj.transform.position.x;
        }
        
        
        void Start() {
            obj_Mobs = GameObject.Find("Mobs " + count);
            obj_Player_Ref = GameObject.Find("Player");


            obj_Mobs.GetComponent<Hitbox>().obj_Ref = obj_Mobs;


            x2 = obj_Mobs.GetComponent<Hitbox>().x2 = 3.00f;
            y2 = obj_Mobs.GetComponent<Hitbox>().y2 = 1.00f;
        }


        void Update() {
            if(obj_Mobs) {
                x1 = GetCurrentPosition_x(obj_Mobs);
                y1 = GetCurrentPosition_y(obj_Mobs);
            

                if(obj_Mobs.GetComponent<HitboxDetection>().DamageDealt(
                    obj_Mobs, 
                    obj_Player_Ref
                )) {
                    obj_Player_Ref.GetComponent<PlayerData>().playerHealth -= 50.00f;
                }

            
                // AI Movement & Behaviour
                obj_Mobs = AttackPlayer(
                    obj_Mobs, 
                    obj_Player_Ref,
                    x1,
                    y1
                );
                
            }
            
        }
            
    }
    
}
