/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Graphics;


namespace Mobs {
    public class MobsData : MonoBehaviour {
        const int MOB_WIDTH = 3,
            MOB_HEIGHT = 1;


        GameObject obj_Mobs_Ref;


        void DrawSprite(
            GameObject mob
        ) {
            GameObject mobRef = mob;


            // MOBS SPAWNER OBJ
            mobRef.GetComponent<DisplaySprite>().DisplayObject(
                mobRef, 
                MOB_WIDTH,
                MOB_HEIGHT,
                mobRef.GetComponent<Hitbox>().x1, 
                mobRef.GetComponent<Hitbox>().y1, 
                mobRef.GetComponent<Hitbox>().x2, 
                mobRef.GetComponent<Hitbox>().y2, 
                0.00f, 
                0.00f, 
                255.00f, // BLUE
                1.00f
            );

        }


        void Start() {
            obj_Mobs_Ref = 
                GameObject.Find("Mobs");
        }

        
        void Update() {
            if(obj_Mobs_Ref) {
                DrawSprite(obj_Mobs_Ref);
            }

        }

    }

}