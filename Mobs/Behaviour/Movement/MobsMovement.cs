/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 09/02/2023
*/
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;


namespace Mobs {
    public class MobsMovement : MonoBehaviour {
        private const float Z = 0.00f,
            TARGET_X = 0.05f,
            TARGET_Y = 0.00f;


        private const float COORD_INC = 4.00f,
            ATTACK_MOB_ZIGZAG_SPEED = 0.02f;


        float x1 = 0.00f, y1 = 0.00f,
            x2 = 0.00f, y2 = 0.00f,
            x3 = 0.00f, y3 = 0.00f,
            x4 = 0.00f, y4 = 0.00f,
            x5 = 0.00f, y5 = 0.00f,
            x6 = 0.00f, y6 = 0.00f, 
            x7 = 0.00f, y7 = 0.00f,
            x8 = 0.00f, y8 = 0.00f,
            x9 = 0.00f, y9 = 0.00f,
            x10 = 0.00f, y10 = 0.00f,
            x11 = 0.00f, y11 = 0.00f,
            x12 = 0.00f, y12 = 0.00f;


        bool set = false;


        public float CheckAxis_Y_ZigZag(
            float y,
            bool triggerValue) {
            if(triggerValue == true) {
                return y - ATTACK_MOB_ZIGZAG_SPEED;
            }


            return y + ATTACK_MOB_ZIGZAG_SPEED;
        }
        
        
        public float CheckAxis_X_ZigZag(
            Vector3 prev,
            Vector3 next) {
            if(next.x >= prev.x) {
                return prev.x + ATTACK_MOB_ZIGZAG_SPEED;
            }


            return prev.x - ATTACK_MOB_ZIGZAG_SPEED;
        }


        public bool CheckCoords_ZigZag(
            Vector3 a, 
            Vector3 b) {
            if (b.x - a.x < TARGET_X && 
                b.y - a.y <= TARGET_Y) {
                return true;
            }


            return false;
        }


        public List<Vector3> GetPoints_ZigZag() {
            if(set == true) {
                return new List<Vector3>() {
                    new Vector3(x1, y1, Z),
                    new Vector3(x2, y2, Z),
                    new Vector3(x3, y3, Z),
                    new Vector3(x4, y4, Z),
                    new Vector3(x5, y5, Z),
                    new Vector3(x6, y6, Z),
                    new Vector3(x7, y7, Z),
                    new Vector3(x8, y8, Z),
                    new Vector3(x9, y9, Z),
                    new Vector3(x10, y10, Z),
                    new Vector3(x11, y11, Z),
                    new Vector3(x12, y12, Z)
                };
                
            }


            return new List<Vector3>();
        }


        void Start() {
            /*  Pre-calculated coordinates,
                dependant on the initial two
                randomly generate initial coords 
                for (x1, y1)...
            */
            x1 = Random.Range(-6, 8); y1 = Random.Range(-4, 6);
            x2 = x1 + COORD_INC; y2 = y1 - COORD_INC;
            x3 = x2 + COORD_INC; y3 = y2 + COORD_INC;
            
            
            x4 = x3 + COORD_INC; y4 = y3 - COORD_INC;
            x5 = x4 + COORD_INC; y5 = y4 + COORD_INC;
            x6 = x5 + COORD_INC; y6 = y5 - COORD_INC;

            
            x7 = x6 - COORD_INC; y7 = y6 + COORD_INC;
            x8 = x7 - COORD_INC; y8 = y7 - COORD_INC;
            x9 = x8 - COORD_INC; y9 = y8 + COORD_INC;


            x10 = x9 - COORD_INC; y10 = y9 - COORD_INC;
            x11 = x10 - COORD_INC; y11 = y10 + COORD_INC;
            x12 = x11 - COORD_INC; y12 = y11 - COORD_INC;


            set = true;
        }
        
        
        void Update() {
        }

    }
    
}