using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Graphics;
using Mechanics;


namespace Player {
    public class PlayerProjectileSpawner : MonoBehaviour {
        public GameObject SpawnProjectileLauncher(
            GameObject obj
        ) {
            GameObject objRef = obj;
            objRef.name = "Player Projectiles";


            objRef.AddComponent<PlayerProjectiles>();
            objRef.AddComponent<DisplaySprite>();
            objRef.AddComponent<DrawSprite>();


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