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


namespace Graphics {
    public class DisplaySprite : MonoBehaviour {
        public GameObject DisplayObject(
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
            return obj.GetComponent<DrawSprite>().DrawIt(
                obj, 
                obj.GetComponent<Rigidbody2D>(),
                obj.GetComponent<SpriteRenderer>(),
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


        void Start() {
        } // Do nothing...

        
        void Update() {
        } // Do nothing...

    }

}