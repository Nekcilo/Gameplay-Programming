using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Environment_Blocks
{
    //int X_Position;
    //int Y_Position;
    string Type

    void Spawn()
    {

    }

    void Detector()
    {

    }
}

public class Environment : MonoBehaviour
{
    public TMP_Text Textblocks;

    string[] blocks = {"Pavement", "Stairs", "Road", "Bollard", "TrafficLights"};
    List<int> blocks2 = new List<int>() {0, };
    //int[] blocks2 = {0,};
    //Pavement = 0, Stairs = 1, Road = 2, Bollard = 3, TrafficLights = 4

    int num = 0;
    int rounds = 20;

    void help(int i)
    {
        Debug.Log(blocks[num]);
        Textblocks.text = blocks[num];
        num = Random.Range(0, blocks.Length);
        blocks2.Add(num);
        Debug.Log(i);
        Debug.Log("Round" + i);
    }

    void BlockSpawn()
    {
        for (int i = 0; i < rounds; i++) //C# alt to 'for i in range'
        {
            if (num == 0 && blocks2[i] == 0) //Checking if 'i' is equal to 0 (Pavement)
            {

                num = Random.Range(0, blocks.Length);

                /*if (num == 0 && blocks2[i] == 0) //Checking if 'i' is equal to 0 (Pavement)
                {
                    debug();
                    Debug.Log("Round 2");
                }
                if (num == 1 && blocks2[i] == 1) //Stairs
                {
                    debug();
                    Debug.Log("Round 2");
                }
                if (num == 2 && blocks2[i] == 2) //Road
                {
                    debug();
                    Debug.Log("Round 2");
                }
                if (num == 4 && blocks2[i] == 4) //Traffic Lights
                {
                    debug();
                    Debug.Log("Round 2");
                }*/
                //Then Pavement, Stairs, Road and TrafficLights can spawn
            }
            if (num == 1 && blocks2[i] == 1) //Stairs
            {
                //Then Pavement and Stairs can spawn
            }
            if (num == 2 && blocks2[i] == 2) //Road
            {
                //Then Pavement, Road, Bollard and TrafflicLights can spawn
            }
            if (num == 3 && blocks2[i] == 3) //Bollard
            {
                //Then ONLY Road can spawn
            }
            if (num == 4 && blocks2[i] == 4) //Traffic Lights
            {
                //Then ONLY Road can spawn
            }
            help(i);
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
