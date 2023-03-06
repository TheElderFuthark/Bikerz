/*  @Title: Bikerz
    @Author: Lloyd Thomas
    @Version: v0.01
    @Date: 29/05/2022
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Mobs;
using Graphics;


namespace Player {
    public class PlayerControls : MonoBehaviour {
        public const float FIRE_SPEED = 0.125f;


        public const string FIRE_LEFT = "left";
        public const string FIRE_RIGHT = "right";


        public const float Z = 0.00f;


        public const int GRIDSNAP_MIN_X = -4;
        public const int GRIDSNAP_MAX_X = 4;


        public const int GRIDSNAP_MIN_Y = 0;
        public const int GRIDSNAP_MAX_Y = 4;


        public const float PLAYER_SPEED = 0.25f;
        public const float PLAYER_SPEED_X = 0.025f;
        public const float PLAYER_SPEED_Y = 1.00f;


        GameObject obj_Player_Ref;


        public float x2,
            y2;


        void MoveLeft(
            GameObject player,
            float x,
            float y
        ) {
            player.transform.position = new Vector3(
                x - PLAYER_SPEED_X,
                y,
                Z
            );

        }


        void MoveRight(
            GameObject player,
            float x,
            float y
        ) {
            player.transform.position = new Vector3(
                x + PLAYER_SPEED_X,
                y,
                Z
            );

        }


        void MoveUp(
            GameObject player,
            float x,
            float y
        ) {
            player.transform.position = new Vector3(
                x,
                y + PLAYER_SPEED_Y,
                Z
            );

        }


        void MoveDown(
            GameObject player,
            float x,
            float y
        ) {
            player.transform.position = new Vector3(
                x,
                y - PLAYER_SPEED_Y,
                Z
            );

        }


        int MovePlayer(
            GameObject player,
            float x,
            float y
        ) {
            // Overall player movement capabilities
            int gridSnap_y_Ref = player.GetComponent<PlayerData>().gridSnap_y;


            if(Input.GetKey("left") ||
                Input.GetKey("a")
            ) {
                if(x > GRIDSNAP_MIN_X) {
                    MoveLeft(player,
                        x,
                        y
                    );

                }
            } else if(Input.GetKey("right") ||
                Input.GetKey("d")
            ) {
                if(x < GRIDSNAP_MAX_X) {
                    MoveRight(player,
                        x,
                        y
                    );

                }
            } else if(Input.GetKeyDown("up") ||
                Input.GetKeyDown("w")
            ) {
                if(gridSnap_y_Ref < GRIDSNAP_MAX_Y) {
                    MoveUp(player,
                        x,
                        y
                    );


                    gridSnap_y_Ref++;
                }
            } else if(Input.GetKeyDown("down") ||
                Input.GetKeyDown("s")
            ) {
                if(gridSnap_y_Ref > GRIDSNAP_MIN_Y) {
                    MoveDown(player,
                        x,
                        y
                    );


                    gridSnap_y_Ref--;
                }

            }


            return gridSnap_y_Ref;
        }


        string KeyPressed() {
            if(Input.GetKeyDown("1")) {
                return FIRE_LEFT;
            } else if(Input.GetKeyDown("2")) {
                return FIRE_RIGHT;
            }


            return "\0";
        }


        float GetCurrentPosition_x(
            GameObject player
        ) {
            return player.transform.position.x;
        }


        float GetCurrentPosition_y(
            GameObject player
        ) {
            return player.transform.position.y;
        }


        void Start() {
            obj_Player_Ref = GameObject.Find("Player");
        }


        void Update() {
            x2 = GetCurrentPosition_x(obj_Player_Ref);
            y2 = GetCurrentPosition_y(obj_Player_Ref);


            obj_Player_Ref.
                GetComponent<PlayerData>().
                    gridSnap_y = MovePlayer(
                        obj_Player_Ref,
                        x2,
                        y2
                    );


            if((obj_Player_Ref.GetComponent<PlayerData>().key = KeyPressed()) != "\0") {
                obj_Player_Ref.GetComponent<PlayerData>().firePressed = true;
            }

        }

    }

}
