using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour {

    public static int bWeapon = 0; // 0 - arrow, 1 - rocket
    public static int GAME_SCORE = 0;
    public Texture bTexture_arrow;
    public Texture bTexture_rocket;

    // Use this for initialization
    void Start ()
    {
      
 
	}

    void OnGUI()
    {
        GUIStyle style = GUI.skin.GetStyle("label");
        style.fontSize = (int)64;

        string score = "Kill : " + GAME_SCORE.ToString();

        GUI.Label(new Rect(160, 900, 300, 100), score.ToString());

        if (GUI.Button(new Rect(100, 100, 100, 100), bTexture_arrow))          
        {
            bWeapon = 0;
        }
        if (GUI.Button(new Rect(260, 100, 100, 100), bTexture_rocket))   
        {
            bWeapon = 1;
        }

        
    }
        // Update is called once per frame
        /*
        void Update () {

        }
        */
    }
