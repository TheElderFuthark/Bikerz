/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 24/01/2023
*/
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


using Player;
using Mobs;


namespace Graphics {
    /*  TODO

        ================================================

        The sprite does not select the image
        correctly, in method "DrawIt_Sprite".

        ================================================
    */
    public class DrawSprite : MonoBehaviour {
        const string FILE_EXT_JPG = ".jpg";


        public GameObject DrawIt_Sprite(
            GameObject obj,
            Rigidbody2D body,
            SpriteRenderer render,
            string spriteTitle,
            string spriteGiven,
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
            // Catch obj
            GameObject objRef = obj;


            if(objRef) {
                Texture2D tex = new Texture2D(
                    width,
                    height
                );


                string dir = Application.dataPath + spriteGiven + FILE_EXT_JPG;
                byte[] data = File.ReadAllBytes(dir);
                
                
                tex.LoadImage(data);


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
                render.sprite = sprite;
                render.material.mainTexture = tex;
                render.color = colour;
                render.size = size;
            }


            return objRef; // @Ret: Any changes made, if any
        }


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


            if(objRef) {
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
            }


            return objRef; // @Ret: Any changes made, if any
        }
        

        public GameObject ApplySprite(
            GameObject obj
        ) {
            GameObject objRef = obj;


            objRef.AddComponent<Rigidbody2D>();
            objRef.AddComponent<SpriteRenderer>();
            objRef.AddComponent<Canvas>();
            

            objRef.GetComponent<Rigidbody2D>().isKinematic = true;
            return objRef;
        }


        void Start() {
        }


        void Update() {
        }

    }

}