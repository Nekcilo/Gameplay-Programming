using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    string[] blocks = {"Pavement", "Stairs", "Road", "Bollard", "TrafficLights"};


    void BlockSpawn()
    {
        int num = Random.Range(0, blocks.Length);
        Debug.Log(blocks[num]);

        //if (num == 0)
        //{
            //Then add the if statements for the blocks here
        //}
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
