/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Levels {
    public class LevelSpawner : MonoBehaviour {
        public bool SpawnInstance(
            GameObject obj
        ) {
            if(GameObject.Find(obj.name)) {
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
            if( GameObject.Find(hud.name) && 
                GameObject.Find(player.name) && 
                GameObject.Find(motorcycle.name) && 
                GameObject.Find(projectiles.name) &&
                GameObject.Find(mob.name)
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