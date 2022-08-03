using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Bikerz;
using Levels;


namespace Menus {
    public class MenuActions : MonoBehaviour {
        public void ExitGame() {
            Application.Quit();
            return;
        }


        public void ExitToMainMenu() {
            /*  This method should include the actions, in the correct order, of the Game Screen
                extiing, and re-entering the Main Menu Screen.
            */
            GameObject.Find("Game Manager").GetComponent<GameManager>().reset = true;
        }


        public void RestartLevel() {
            /*  This method should include the necessary instructions to reset the level,
                perhaps a recursion could be used here??
            */
            GameObject.Find("Level Manager").GetComponent<LevelManager>().restart = true;
        }


        public void LoadCreditsScreen() {
            /*  This method Should exit the Main Menu Screen, and enter
                the scrolling screen of the Credits...
            */
            GameObject.Find("Menu Manager").GetComponent<MenuManager>().credits = true;
        }


        public void LoadOptionsMenu() {
            /*  When executed, this method should load ONCE the options overlay, over
                the Main Menu Screen.
            */
            GameObject.Find("Menu Manager").GetComponent<MenuManager>().loadOptionsMenu = true;
        }


        public void LoadLevelMenu() {
            /*  Working with the level loader, this should be the controlling screen of all
                the current saves on disk.
            */
            GameObject.Find("Menu Manager").GetComponent<MenuManager>().loadLevelMenu = true;
        }


        public void LoadLastSave() {
            /*   Enters game screen using the last playable save.
            */
            GameObject.Find("Menu Manager").GetComponent<MenuManager>().loadLastSave = true;
        }


        public void SaveGame() {
            /*  Either overwrites current save file or generates a new one.
            */
            GameObject.Find("Menu Manager").GetComponent<MenuManager>().saveGame = true;
        }


        public void NewGame() {
            /*  Resets save file (overwritten with 0/Null...)
            */
            GameObject.Find("Menu Manager").GetComponent<MenuManager>().newGame = true;
        }


        void Start() {
        } // Do nothing...


        void Update() {
        } // Do nothing...

    }

}
