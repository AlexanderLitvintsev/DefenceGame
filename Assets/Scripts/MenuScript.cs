using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public int window;

    public int position = 0;
    public int samplerate = 44100;
    public float frequency = 440;

    public Texture aTexture;

    void Start ()
    {
        AudioClip sd_menu = AudioClip.Create("sd_menu.mp3", samplerate * 2, 1, samplerate, true);
        AudioSource Menu_Audio = GetComponent<AudioSource>();

    //    Menu_Audio.clip = sd_menu;
    //    Menu_Audio.Play();

        

        window = 1;

    }

    void OnGUI()
    {
        GUIStyle style = GUI.skin.GetStyle("button");
        style.fontSize = (int)24;

        GUI.BeginGroup(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 300, 500, 600));
        

        if (window == 1)
        {
            if (GUI.Button(new Rect(10, 10, 400, 110), "Play"))          // 10, 30, 180, 30
            {
                window = 2;
            }
            if (GUI.Button(new Rect(10, 160, 400, 110), "Preferences"))   // 10, 70, 180, 30
            {
                window = 3;
            }
            if (GUI.Button(new Rect(10, 310, 400, 110), "About Game"))   // 10, 110, 180, 30
            {
                window = 4;
            }
            if (GUI.Button(new Rect(10, 460, 400, 110), "Exit"))         // 10, 150, 180, 30
            {
                window = 5;
            }
        }

        if (window == 2)
        {

            if (GUI.Button(new Rect(10, 10, 400, 400), aTexture))
            {
                SceneManager.LoadScene("sc_main");
            //    Destroy(this);
            }

        //    GUI.DrawTexture(new Rect(10, 10, 60, 60), aTexture, ScaleMode.ScaleToFit, true, 10.0F);

            /*
            GUI.Label(new Rect(50, 0, 180, 30), "Level map");
            if (GUI.Button(new Rect(10, 10, 400, 110), "Level 1"))
            {
                Debug.Log("Level 1 loaded");
                Application.LoadLevel(1);
            }
            if (GUI.Button(new Rect(10, 160, 400, 110), "Level 2"))
            {
                Debug.Log("Level 2 loaded");
                Application.LoadLevel(2);
            }
            if (GUI.Button(new Rect(10, 310, 400, 110), "Level 3"))
            {
                Debug.Log("Level 3 loaded");
                Application.LoadLevel(3);
            }
            */

            if (GUI.Button(new Rect(10, 460, 400, 110), "Back"))
            {
                window = 1;
            }
            
        }

        if (window == 3)
        {
            GUI.Label(new Rect(50, 10, 180, 30), "Preferences");
            if (GUI.Button(new Rect(10, 10, 400, 110), "Game"))
            {
            }
            if (GUI.Button(new Rect(10, 160, 400, 110), "Audio"))
            {
            }
            if (GUI.Button(new Rect(10, 310, 400, 110), "Video"))
            {
            }
            if (GUI.Button(new Rect(10, 460, 400, 110), "Back"))
            {
                window = 1;
            }
        }

        if (window == 4)
        {
            GUI.Label(new Rect(50, 10, 180, 30), "About Game");
            GUI.Label(new Rect(10, 40, 180, 40), "Developers:");
            if (GUI.Button(new Rect(10, 90, 400, 110), "Back"))
            {
                window = 1;
            }
        }

        if (window == 5)
        {
            GUI.Label(new Rect(50, 10, 180, 30), "Are you sure?");
            if (GUI.Button(new Rect(10, 10, 400, 110), "Yes"))
            {
                Application.Quit();
            }
            if (GUI.Button(new Rect(10, 160, 400, 110), "No"))
            {
                window = 1;
            }
        }


        GUI.EndGroup();


    }

    /*
	// Update is called once per frame
	void Update () {
		
	}
    */
}
