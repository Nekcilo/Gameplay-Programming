using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Environment : MonoBehaviour
{
    public TMP_Text Textblocks;

    string[] blocks = {"Pavement", "Stairs", "Road", "Bollard", "TrafficLights"};
    //Pavement = 0, Stairs = 1, Road = 2, Bollard = 3, TrafficLights = 4

    int num = 0;

    void BlockSpawn()
    {
        //Currently: Prints Pavement first (correct), then prints only 1 option after no matter how many times its 'rerolled' (incorrect)
        if (num == 0) //Pavement
        {
            Debug.Log(blocks[num]);
            Textblocks.text = blocks[num];
            num = Random.Range(0, blocks.Length);
            //Then Pavement, Stairs, Road and TrafficLights can spawn
        }
        if (num == 1) //Stairs
        {
            Debug.Log(blocks[num]);
            Textblocks.text = blocks[num];
            //Then Pavement and Stairs can spawn
        }
        if (num == 2) //Road
        {
            Debug.Log(blocks[num]);
            Textblocks.text = blocks[num];
            //Then Pavement, Road, Bollard and TrafflicLights can spawn
        }
        if(num == 3) //Bollard
        {
            Debug.Log(blocks[num]);
            Textblocks.text = blocks[num];
            //Then ONLY Road can spawn
        }
        if (num == 4) //Traffic Lights
        {
            Debug.Log(blocks[num]);
            Textblocks.text = blocks[num];
            //Then ONLY Road can spawn
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            BlockSpawn();
        }
    }
}
