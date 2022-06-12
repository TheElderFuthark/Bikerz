using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Graphics;
using Mechanics;


namespace Player {
    public class PlayerSpawner : MonoBehaviour {
        const float PLAYER_X = 0.00f,
            PLAYER_Y = 0.00f,
            PLAYER_Z = 0.00f;


        public GameObject SpawnPlayer(
            GameObject obj
        ) {
            GameObject objRef = obj;
            objRef.name = "Player";


            objRef.AddComponent<PlayerControls>();
            objRef.AddComponent<PlayerData>();
            objRef.AddComponent<Hitbox>();
            objRef.AddComponent<HitboxDetection>();
            objRef.AddComponent<DisplaySprite>();
            objRef.AddComponent<DrawSprite>();


            objRef.transform.position = new Vector3(
                PLAYER_X,
                PLAYER_Y,
                PLAYER_Z
            );


            /* INIT: Assign reference to external script var
            */
            objRef.GetComponent<Hitbox>().obj_Ref = objRef;


            /* Size & position of hitbox relative to external script/s.
            */
            objRef.GetComponent<PlayerData>().x1 = objRef.GetComponent<Hitbox>().obj_Ref.GetComponent<Hitbox>().x1;
            objRef.GetComponent<PlayerData>().y1 = objRef.GetComponent<Hitbox>().obj_Ref.GetComponent<Hitbox>().y1;


            objRef.GetComponent<Hitbox>().x2 = objRef.GetComponent<PlayerData>().x2;
            objRef.GetComponent<Hitbox>().y2 = objRef.GetComponent<PlayerData>().y2;


            objRef.GetComponent<DrawSprite>().ApplySprite(objRef);
            objRef.transform.parent = GameObject.Find("Level Actions").transform;


            return objRef;
        }


        void Start() {
        }

        
        void Update() {
        }

    }

}