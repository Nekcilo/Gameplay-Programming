using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Environment_Blocks : MonoBehaviour
{
    [SerializeField] private GameObject Pavement_Prefab;
    [SerializeField] private GameObject Road_Prefab;
    [SerializeField] private GameObject Stair_Prefab;
    [SerializeField] private GameObject Bollard_Prefab;
    [SerializeField] private GameObject TrafficLight_Prefab;
    string[] Type = {"Pavement", "Road", "Bollard", "TrafficLights"}; //stairs not included
    List<int> Spawned = new List<int>() {0,};
    float X_Position = 18f;
    float Y_Position = 0f;
    int block_num = 0;
    public int rounds = 20;
    
    void Randomize(int i)
    {
      block_num = Random.Range(0, Type.Length);
      Spawned.Add(block_num);
      
      string result = "List contents: "; //printing Spawned contents
      foreach (var item in Spawned)
      {
        result += item.ToString() + " ";
      }
      Debug.Log(result);
    }
    
    public void Spawn()
    {
      for (int i = 0; i < rounds;) //C# alt to 'for i in range'
      {
        Debug.Log("For loop number " + i);

        //pavement - can spawn pavement, road, (stairs - currently disabled)
        //road - can spawn pavement, bollard, traffic lights
        //bollard + traffic lights - can spawn road
        //stairs - can spawn pavement
        if (Spawned[i] == 0) //pavement
        {
	        block_num = Random.Range(0, 1);

          switch(block_num)
          {
            default:
              Instantiate(Pavement_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
              Debug.Log("Spawn Pavement");
            break;

            case 1:
              Instantiate(Road_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
              Debug.Log("Spawn Road");
            break;
          }
        }

        if (Spawned[i] == 1) //road
        {
	        block_num = Random.Range(0, 2);

          switch(block_num)
          {
            default: //Pavement
              Instantiate(Pavement_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
              Debug.Log("Spawn Pavement");
            break;

            case 1: //Bollard
              Instantiate(Bollard_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
              Debug.Log("Spawn Bollard");
            break;

            case 2: //Traffic Lights
              Instantiate(TrafficLight_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
              Debug.Log("Spawn Traffic Light");
            break;

            case 3: //road
            Instantiate(Road_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
            Debug.Log("Spawn Road");
            break;
          }
        }

        if (Spawned[i] == 2) //bollard
        {
          block_num = Random.Range(0, 1);

          switch(block_num)
          {
            default: //road
            Instantiate(Road_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
            Debug.Log("Spawn Road");
            break;

            case 1: //Traffic Lights
              Instantiate(TrafficLight_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
              Debug.Log("Spawn Traffic Light");
            break;

            /*case 2: //Bollard
              Instantiate(Bollard_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
              Debug.Log("Spawn Bollard");
            break;*/
          }
        }

        if (Spawned[i] == 3) //traffic light
        {
          block_num = Random.Range(0, 2);

          switch(block_num)
          {
            default: //road
            Instantiate(Road_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
            Debug.Log("Spawn Road");
            break;

            case 1: //Bollard
              Instantiate(Bollard_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
              Debug.Log("Spawn Bollard");
            break;

            /*case 2: //Traffic Lights
              Instantiate(TrafficLight_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
              Debug.Log("Spawn Traffic Light");
            break;*/

          }
        }
        Randomize(i);
        i++;
      }
    }

    // Start is called before the first frame update
    void Start()
    {
      Spawn();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
