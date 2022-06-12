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
    public class DrawSprite : MonoBehaviour {
        public GameObject DrawIt(
            GameObject obj,
            Rigidbody2D body,
            SpriteRenderer render,
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
            // Catch obj
            GameObject objRef = obj;


            // Init sprite
            Texture2D tex = new Texture2D(
                width, 
                height
            );


            // Graphics layer
            Rect rect = new Rect(
                x1, 
                y1, 
                x2, 
                y2
            );
            
            
            // Overall sprite size
            Vector2 size = new Vector2(
                x2, 
                y2
            );


            // Object's sprite
            Sprite sprite = Sprite.Create(
                tex, 
                rect, 
                size
            );        
                

            // Chosen colour
            Color colour = new Color(
                r, 
                g, 
                b, 
                opacity
            );


            // Render population
            render.drawMode = SpriteDrawMode.Sliced;
            render.material.mainTexture = tex;
            render.sprite = sprite;
            render.color = colour;
            render.size = size;


            return objRef; // @Ret: Any changes made, if any
        }
        

        public GameObject ApplySprite(
            GameObject obj
        ) {
            GameObject objRef = obj;


            objRef.AddComponent<Rigidbody2D>();
            objRef.AddComponent<SpriteRenderer>();
            

            objRef.GetComponent<Rigidbody2D>().isKinematic = true;            
            return objRef;
        }


        void Start() {
        }


        void Update() {
        }

    }

}