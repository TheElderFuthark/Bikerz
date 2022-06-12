/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Player;
using Mobs;
using Graphics;


namespace Mechanics {
    public class HitboxDetection : MonoBehaviour {
        const float TARGET = 0.45f;


        public bool DamageDealt(
            GameObject a,
            GameObject b
        ) { 
            if(a && b) {
                if(Vector2.Distance(
                    a.transform.position, 
                    b.transform.position
                ) <= TARGET
                ) {
                    return true;
                }
            
            }   
            

            return false;        
        }


        void Start() {
        } // Do nothing...


        void Update() {
        } // Do nothing...

    }

}