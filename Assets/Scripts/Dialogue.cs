using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TMP_Text BlockText;
    [SerializeField] TMP_Text CommandText;

    //COLOURS
    Color Red = new Color32(237, 128, 153, 255); //RGBA
    Color Orange = new Color32(251, 107, 29, 255); //RGBA
    Color Green = new Color32(145, 219, 105, 255); //RGBA
    Color Blue = new Color32(77, 155, 230, 255); //RGBA
    Color Purple = new Color32(168, 132, 243, 255); //RGBA
    Color Pink = new Color32(240, 79, 120, 255); //RGBA

    void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.tag == "Pavement")
        {
            Debug.Log("Player has entered a Pavement block");

            BlockText.color = Pink;
            BlockText.outlineWidth = 0.2f;
            BlockText.outlineColor = new Color32(255, 255, 255, 255);

            BlockText.SetText("Pavement");
        }

        if (collision2D.gameObject.tag == "Road")
        {
            Debug.Log("Player has entered a Road block");

            BlockText.color = Orange;
            BlockText.outlineWidth = 0.2f;
            BlockText.outlineColor = new Color32(255, 255, 255, 255);

            BlockText.SetText("Road");
        }

        if (collision2D.gameObject.tag == "Stairs")
        {
            Debug.Log("Player has entered a Stair block");

            BlockText.color = Green;
            BlockText.outlineWidth = 0.2f;
            BlockText.outlineColor = new Color32(255, 255, 255, 255);

            BlockText.SetText("Stairs");
        }

        if (collision2D.gameObject.tag == "Bollard")
        {
            Debug.Log("Player has entered a Bollard block");

            BlockText.color = Blue;
            BlockText.outlineWidth = 0.2f;
            BlockText.outlineColor = new Color32(255, 255, 255, 255);

            BlockText.SetText("Bollard");
        }

        if (collision2D.gameObject.tag == "TrafficLights")
        {
            Debug.Log("Player has entered a Traffic Light block");

            BlockText.color = Purple;
            BlockText.outlineWidth = 0.2f;
            BlockText.outlineColor = new Color32(255, 255, 255, 255);

            BlockText.SetText("Traffic Lights");
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        //PAVEMENT - Random: Go or Nothing
        if (collision2D.gameObject.tag == "PavementCol")
        {
            if (Random.Range(1, 3) == 1) //1 or 2
            {
                Debug.Log("Print Go (Pavement)");
                CommandText.color = new Color32(255, 255, 255, 255);
                CommandText.outlineWidth = 0.2f;
                CommandText.outlineColor = new Color32(0, 0, 0, 255);

                CommandText.SetText("Go");
            }
            else if (Random.Range(1, 3) == 2) // 1 or 2
            {
                Debug.Log("Print Nothing (Pavement)");
                CommandText.color = new Color32(255, 255, 255, 0); //Opacity 0
                CommandText.outlineColor = new Color32(0, 0, 0, 0); //Opacity 0
                CommandText.SetText("[Do Nothing]");
            }   
        }       


        //ROAD + BOLLARD - Stop, Wait (2-5 Seconds, Random), Cross
        if (collision2D.gameObject.tag == "RoadCol")
        {
            Debug.Log("Stop (Road/Bollard)");
            CommandText.color = new Color32(255, 255, 255, 255);
            CommandText.outlineWidth = 0.2f;
            CommandText.outlineColor = new Color32(0, 0, 0, 255);

            CommandText.SetText("Stop");
        }
        else
        {
            Debug.Log("Disabled (Road/Bollard)");
            CommandText.color = new Color32(255, 255, 255, 0); //Opacity 0
            CommandText.outlineColor = new Color32(0, 0, 0, 0); //Opacity 0
        }


        //TRAFFIC LIGHTS - Stop, Wait (for light sprite to change), Cross
        if (collision2D.gameObject.tag == "TLCol")
        {
            Debug.Log("Stop (Traffic Lights)");
            CommandText.color = new Color32(255, 255, 255, 255);
            CommandText.outlineWidth = 0.2f;
            CommandText.outlineColor = new Color32(0, 0, 0, 255);

            CommandText.SetText("Wait");
        }
        else
        {
            Debug.Log("Disabled (Traffic Lights)");
            CommandText.color = new Color32(255, 255, 255, 0); //Opacity 0
            CommandText.outlineColor = new Color32(0, 0, 0, 0); //Opacity 0
        }


        //STAIRS - Stop, Stairs
        if (collision2D.gameObject.tag == "StairsCol")
        {
            Debug.Log("Stop (Stairs)");
            CommandText.color = new Color32(255, 255, 255, 255);
            CommandText.outlineWidth = 0.2f;
            CommandText.outlineColor = new Color32(0, 0, 0, 255);

            CommandText.SetText("Stop");
        }
        else
        {
            Debug.Log("Disabled (Stairs)");
            CommandText.color = new Color32(255, 255, 255, 0); //Opacity 0
            CommandText.outlineColor = new Color32(0, 0, 0, 0); //Opacity 0
        }
    }

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
