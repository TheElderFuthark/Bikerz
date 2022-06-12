using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Graphics;
using Mechanics;


namespace Player {
    public class PlayerHUDSpawner : MonoBehaviour {
        public GameObject SpawnHUD(
            GameObject obj
        ) {
            GameObject objRef = obj;
            objRef.name = "Player HUD";


            objRef.AddComponent<PlayerHUD>();
            objRef.AddComponent<Hitbox>();
            objRef.AddComponent<DisplaySprite>();
            objRef.AddComponent<DrawSprite>();


            /* INIT: Assign reference to external script var
            */
            objRef.GetComponent<Hitbox>().obj_Ref = objRef;


            objRef.GetComponent<DrawSprite>().ApplySprite(objRef);
            objRef.transform.parent = GameObject.Find("Player UI").transform;


            return objRef;
        }


        void Start() {  
        }

        
        void Update() {
        }
        
    }

}