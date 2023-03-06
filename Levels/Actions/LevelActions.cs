/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Physics;


using Mechanics;
using Graphics;
using Player;
using Mobs;


namespace Levels {
    public class LevelActions : MonoBehaviour {        
        const string DEBUG_SUCCESS = "SUCCESS!! ALL objects successfully spawned...",
            DEBUG_FAIL = "ERROR: Object/s could not be generated and/or spawned...";


        public GameObject obj_Spawner;


        bool Spawn(GameObject obj) {
            GameObject objRef = obj;

            
            return objRef.GetComponent<LevelSpawner>().SpawnAll(
                objRef.GetComponent<PlayerHUDSpawner>().SpawnHUD(new GameObject()),
                objRef.GetComponent<PlayerSpawner>().SpawnPlayer(new GameObject()),
                objRef.GetComponent<PlayerMotorcycleSpawner>().SpawnMotorcycle(new GameObject()),
                objRef.GetComponent<PlayerProjectileSpawner>().SpawnProjectileLauncher(new GameObject()),
                objRef.GetComponent<MobsSpawner>().SpawnMob(new GameObject(), 0)
            );

        }


        GameObject Spawner(GameObject obj) {
            GameObject objRef = obj;
            objRef.name = "Level Spawner";


            objRef.AddComponent<LevelSpawner>();
                objRef.AddComponent<PlayerHUDSpawner>();
                objRef.AddComponent<PlayerSpawner>();
                objRef.AddComponent<PlayerMotorcycleSpawner>();
                objRef.AddComponent<PlayerProjectileSpawner>();
                objRef.AddComponent<MobsSpawner>();


            objRef.transform.parent = GameObject.Find("Level Actions").transform;
            return objRef;
        }


        void Start() {
            if(Spawn( (obj_Spawner = Spawner(new GameObject()) ))) {
                Debug.Log(DEBUG_SUCCESS);
            } else {
                Debug.Log(DEBUG_FAIL);
                Application.Quit();
            }
            
        }


        void Update() {
        } // Do nothing...

    }

}