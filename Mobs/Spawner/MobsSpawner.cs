/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 08/02/2023
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Graphics;
using Mechanics;
using Levels;
using Player;


namespace Mobs {
    public class MobsSpawner : MonoBehaviour {
        const string DEBUG_SUCCESS = "Mob spawned...",
            DEBUG_FAIL = "Mob could not be spawned...",
            DEBUG_RESPAWN_SUCCESS = "Mob respawned...",
            DEBUG_RESPAWN_FAIL = "Mob failed to respawn...";


        const int MOB_COUNT_MAX_LEVEL_0 = 4;


        public int mobCount = 1,
            mobLevelCount = 0;


        string mobSelected = "";
        
        
        public bool respawn = false;


        public List<GameObject> obj_All_Mobs = new List<GameObject>();


        GameObject obj_Player_Ref;


        public GameObject SpawnMob(
            GameObject obj,
            int count
        ) {
            GameObject objRef = obj;
            objRef.name = "Mobs " + count;


            /*  TEST CODE
            =================================

            objRef.AddComponent<MobsTest>();

            =================================
            */


            objRef.AddComponent<MobsMovement>();
            objRef.AddComponent<MobsAttacks>();
            objRef.AddComponent<MobsBehaviour>();
            objRef.AddComponent<MobsData>();
            objRef.AddComponent<Hitbox>();
            objRef.AddComponent<HitboxDetection>();
            objRef.AddComponent<DisplaySprite>();
            objRef.AddComponent<DrawSprite>();


            /* RANDOM: Random spawning on map
            */
            objRef.transform.position = new Vector3(
                Random.Range(
                    -12.00f, 
                    12.00f
                ),
                Random.Range(
                    -9.00f, 
                    9.00f
                ),
                0.00f
            );


            /* INIT: Assign reference to external script var
            */
            objRef.GetComponent<Hitbox>().obj_Ref = objRef;


            /*  TEST CODE
            =======================================================================
            
            objRef.GetComponent<Hitbox>().x2 = objRef.GetComponent<MobsTest>().x2;
            objRef.GetComponent<Hitbox>().y2 = objRef.GetComponent<MobsTest>().y2;
            
            =======================================================================
            */


            objRef.GetComponent<Hitbox>().x2 = objRef.GetComponent<MobsBehaviour>().x2;
            objRef.GetComponent<Hitbox>().y2 = objRef.GetComponent<MobsBehaviour>().y2;
            
            
            objRef.GetComponent<DrawSprite>().ApplySprite(objRef);
            objRef.transform.parent = GameObject.Find("Level Actions").transform;
            

            obj_All_Mobs.Add(objRef);
            return objRef;
        }


        void Start() {
            obj_Player_Ref = GameObject.Find("Player");
        }


        void Update() {
            if(mobCount < MOB_COUNT_MAX_LEVEL_0 || 
                respawn == true
            ) {
                if(!GameObject.Find("Mobs " + mobCount)) {
                    if(GameObject.Find("Level Spawner")
                        .GetComponent<LevelSpawner>()
                        .SpawnInstance(GameObject.Find("Level Spawner")
                        .GetComponent<MobsSpawner>()
                        .SpawnMob(new GameObject(), mobCount))
                    ) {
                        mobSelected = "Mobs " + mobCount;

                        /*  TEST CODE
                        =============================================================================
                        
                        GameObject.Find(mobSelected).GetComponent<MobsTest>().count = mobCount;

                        =============================================================================
                        */


                        GameObject.Find(mobSelected).GetComponent<MobsBehaviour>().count = mobCount;
                        GameObject.Find(mobSelected).GetComponent<MobsData>().count = mobCount;


                        Debug.Log(DEBUG_SUCCESS);
                    } else {
                        Debug.Log(DEBUG_FAIL);
                    }
                        
                }


                if(respawn == true) {
                    respawn = false;
                }
            
                
                mobCount++;
            }


            //mobLevelCount = GameObject.Find(mobSelected).GetComponent<MobsDifficulty>().;
        }

    }

}

