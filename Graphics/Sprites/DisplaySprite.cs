/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 24/01/2023
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Player;
using Mobs;


namespace Graphics {
    public class DisplaySprite : MonoBehaviour {
        public GameObject DisplayObject_Sprite(
            GameObject obj,
            string title,
            string sprite,
            int width,
            int height,
            float x1, 
            float y1, 
            float x2, 
            float y2,
            float r,
            float g,
            float b,
            float opacity,
            float quality
        ) {
            if(obj) {
                try {
                    return obj.GetComponent<DrawSprite>().DrawIt_Sprite(
                        obj, 
                        obj.GetComponent<Rigidbody2D>(),
                        obj.GetComponent<SpriteRenderer>(),
                        title,
                        sprite,
                        width, 
                        height, 
                        x1, 
                        y1, 
                        x2, 
                        y2, 
                        r,
                        g, 
                        b, 
                        opacity,
                        quality
                    );
                } catch(System.Exception e) {
                    Debug.Log(e);
                }

            }


            return obj;
        }


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
            if(obj) {
                try {
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
                } catch(System.Exception e) {
                    Debug.Log(e);
                }

            }


            return obj;
        }


        void Start() {
        } // Do nothing...

        
        void Update() {
        } // Do nothing...

    }

}