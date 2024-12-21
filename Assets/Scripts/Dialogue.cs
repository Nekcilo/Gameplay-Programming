using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using Unity.Collections;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TMP_Text BlockText;
    [SerializeField] TMP_Text CommandText;
    [SerializeField] TextMeshProUGUI DebugText;
    Animator TL_Anim;
    public GameObject[] AnimArray;
    int x = 0;

    //COLOURS
    Color Red = new Color32(237, 128, 153, 255); //RGBA
    Color Orange = new Color32(251, 107, 29, 255); //RGBA
    Color Green = new Color32(145, 219, 105, 255); //RGBA
    Color Blue = new Color32(77, 155, 230, 255); //RGBA
    Color Purple = new Color32(168, 132, 243, 255); //RGBA
    Color Pink = new Color32(240, 79, 120, 255); //RGBA

    bool Trigger = false;
    float Secs;

    bool PavementBool = false;
    bool RoadBool = false;
    bool TLBool = false;
    bool StairsBool = false;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Secs = 0f;
        Trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Trigger == true)
        {
            DebugText.SetText((System.Math.Truncate(Secs)).ToString());
            Secs -= Time.deltaTime;
            if (Secs <= 0)
            {
                Trigger = false;
                CommandText.color = new Color32(255, 255, 255, 255);
                CommandText.outlineWidth = 0.2f;
                CommandText.outlineColor = new Color32(0, 0, 0, 255);
                if (PavementBool == true)
                {
                    CommandText.SetText("Go"); //Sets text to go once timer is finished, if pavementbool is true
                    PavementBool = false;
                }
                if (RoadBool == true)
                {
                   CommandText.SetText("Cross"); //Sets text to cross once timer is finished, if roadbool is true
                   RoadBool = false;
                }
                if (TLBool == true)
                {
                   CommandText.SetText("Cross"); //Sets text to cross once timer is finished, if tlbool is true
                   TLBool = false;
                   TL_Anim.SetBool("IsTriggered", false);
                   Debug.Log("THE ANIMATION SHOULD NOW BE RESET");
                   x++;
                }
                if (StairsBool == true)
                {
                   CommandText.SetText("Stairs"); //Sets text to stairs once timer is finished, if stairsbool is true
                   StairsBool = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.tag == "Pavement")
        {
            //Hides previous command text on new block entered
            CommandText.color = new Color32(255, 255, 255, 0);
            CommandText.outlineWidth = 0.2f;
            CommandText.outlineColor = new Color32(0, 0, 0, 0);

            //Debug.Log("Player has entered a Pavement block");

            BlockText.color = Pink;
            BlockText.outlineWidth = 0.2f;
            BlockText.outlineColor = new Color32(255, 255, 255, 255);

            BlockText.SetText("Pavement");
        }

        if (collision2D.gameObject.tag == "Road")
        {
            //Hides previous command text on new block entered
            CommandText.color = new Color32(255, 255, 255, 0);
            CommandText.outlineWidth = 0.2f;
            CommandText.outlineColor = new Color32(0, 0, 0, 0);

            //Debug.Log("Player has entered a Road block");

            BlockText.color = Orange;
            BlockText.outlineWidth = 0.2f;
            BlockText.outlineColor = new Color32(255, 255, 255, 255);

            BlockText.SetText("Road");
        }

        if (collision2D.gameObject.tag == "Stairs")
        {
            //Hides previous command text on new block entered
            CommandText.color = new Color32(255, 255, 255, 0);
            CommandText.outlineWidth = 0.2f;
            CommandText.outlineColor = new Color32(0, 0, 0, 0);

            //Debug.Log("Player has entered a Stair block");

            BlockText.color = Green;
            BlockText.outlineWidth = 0.2f;
            BlockText.outlineColor = new Color32(255, 255, 255, 255);

            BlockText.SetText("Stairs");
        }

        if (collision2D.gameObject.tag == "Bollard")
        {
            //Hides previous command text on new block entered
            CommandText.color = new Color32(255, 255, 255, 0);
            CommandText.outlineWidth = 0.2f;
            CommandText.outlineColor = new Color32(0, 0, 0, 0);

            //Debug.Log("Player has entered a Bollard block");

            BlockText.color = Blue;
            BlockText.outlineWidth = 0.2f;
            BlockText.outlineColor = new Color32(255, 255, 255, 255);

            BlockText.SetText("Bollard");
        }

        if (collision2D.gameObject.tag == "TrafficLights")
        {
            AnimArray = GameObject.FindGameObjectsWithTag("TLLights"); //.GetComponent<Animator>()
            TL_Anim = AnimArray[x].GetComponent<Animator>();

            //Hides previous command text on new block entered
            CommandText.color = new Color32(255, 255, 255, 0);
            CommandText.outlineWidth = 0.2f;
            CommandText.outlineColor = new Color32(0, 0, 0, 0);

            //Debug.Log("Player has entered a Traffic Light block");

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
                //Debug.Log("Print Go (Pavement)");
                CommandText.color = Pink;
                CommandText.outlineWidth = 0.2f;
                CommandText.outlineColor = new Color32(0, 0, 0, 255);
                
                Secs = Random.Range(1, 5); //1 to 5
                Debug.Log(Secs);
                Trigger = true; //Sets the timer to count down
                Debug.Log("Timer Started");
                CommandText.SetText("Wait");

                PavementBool = true;

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
            CommandText.color = Orange;
            CommandText.outlineWidth = 0.2f;
            CommandText.outlineColor = new Color32(0, 0, 0, 255);

            Secs = Random.Range(1, 5); //1 to 5
            Trigger = true; //Sets the timer to count down
            Debug.Log("Timer Started");
            CommandText.SetText("Wait");

            RoadBool = true;
        }
        /*else
        {
            Debug.Log("Disabled (Road/Bollard)");
            CommandText.color = new Color32(255, 255, 255, 0); //Opacity 0
            CommandText.outlineColor = new Color32(0, 0, 0, 0); //Opacity 0
        }*/


        //TRAFFIC LIGHTS - Stop, Wait (for light sprite to change), Cross
        if (collision2D.gameObject.tag == "TLCol")
        {
            TL_Anim.SetBool("IsTriggered", true);

            Debug.Log("Stop (Traffic Lights)");
            CommandText.color = Purple;
            CommandText.outlineWidth = 0.2f;
            CommandText.outlineColor = new Color32(0, 0, 0, 255);

            Secs = 3; //Matches the length of the lights animation
            Trigger = true; //Sets the timer to count down
            Debug.Log("Timer Started");
            TLBool = true;
        }
        /*else
        {
            Debug.Log("Disabled (Traffic Lights)");
            CommandText.color = new Color32(255, 255, 255, 0); //Opacity 0
            CommandText.outlineColor = new Color32(0, 0, 0, 0); //Opacity 0
        }*/


        //STAIRS - Stop, Stairs
        if (collision2D.gameObject.tag == "StairsCol")
        {
            Debug.Log("Stop (Stairs)");
            CommandText.color = Green;
            CommandText.outlineWidth = 0.2f;
            CommandText.outlineColor = new Color32(0, 0, 0, 255);

            Secs = 3; //Stairs will alwasys need a 3 second wait
            Trigger = true; //Sets the timer to count down
            Debug.Log("Timer Started");
            CommandText.SetText("Stop");

            StairsBool = true;
        }
        /*else
        {
            Debug.Log("Disabled (Stairs)");
            CommandText.color = new Color32(255, 255, 255, 0); //Opacity 0
            CommandText.outlineColor = new Color32(0, 0, 0, 0); //Opacity 0
        }*/
    }
}
