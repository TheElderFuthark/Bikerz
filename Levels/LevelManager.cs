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


using Graphics;
using Player;
using Mobs;


namespace Levels {
    public class LevelManager : MonoBehaviour {
        const string DEBUG_SUCCESS = "Level loaded...", 
            DEBUG_FAIL = "ERROR: Issue loading level...";   


        const string GAME_OBJECT_GAME_MANAGER = "Game Manager",
            GAME_OBJECT_LEVEL_ACTIONS = "Level Actions",
            GAME_OBJECT_LEVEL_MANAGER = "Level Manager",
            GAME_OBJECT_UI = "Player UI";


        GameObject StartTimer(
            GameObject obj
        ) {
            GameObject objRef = obj;
            objRef.name = "Level Timer";


            objRef.AddComponent<LevelTimer>();
            objRef.transform.parent = GameObject.Find(GAME_OBJECT_LEVEL_MANAGER).transform;
            
            
            return objRef;
        }


        GameObject InitialiseLevel(
            GameObject obj
        ) {
            GameObject objRef = obj;
            objRef.name = GAME_OBJECT_LEVEL_ACTIONS;


            objRef.AddComponent<LevelActions>();
            
            
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
            GameObject hud,
            GameObject timer
        ) {
            if(levels && hud && timer) {
                return true;
            }


            return false;
        }


        void Start() {
            /* INIT */
            if(SpawnAll(
                InitialiseLevel(new GameObject()),
                DisplayUI(new GameObject()),
                StartTimer(new GameObject())
            )) {
                Debug.Log(DEBUG_SUCCESS);
            } else {
                Debug.Log(DEBUG_FAIL);
            }

        }

        
        void Update() { 
        } // Do nothing...

    }

}