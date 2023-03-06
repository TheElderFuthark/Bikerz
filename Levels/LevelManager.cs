/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEngine.SceneManagement;


using Bikerz;
using Graphics;
using Player;
using Mobs;


namespace Levels {
    public class LevelManager : MonoBehaviour {
        const string DEBUG_SUCCESS = "Level loaded...",
            DEBUG_FAIL = "ERROR: Issue loading level...";


        const string GAME_OBJECT_GAME_MANAGER = "Game Manager",
            GAME_OBJECT_DATA = "Game Data Tracker",
            GAME_OBJECT_LEVEL_ACTIONS = "Level Actions",
            GAME_OBJECT_LEVEL_LOADER = "Level Loader",
            GAME_OBJECT_LEVEL_MANAGER = "Level Manager",
            GAME_OBJECT_UI = "Player UI",
            GAME_OBJECT_TIMER = "Level Timer";


        public bool restart = false;

        
        public int givenCount = 0;
        public bool givenLvUp = false;


        public float mobSpeedValue,
            mobMultipleValue;


        GameObject obj_Level_Actions;


        GameObject StartTimer(
            GameObject obj
        ) {
            GameObject objRef = obj;
            objRef.name = GAME_OBJECT_TIMER;


            objRef.AddComponent<LevelTimer>();
            
            
            objRef.transform.parent = GameObject.Find(GAME_OBJECT_LEVEL_MANAGER).transform;
            return objRef;
        }


        GameObject InitialiseLevel(
            GameObject obj,
            bool lvlUp,
            int count
        ) {
            GameObject objRef = obj;
            objRef.name = GAME_OBJECT_LEVEL_ACTIONS;
            
            
            objRef.AddComponent<LevelActions>();
            objRef.AddComponent<MobsDifficulty>();

            
            objRef.GetComponent<MobsDifficulty>().levelCount = count;
            objRef.GetComponent<MobsDifficulty>().levelUp = lvlUp;


            objRef.transform.parent = GameObject.Find(GAME_OBJECT_LEVEL_MANAGER).transform;            
            return objRef;
        }


        GameObject DisplayUI(
            GameObject obj
        ) {
            GameObject objRef = obj;
            objRef.name = GAME_OBJECT_UI;


            objRef.AddComponent<PlayerHUD>();
            objRef.AddComponent<DrawSprite>();


            objRef.transform.parent = GameObject.Find(GAME_OBJECT_GAME_MANAGER).transform;
            return objRef;
        }


        bool SpawnAll(
            GameObject levels,
            GameObject ui,
            GameObject timer
        ) {
            if( levels == GameObject.Find(levels.name) &&
                ui == GameObject.Find(ui.name) &&
                timer == GameObject.Find(timer.name)
            ) {
                return true;
            }


            return false;
        }


        void Start() {
            /*  Chcecks if there is already instance/s, 
                that the spawner would otherwise handle...
             */
            if(!(GameObject.Find(GAME_OBJECT_LEVEL_ACTIONS)) &&
                !(GameObject.Find(GAME_OBJECT_UI)) &&
                !(GameObject.Find(GAME_OBJECT_TIMER))
            ) {
                /* INIT */
                if(SpawnAll(
                    InitialiseLevel(
                        new GameObject(), givenLvUp, givenCount),
                    DisplayUI(new GameObject()),
                    StartTimer(new GameObject())
                )) {
                    Debug.Log(DEBUG_SUCCESS);

                    
                    /* For reference... */
                    obj_Level_Actions = 
                        GameObject.Find(GAME_OBJECT_LEVEL_ACTIONS);
                } else {
                    Debug.Log(DEBUG_FAIL);
                }

            }

        }


        void Update() {
            if(restart == true) {                   
                // Store previous val/s,
                givenCount = obj_Level_Actions.GetComponent<MobsDifficulty>().levelCount;
                mobSpeedValue = obj_Level_Actions.GetComponent<MobsDifficulty>().speedValue;
                mobMultipleValue = obj_Level_Actions.GetComponent<MobsDifficulty>().multipleValue;


                // Reload the level,
                SceneManager.UnloadSceneAsync("Test Area");
                SceneManager.LoadSceneAsync("Test Area");


                obj_Level_Actions = 
                    GameObject.Find(GAME_OBJECT_LEVEL_ACTIONS);


                // Increase level count
                givenCount++;


                // Update val/s,
                obj_Level_Actions.GetComponent<MobsDifficulty>().levelCount = givenCount;
                obj_Level_Actions.GetComponent<MobsDifficulty>().speedValue = mobSpeedValue;
                obj_Level_Actions.GetComponent<MobsDifficulty>().multipleValue = mobMultipleValue;


                // Increment, using updated val/s.
                obj_Level_Actions.GetComponent<MobsDifficulty>().levelUp = true;
                restart = false;
            }
        
        }

    }

}
