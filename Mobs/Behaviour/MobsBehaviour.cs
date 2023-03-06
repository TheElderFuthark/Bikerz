/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 08/02/2023
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Mechanics;
using Player;
using Graphics;
using UnityEditor.U2D.Path;
using UnityEngine.UIElements;


namespace Mobs {
    public class MobsBehaviour : MonoBehaviour
    {
        const float Z = 0.00f,
            AXIS_OFFSET = 4.00f;


        const int ATTACK_NORMAL = 0,
            ATTACK_ZIGZAG = 1,
            ATTACK_MIN = 0,
            ATTACK_MAX = 2;


        private const float ATTACK_MOB_DMG = 0.05f,
            ATTACK_MOB_ZIGZAG_SPEED = 0.02f;


        public float x1,
            y1,
            x2,
            y2;


        public int count = 0,
            attackSelect = -1;

        public Vector3 previousPosition = new Vector3(),
            nextPosition = new Vector3();


        public int point = 1;
        public bool damaged = false,
            checkCoordsResult = false,
            triggerValue = false;


        List<Vector3> points_ZigZag = new List<Vector3> { };


        GameObject obj_Player_Ref,
            obj_Mobs,
            obj_Mobs_Copy;
        
        
        GameObject AttackPlayer_ZigZag_Calculate(
            GameObject objMobs,
            Vector3 prev,
            Vector3 next,
            float result,
            List<Vector3> points,
            int p,
            bool coordRes,
            float y,
            bool trigger
        ) {
            GameObject objMobsRef = objMobs;


            int __p = p;
            bool __trigger = trigger;


            Vector3 __prev = prev,
                __next = next;


            bool __coordResult = coordRes;


            if(__coordResult == true && __p < points.Count && __next != points[points.Count - 1]) {
                __trigger = false;
            } else if (__coordResult == true && __p > 0 && __next != points[0]) {
                __trigger = true;
            }


            if(__trigger == true) {
                __p--;
                __prev = __next;
                __next = points[__p];
            } else {
                __p++;
                __prev = __next;
                __next = points[__p];
                
                
                __next = new Vector3(
                    __prev.x + (__next.x - __prev.x), 
                    __prev.y + (__next.y - __prev.y), 
                    Z);
            }


            objMobsRef.GetComponent<MobsBehaviour>().point = __p;
            objMobsRef.GetComponent<MobsBehaviour>().checkCoordsResult = __coordResult;
            objMobsRef.GetComponent<MobsBehaviour>().triggerValue = __trigger;
            objMobsRef.GetComponent<MobsBehaviour>().previousPosition = __prev;
            objMobsRef.GetComponent<MobsBehaviour>().nextPosition = __next;


            return objMobsRef;
        }


        bool AttackPlayer_ZigZag_CheckCoords(
            GameObject objMobs,
            Vector3 prev,
            Vector3 next
            )
        {
            GameObject objMobsRef = objMobs;
            
            
            if(objMobsRef.GetComponent<MobsMovement>().CheckCoords_ZigZag(prev, next) == true) {
                return true;
            }


            return false;
        }

        GameObject AttackPlayer_Normal(
            GameObject objMobs,
            GameObject objPlayer,
            float x,
            float y,
            float result) {
            return obj_Mobs
                .GetComponent<MobsAttacks>()
                .AttackPlayer_Normal(
                    objMobs, 
                    objPlayer,
                    x,
                    y, 
                    result
            );
            
        }


        bool CheckDamage(
            GameObject objMobs,
            GameObject objPlayer) {
            GameObject objMobRef = objMobs,
                objPlayerRef = objPlayer;


            if(obj_Mobs.GetComponent<HitboxDetection>().DamageDealt(
                    objMobRef,
                    objPlayerRef)
               ) {
                return true;
            }


            return false;
        }


        float GetCurrentPosition_y(
            GameObject obj) {
            return obj.transform.position.y;
        }


