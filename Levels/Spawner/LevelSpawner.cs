using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Levels {
    public class LevelSpawner : MonoBehaviour {
        public bool SpawnInstance(
            GameObject obj
        ) {
            if(obj) {
                return true;
            } 
            
            
            return false;
        }


        public bool SpawnAll(
            GameObject hud,
            GameObject player,
            GameObject motorcycle,
            GameObject projectiles,
            GameObject mob
        ) {
            if( hud && 
                player && 
                motorcycle && 
                projectiles &&
                mob
            ) {
                return true;
            }


            return false;
        }


        void Start() {
        }

        
        void Update() {
        }

    }

}