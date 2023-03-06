/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 08/02/2023
*/
using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.EventSystems;


namespace Mobs {
    public class MobsAttacks : MonoBehaviour {
        const float Z = 0.00f,
            AXIS_OFFSET = 4.00f,
            SPEED_ZIGZAG = 0.05f;


        const float EXP_2 = 2.00f;


        public GameObject AttackPlayer_ZigZag(            
            GameObject mob, 
            Vector3 prev,
            Vector3 next,
            float speed,
            bool triggerValue
        ) {
            GameObject mobRef = mob;

            
            mobRef.transform.position = Vector3.Lerp(
                prev, 
                next, 
                SPEED_ZIGZAG);   
            
            
            return mobRef;
        }


        public GameObject AttackPlayer_Normal(
            GameObject mob, 
            GameObject player,
            float x, 
            float y,
            float speed
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
                speed
            );

         
            return mobRef;
        }
        
        
        void Start() {
        }


        void Update() {
        }

    }
    
}