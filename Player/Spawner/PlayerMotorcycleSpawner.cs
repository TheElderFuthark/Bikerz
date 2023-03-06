using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Graphics;
using Mechanics;


namespace Player {
    public class PlayerMotorcycleSpawner : MonoBehaviour {
        const float MOTORCYCLE_X = 0.00f,
            MOTORCYCLE_Y = 0.00f,
            MOTORCYCLE_Z = 0.00f;


        const float AXIS_OFFSET = 11.00f;


        public GameObject SpawnMotorcycle(
            GameObject obj
        ) {
            GameObject objRef = obj;
            objRef.name = "Player Motorcycle";


            objRef.AddComponent<PlayerMotorcycle>();
            objRef.AddComponent<Hitbox>();
            objRef.AddComponent<DisplaySprite>();
            objRef.AddComponent<DrawSprite>();


            objRef.transform.position = new Vector3(
                MOTORCYCLE_X + AXIS_OFFSET,
                MOTORCYCLE_Y,
                MOTORCYCLE_Z
            );


            objRef.GetComponent<DrawSprite>().ApplySprite(objRef);
            objRef.transform.parent = GameObject.Find("Player").transform;
            
            
            return objRef;
        }


        void Start() {
        }

        
        void Update() {
        }

    }

}