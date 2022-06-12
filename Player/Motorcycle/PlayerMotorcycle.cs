/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player {
    public class PlayerMotorcycle : MonoBehaviour {
        public float x1,
            y1,
            x2 = 4.00f,
            y2 = 1.00f;


        GameObject obj_Player_Ref,
            obj_Player_Motorcycle;


        void Start() {
            obj_Player_Ref = GameObject.Find("Player");
            obj_Player_Motorcycle = GameObject.Find("Player Motorcycle");
        }


        void Update() {
            if(obj_Player_Ref && 
                obj_Player_Motorcycle
            ) {
                x1 = obj_Player_Ref.transform.position.x;
                y1 = obj_Player_Ref.transform.position.y;
            }

        }

    }

}