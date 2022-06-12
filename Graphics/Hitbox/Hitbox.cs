/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Graphics {
    public class Hitbox : MonoBehaviour {
        public GameObject obj_Ref;


        public struct Obj_Hitbox {
            public float hitbox_x1, hitbox_y1, 
                hitbox_x2, hitbox_y2, 
                hitbox_x3, hitbox_y3, 
                hitbox_x4, hitbox_y4;


            public Vector2 hitbox_0, 
                hitbox_1, 
                hitbox_2, 
                hitbox_3;
        };


        public Obj_Hitbox hitbox;


        public float z = 0.00f;


        public float x1, 
            y1, 
            x2, 
            y2;


        bool hitboxCreated = false;


        public List<Vector2> CreateHitbox_MakeList(
            Obj_Hitbox hit
        ) {
            Obj_Hitbox hitboxRef = hit;
           
           
            return new List<Vector2> {
                hitboxRef.hitbox_0,
                hitboxRef.hitbox_1,
                hitboxRef.hitbox_2,
                hitboxRef.hitbox_3
            };

        }


        Obj_Hitbox CreateHitbox_ApplyValues(
            Obj_Hitbox hit
        ) {
            Obj_Hitbox hitboxRef = hit; // Ref
            
            
            /* SETUP HITBOXES
            */
            hitboxRef.hitbox_0 = new Vector2(
                hitboxRef.hitbox_x1, 
                hitboxRef.hitbox_y1
            );


            hitboxRef.hitbox_1 = new Vector2(
                hitboxRef.hitbox_x2,
                hitboxRef.hitbox_y2
            );


            hitboxRef.hitbox_2 = new Vector2(
                hitboxRef.hitbox_x3,
                hitboxRef.hitbox_y3
            );


            hitboxRef.hitbox_3 = new Vector2(
                hitboxRef.hitbox_x4,
                hitboxRef.hitbox_y4
            );


            /* @Ret: New hitbox */
            return hitboxRef;
        }


        Obj_Hitbox CreateHitbox_SetValues(
            Obj_Hitbox hit,
            float hit_x,
            float hit_y
        ) {
            Obj_Hitbox hitboxRef = hit; // Ref


            /* INIT VALUE/S
            */
            hitboxRef.hitbox_x1 = hit_x - hit_x;  
            hitboxRef.hitbox_y1 = hit_y;


            hitboxRef.hitbox_x2 = hit_x;    
            hitboxRef.hitbox_y2 = hit_y;
            
            
            hitboxRef.hitbox_x3 = hit_x; 
            hitboxRef.hitbox_y3 = hit_y - hit_y;
            
            
            hitboxRef.hitbox_x4 = hit_x - hit_x; 
            hitboxRef.hitbox_y4 = hit_y - hit_y;


            /* @Ret: val/s for hitbox */
            return hitboxRef;
        }


        Obj_Hitbox CreateHitbox_Create(
            Obj_Hitbox hit
        ) {
            Obj_Hitbox hitboxRef = hit;
            return hitboxRef;
        }


        GameObject Update_Object(
            GameObject obj, 
            Vector2 vec
        ) {
            GameObject objRef = obj;


            objRef.transform.position = vec;
            return objRef;
        }


        Vector3 MovePosition_Vector3(
            float x, 
            float y, 
            float index
        ) {
            return new Vector3(
                x,
                y, 
                index
            );

        }


        Vector2 MovePosition_Vector2(
            float x, 
            float y
        ) {
            return new Vector2(
                x,
                y
            );
        }


        float GetCurrentPosition_y(
            GameObject obj
        ) {
            return obj.transform.position.y;
        }


        float GetCurrentPosition_x(
            GameObject obj
        ) {
            return obj.transform.position.x;
        }


        void Start() {
        } // Do nothing...


        void Update() {            
            if(hitboxCreated && obj_Ref) {
                x1 = GetCurrentPosition_x(obj_Ref);
                y1 = GetCurrentPosition_y(obj_Ref);
            } else {
                hitbox = // INIT
                    CreateHitbox_Create(
                        new Obj_Hitbox()
                    );
                
                
                hitbox = // Set val/s 
                    CreateHitbox_SetValues(
                        hitbox, 
                        x2,
                        y2
                    );
                
                
                hitbox = // Applies them
                    CreateHitbox_ApplyValues(
                        hitbox
                    );


                // Prevents creation from reiteration
                hitboxCreated = true;           
            }
        
        }

    }

}