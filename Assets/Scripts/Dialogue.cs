using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using Unity.Collections;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    //TMP_Text References
    [SerializeField] TMP_Text BlockText;
    [SerializeField] TMP_Text CommandText;
    [SerializeField] TextMeshProUGUI DebugText;

    //Information for the TrafficLight Animation
    Animator TL_Anim;
    public GameObject[] AnimArray;
    int TLCount = 0;

    //COLOURS
    Color Red = new Color32(237, 128, 153, 255); //RGBA
    Color Orange = new Color32(251, 107, 29, 255); //RGBA
    Color Green = new Color32(145, 219, 105, 255); //RGBA
    Color Blue = new Color32(77, 155, 230, 255); //RGBA
    Color Purple = new Color32(168, 132, 243, 255); //RGBA
    Color Pink = new Color32(240, 79, 120, 255); //RGBA

    bool Trigger = false;
    float Secs;
    float FixedSecs;
    bool PavementBool = false;
    bool RoadBool = false;
    bool TLBool = false;
    bool StairsBool = false;

    //Movement Detection Variables
    bool IsMoving = false;
    bool PlayerMoved = false;
    bool TriggerEnd = false;
    bool MovementEvent = false;

    float SecsButASecondTime = 1f;

    //SCORING VARIABLES
    public int GoodScore = 0;
    public int BadScore = 0;
    public int EventCount = 0;

    void MovingCheck()
    {
        if (Input.GetAxisRaw("Horizontal") <= 0)
        {
            IsMoving = false;
        } 
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            IsMoving = true;
        }
    }

    void TextReset()
    {
        //Hides previous command text on new block entered
        CommandText.color = new Color32(255, 255, 255, 0);
        CommandText.outlineWidth = 0.2f;
        CommandText.outlineColor = new Color32(0, 0, 0, 0);
    }

    void BlockTextOutline()
    {
        BlockText.outlineWidth = 0.2f;
        BlockText.outlineColor = new Color32(255, 255, 255, 255);
    }

    void CommandTextOutline()
    {
        CommandText.outlineWidth = 0.2f;
        CommandText.outlineColor = new Color32(0, 0, 0, 255);
    }

    void Timer()
    {
        if(TLBool == true)
        {
            Secs = 2.5f;
            Debug.Log("Timer Length:" + Secs);
            MovementEvent = false;
            Trigger = true; //Sets the timer to count down
            Debug.Log("Timer Started");
        }
        if(StairsBool == true)
        {
            Secs = 3;
            Debug.Log("Timer Length:" + Secs);
            MovementEvent = false;
            Trigger = true; //Sets the timer to count down
            Debug.Log("Timer Started");
        }
        else if (PavementBool == true || RoadBool == true)
        {
            Secs = Random.Range(1, 5); //1 to 5
            Debug.Log("RANDOM Timer Length:" + Secs);
            MovementEvent = false;
            Trigger = true; //Sets the timer to count down
            Debug.Log("Timer Started");
        }
        FixedSecs = Secs - 0.3f;
        Debug.Log("FixedSecs Length:" + FixedSecs);
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
        MovingCheck();

        if (Trigger == true)
        {
            //Makes the timer count down in whole numbers
            DebugText.SetText((System.Math.Truncate(Secs)).ToString());
            //Timer Counting Down
            Secs -= Time.deltaTime;

            //Checks if the player moved at all during the timer
            if (Secs < FixedSecs) 
            {
                if (IsMoving == true)
                {
                    PlayerMoved = true;
                }
            }

            //After timer has finished:
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
                   TLCount++;
                }
                if (StairsBool == true)
                {
                   CommandText.SetText("Stairs"); //Sets text to stairs once timer is finished, if stairsbool is true
                   StairsBool = false;
                }

                if (PlayerMoved == true)
                    {
                        Debug.Log("BAD SCORE");
                        BadScore++;
                        PlayerMoved = false;
                    }
                    else if (PlayerMoved == false)
                    {
                        Debug.Log("GOOD SCORE");
                        GoodScore++;
                    }

                /*if (MovementEvent == false)
                {
                    if (PlayerMoved == true)
                    {
                        Debug.Log("BAD SCORE");
                        BadScore++;
                        PlayerMoved = false;
                    }
                    else if (PlayerMoved == false)
                    {
                        Debug.Log("GOOD SCORE");
                        GoodScore++;
                    }
                }
                else if (MovementEvent == true)
                {
                    if (PlayerMoved == true)
                    {
                        Debug.Log("GOOD SCORE");
                        GoodScore++;
                    }
                    else if (PlayerMoved == false)
                    {
                        Debug.Log("BAD SCORE");
                        BadScore++;
                        PlayerMoved = false;
                    }
                }*/

                EventCount++;
                TriggerEnd = true;
            }
        }

        if (TriggerEnd == true)
        {
            //Makes the timer count down in whole numbers
            DebugText.SetText((System.Math.Truncate(SecsButASecondTime)).ToString());
            //Timer Counting Down
            SecsButASecondTime -= Time.deltaTime;

            if (IsMoving == true)
            {
                PlayerMoved = true;
            }

            if (SecsButASecondTime <= 0)
            {
                if (PlayerMoved == true)
                {
                    Debug.Log("Movement GOOD SCORE");
                    GoodScore++;
                    TriggerEnd = false;  
                    SecsButASecondTime = 1;
                }
                else if (PlayerMoved == false)
                {
                    Debug.Log("Movement BAD SCORE");
                    BadScore++;
                    TriggerEnd = false;
                    SecsButASecondTime = 1;
                }
                EventCount++;
                PlayerMoved = false;
            }

            /*//Trigger = true;
            //MovementEvent = true;
            if (IsMoving == true)
            {
                Debug.Log("Movement GOOD SCORE");
                GoodScore++;
                TriggerEnd = false;
                EventCount++;
            }
            if (IsMoving == false)
            {
                Debug.Log("Movement BAD SCORE");
                BadScore++;
                TriggerEnd = false;
                EventCount++;
            }*/
        }
    }

    void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.tag == "Pavement")
        {   
            TextReset();

            BlockText.color = Pink;
            BlockTextOutline();

            BlockText.SetText("Pavement");
        }

        if (collision2D.gameObject.tag == "Road")
        {
            TextReset();

            BlockText.color = Orange;
            BlockTextOutline();

            BlockText.SetText("Road");
        }

        if (collision2D.gameObject.tag == "Stairs")
        {
            TextReset();

            BlockText.color = Green;
            BlockTextOutline();

            BlockText.SetText("Stairs");
        }

        if (collision2D.gameObject.tag == "Bollard")
        {
            TextReset();

            BlockText.color = Blue;
            BlockTextOutline();

            BlockText.SetText("Bollard");
        }

        if (collision2D.gameObject.tag == "TrafficLights")
        {
            AnimArray = GameObject.FindGameObjectsWithTag("TLLights"); //The animation looks better when this code is here
            TL_Anim = AnimArray[TLCount].GetComponent<Animator>();

            TextReset();

            BlockText.color = Purple;
            BlockTextOutline();

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
                CommandTextOutline();
                
                PavementBool = true;
                Timer();
                CommandText.SetText("Wait");

            }
            else if (Random.Range(1, 3) == 2) // 1 or 2
            {
                Debug.Log("Print Nothing (Pavement)");
                CommandText.SetText("[Do Nothing]");
                TextReset();
            }   
        }       

        //ROAD + BOLLARD - Stop, Wait (2-5 Seconds, Random), Cross
        if (collision2D.gameObject.tag == "RoadCol")
        {
            Debug.Log("Stop (Road/Bollard)");
            CommandText.color = Orange;
            CommandTextOutline();

            RoadBool = true;
            Timer();
            CommandText.SetText("Wait");
        }
 
        //TRAFFIC LIGHTS - Stop, Wait (for light sprite to change), Cross
        if (collision2D.gameObject.tag == "TLCol")
        {
            TL_Anim.SetBool("IsTriggered", true);

            Debug.Log("Stop (Traffic Lights)");
            CommandText.color = Purple;
            CommandTextOutline();

            TLBool = true;
            Timer();
        }

        //STAIRS - Stop, Stairs
        if (collision2D.gameObject.tag == "StairsCol")
        {
            Debug.Log("Stop (Stairs)");
            CommandText.color = Green;
            CommandTextOutline();

            StairsBool = true;
            Timer();
            CommandText.SetText("Stop");
        }
    }
}
