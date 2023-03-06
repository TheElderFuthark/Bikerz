/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 19/01/2023
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;


using Mechanics;
using Graphics;
using Levels;
using Player;
using Mobs;


namespace Player {
    public class PlayerProjectiles : MonoBehaviour {
        const float MAP_BOUNDS_MIN_X = -10.00f;
        const float MAP_BOUNDS_MAX_X = 10.00f;


        const float FIRE_SPEED = 0.5f;
        const string FIRE_LEFT = "left";
        const string FIRE_RIGHT = "right";


        const int MOB_COUNT_MAX_LEVEL_0 = 4;


        float i = 0.00f;
        public int iteration = 0;
        
        
        public int mobCount = 0,
            count = 0;


        List<GameObject> obj_All_Mobs = new List<GameObject>();


        GameObject obj_Player_Ref,
            obj_Player_Projectiles_Ref,
            obj_Player_Projectile_Ref,
            obj_Mobs_Ref;


        public GameObject Fire(
            GameObject projectile,
            float speed
        ) {
            GameObject objRef = projectile;
            
            
            objRef.transform.position = new Vector3(
                objRef.transform.position.x + speed,
                objRef.transform.position.y,
                objRef.transform.position.z
            );
            
            
            return objRef;    
        }


        bool HitTarget(
            GameObject projectile, 
            GameObject mob
        ) {
        
            if(projectile.GetComponent<HitboxDetection>().DamageDealt(
                projectile, 
                mob
            )) { 
                return true; 
            }


            return false;
        }

        
        GameObject CreateProjectile(
            GameObject obj, 
            Vector3 pos, 
            int i
        ) {
            GameObject objRef = obj;
            objRef.name = "Player Projectile " + i;


            objRef.AddComponent<PlayerProjectile>();
            objRef.AddComponent<Hitbox>();
            objRef.AddComponent<HitboxDetection>();
            objRef.AddComponent<DisplaySprite>();
            objRef.AddComponent<DrawSprite>(); 


            /* INIT: Assign reference to external script var
            */
            objRef.GetComponent<Hitbox>().obj_Ref = objRef;


            objRef.GetComponent<Hitbox>().x1 = 
                objRef.GetComponent<PlayerProjectile>().x2;

            
            objRef.GetComponent<Hitbox>().y1 = 
                objRef.GetComponent<PlayerProjectile>().y2;


            objRef.transform.position = pos;
            objRef.transform.parent = GameObject.Find("Player Projectiles").transform;
            
            
            return objRef;
        }
        

        void Start() {
            obj_Player_Ref = 
                GameObject.Find("Player");
            
            
            obj_Player_Projectiles_Ref = 
                GameObject.Find("Player Projectiles");


            mobCount = 
                GameObject.Find("Level Spawner")
                .GetComponent<MobsSpawner>().mobCount;


            count = 0;
            mobCount = MOB_COUNT_MAX_LEVEL_0;
        }
        

        void Update() { 
            if(count >= mobCount) {
                count = 0;
            }


            if(obj_Player_Ref.GetComponent<PlayerData>().firePressed) {
                if(iteration > 0) {
                    Destroy(GameObject.Find(
                        "Player Projectile " + (iteration - 1)
                    ));

                }


                obj_Player_Projectile_Ref = CreateProjectile(
                    new GameObject(),
                    obj_Player_Ref.transform.position, 
                    iteration
                );


                obj_Player_Projectile_Ref = obj_Player_Projectile_Ref
                    .GetComponent<DrawSprite>()
                    .ApplySprite(obj_Player_Projectile_Ref);   


                obj_Player_Ref.GetComponent<PlayerData>().firePressed = false;          
                iteration++;
            }


            if(obj_Player_Projectile_Ref) {
                if(obj_Player_Ref.GetComponent<PlayerData>().key == FIRE_LEFT) {
                    i = -FIRE_SPEED;
                } else if(obj_Player_Ref.GetComponent<PlayerData>().key == FIRE_RIGHT) {
                    i = FIRE_SPEED;
                }


                obj_Player_Projectiles_Ref
                    .GetComponent<PlayerProjectiles>()
                    .Fire(obj_Player_Projectile_Ref, i);        
                    
                        
                obj_Mobs_Ref =  GameObject.Find("Mobs " + count);
                if(HitTarget(obj_Player_Projectile_Ref, obj_Mobs_Ref) == true) {
                    Destroy(obj_Mobs_Ref);  
                    GameObject
                        .Find("Level Spawner")
                        .GetComponent<MobsSpawner>()
                        .respawn = true;
                    
                    
                    mobCount++;
                }

            } 


            if(count < mobCount) {
                count++;
            }

        }
 
    }
 
 }