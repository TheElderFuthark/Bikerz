using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Graphics;
using Mechanics;
using Levels;


namespace Mobs {
    public class MobsSpawner : MonoBehaviour {
        const string DEBUG_SUCCESS = "Mob Respawned...",
            DEBUG_FAIL = "Mob could not be respawned...";


        public GameObject SpawnMob(
            GameObject obj
        ) {
            GameObject objRef = obj;
            objRef.name = "Mobs";


            objRef.AddComponent<MobsTest>();
            objRef.AddComponent<MobsData>();
            objRef.AddComponent<Hitbox>();
            objRef.AddComponent<HitboxDetection>();
            objRef.AddComponent<DisplaySprite>();
            objRef.AddComponent<DrawSprite>();


            /* RANDOM: Random spawning on map
            */
            objRef.transform.position = new Vector3(
                Random.Range(
                    -8.00f, 
                    8.00f
                ),
                Random.Range(
                    -6.00f, 
                    6.00f
                ),
                0.00f
            );


            /* INIT: Assign reference to external script var
            */
            objRef.GetComponent<Hitbox>().obj_Ref = objRef;


            objRef.GetComponent<Hitbox>().x2 = objRef.GetComponent<MobsTest>().x2;
            objRef.GetComponent<Hitbox>().y2 = objRef.GetComponent<MobsTest>().y2;
            
            
            objRef.GetComponent<DrawSprite>().ApplySprite(objRef);
            objRef.transform.parent = GameObject.Find("Level Actions").transform;
            
            
            return objRef;
        }


        void Start() {
        }


        void Update() {
            if(!GameObject.Find("Mobs")) {
                if(GameObject.Find("Level Spawner")
                    .GetComponent<LevelSpawner>()
                    .SpawnInstance(GameObject.Find("Level Spawner")
                        .GetComponent<MobsSpawner>()
                        .SpawnMob(new GameObject()))
                ) {
                    Debug.Log(DEBUG_SUCCESS);
                } else {
                    Debug.Log(DEBUG_FAIL);
                }

            }

        }

    }

}