        float GetCurrentPosition_x(
            GameObject obj) {
            return obj.transform.position.x;
        }
        
        
        void Start() {
            obj_Mobs = GameObject.Find("Mobs " + count);
            obj_Player_Ref = GameObject.Find("Player");


            obj_Mobs.GetComponent<Hitbox>().obj_Ref = obj_Mobs;


            x2 = obj_Mobs.GetComponent<Hitbox>().x2 = 3.00f;
            y2 = obj_Mobs.GetComponent<Hitbox>().y2 = 1.00f;
            
            
            // Randomises attack type/s
            //attackSelect = Random.Range(ATTACK_MIN, ATTACK_MAX);
            attackSelect = 0; // Test value
            

            if(attackSelect == ATTACK_ZIGZAG) {
                points_ZigZag = obj_Mobs
                    .GetComponent<MobsMovement>()
                    .GetPoints_ZigZag();


                /*  i = 1, pos for first
                    index = i - 1, second = i...
                */
                previousPosition = points_ZigZag[point - 1];
                obj_Mobs.transform.position = previousPosition;
                nextPosition = points_ZigZag[point]; 
            }
            
        }


        void Update() {
            if(obj_Mobs == GameObject.Find(obj_Mobs.name)) {
                x1 = GetCurrentPosition_x(obj_Mobs);
                y1 = GetCurrentPosition_y(obj_Mobs);
                
                
                previousPosition = new Vector3(x1, y1, Z);
                damaged = CheckDamage(obj_Mobs, obj_Player_Ref);
                
                
                if(damaged == true) {
                    obj_Player_Ref.GetComponent<PlayerData>().playerHealth -= ATTACK_MOB_DMG;
                    damaged = false;
                }


                /*  AI Movement & Behaviour
                */
                if(attackSelect == ATTACK_NORMAL) { // Normal attack - using built-in method "Vector3.Lerp", moving the displacement,
                    obj_Mobs = AttackPlayer_Normal(
                        obj_Mobs, 
                        obj_Player_Ref, 
                        x1, 
                        y1, 
                        GameObject.Find("Level Actions").GetComponent<MobsDifficulty>().result);
                } else if(attackSelect == ATTACK_ZIGZAG) { // Zig zag - moves along a pre-calculated diagonal path, moving left and right,  
                    /*  TODO:
                        =====================================================
                        Make the mob go from one vector to another,
                        following the pre-calculated path, right, then left,
                        repeating the same pattern.
                        =====================================================
                    */


                    // Checks if mob is at current target vector,
                    checkCoordsResult = AttackPlayer_ZigZag_CheckCoords(
                        obj_Mobs, 
                        previousPosition, 
                        nextPosition);

                    
                    // Estimates movement val/s,
                    obj_Mobs = AttackPlayer_ZigZag_Calculate(
                        obj_Mobs,
                        previousPosition,
                        nextPosition,
                        GameObject.Find("Level Actions").GetComponent<MobsDifficulty>().result,
                        points_ZigZag,
                        point,
                        checkCoordsResult,
                        y1,
                        triggerValue);


                    // Re-assign value/s from referenced obj,
                    point = obj_Mobs.GetComponent<MobsBehaviour>().point; 
                    checkCoordsResult = obj_Mobs.GetComponent<MobsBehaviour>().checkCoordsResult;
                    triggerValue = obj_Mobs.GetComponent<MobsBehaviour>().triggerValue;
                    previousPosition = obj_Mobs.GetComponent<MobsBehaviour>().previousPosition;
                    nextPosition = obj_Mobs.GetComponent<MobsBehaviour>().nextPosition;
                    
                    
                    // Attack...
                    obj_Mobs = obj_Mobs.GetComponent<MobsAttacks>()
                        .AttackPlayer_ZigZag(
                            obj_Mobs,
                            previousPosition,
                            nextPosition,
                            GameObject.Find("Level Actions").GetComponent<MobsDifficulty>().result,
                            triggerValue);
                }
                    
            }
                
        }
            
    }
    
}