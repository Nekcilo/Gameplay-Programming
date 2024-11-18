using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Environment_Blocks : MonoBehaviour
{
    //inspector prefab references
    [SerializeField] private GameObject Pavement_Prefab;
    [SerializeField] private GameObject Road_Prefab;
    [SerializeField] private GameObject Stair_Prefab;
    [SerializeField] private GameObject Bollard_Prefab;
    [SerializeField] private GameObject TrafficLight_Prefab;

    //to keep track of the number + meaning
    string[] Type = {"Pavement", "Road", "Bollard", "TrafficLights"}; //stairs not included

    List<int> Spawned = new List<int>() {0,};

    List<string> PavementList = new List<string>() {"Pavement", "Road", "Stairs"};
    List<string> RoadList = new List<string>() {"Pavement", "Bollard", "TrafficLights"};
    List<string> BollardList = new List<string>() {"Road"};
    List<string> TrafficLightList = new List<string>() {"Road"};
    List<string> StairsList = new List<string>() {"Pavement"};

    //standard variables
    float X_Position = 18f;
    float Y_Position = 0f;
    int block_num = 0;
    public int rounds = 20;

    string Previous = "Pavement";
    string Spawn_Choice;
    
    void Randomize(int i)
    {
      //block_num = Random.Range(0, Type.Length);
      //Spawned.Add(block_num);
      
      /*string result = "List contents: "; //printing Spawned contents
      foreach (var item in Spawned)
      {
        result += item.ToString() + " ";
      }
      Debug.Log(result);*/
    }
    
    public void Spawn()
    {
      for (int i = 1; i < rounds;) //C# alt to 'for i in range'
      {
        Debug.Log("For loop number " + i);

        switch(Previous)
        {
          case "Pavement":
          block_num = Random.Range(0, 2);
          Spawn_Choice = PavementList[block_num];
          break;

          case "Road":
          block_num = Random.Range(0, 2);
          Spawn_Choice = RoadList[block_num];
          break;

          case "Bollard":
          Spawn_Choice = BollardList[0];
          break;

          case "TrafficLights":
          Spawn_Choice = TrafficLightList[0];
          break;

          case "Stairs":
          Spawn_Choice = StairsList[0];
          break;

          default:
          Spawn_Choice = PavementList[0];
          Debug.Log("DEFAULT");
          break;
        }

        switch(Spawn_Choice)
        {
          case "Pavement":
          Instantiate(Pavement_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
          Debug.Log("Spawn Pavement");
          break;

          case "Road":
          Instantiate(Road_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
          Debug.Log("Spawn Road");
          break;

          case "Bollard":
          Instantiate(Bollard_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
          Debug.Log("Spawn Bollard");
          break;

          case "TrafficLights":
          Instantiate(TrafficLight_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
          Debug.Log("Spawn Traffic Light");
          break;

          case "Stairs":
          Instantiate(Stair_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
          Debug.Log("Spawn Stairs");
          break;

          default:
          Instantiate(Pavement_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
          Debug.Log("Spawn DEFAULT Pavement");
          break;
        }

        Previous = Spawn_Choice;


        //OLD CODE

        /*if (Spawned[i] == 0) //pavement
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

            case 2: //Bollard
              Instantiate(Bollard_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
              Debug.Log("Spawn Bollard");
            break;
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

            case 2: //Traffic Lights
              Instantiate(TrafficLight_Prefab, new Vector3(i * X_Position, Y_Position, 0), Quaternion.identity);
              Debug.Log("Spawn Traffic Light");
            break;

          }
        }*/
        //Randomize(i);
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
