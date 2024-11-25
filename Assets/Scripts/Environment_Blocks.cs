using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Environment_Blocks : MonoBehaviour
{
    //Prefab References
    [SerializeField] private GameObject Pavement_Prefab;
    [SerializeField] private GameObject Road_Prefab;
    [SerializeField] private GameObject Stair_Prefab;
    [SerializeField] private GameObject Bollard_Prefab;
    [SerializeField] private GameObject TrafficLight_Prefab;

    //BoundingBox References
    [SerializeField] private GameObject BoundingBox;
    [SerializeField] private GameObject BB_Left;
    [SerializeField] private GameObject BB_Right;
    private Vector3 scaleChange, positionChange;

    //Lists to track which blocks can be spawned
    List<string> PavementList = new List<string>() {"Pavement", "Road", "Stairs"};
    List<string> RoadList = new List<string>() {"Pavement", "Bollard", "TrafficLights", "Stairs"};
    List<string> BollardList = new List<string>() {"Road"};
    List<string> TrafficLightList = new List<string>() {"Road"};
    List<string> StairsList = new List<string>() {"Pavement"};

    //Standard Variables
    float X_Constant = 18f;
    float Y_Constant = 2.24f;
    int StairsCount = 0;
    int block_num = 0;
    public int rounds = 20;

    //Makes the 'first' block spawned always be Pavement
    string Previous = "Pavement";
    string Spawn_Choice;
    
    public void Spawn()
    {
      for (int i = 1; i < rounds;) //C# alt to 'for i in range'
      {
        Debug.Log("For loop number " + i);

        switch(Previous)
        {
          case "Pavement":
          block_num = Random.Range(0, 3);
          Spawn_Choice = PavementList[block_num];
          break;

          case "Road":
          block_num = Random.Range(0, 4); //includes stairs for testing
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
          Instantiate(Pavement_Prefab, new Vector3(i * X_Constant, StairsCount * Y_Constant, 0), Quaternion.identity);
          Debug.Log("Spawn Pavement");
          break;

          case "Road":
          Instantiate(Road_Prefab, new Vector3(i * X_Constant, StairsCount * Y_Constant, 0), Quaternion.identity);
          Debug.Log("Spawn Road");
          break;

          case "Bollard":
          Instantiate(Bollard_Prefab, new Vector3(i * X_Constant, StairsCount * Y_Constant, 0), Quaternion.identity);
          Debug.Log("Spawn Bollard");
          break;

          case "TrafficLights":
          Instantiate(TrafficLight_Prefab, new Vector3(i * X_Constant, StairsCount * Y_Constant, 0), Quaternion.identity);
          Debug.Log("Spawn Traffic Light");
          break;

          case "Stairs":
          Instantiate(Stair_Prefab, new Vector3(i * X_Constant, StairsCount * Y_Constant, 0), Quaternion.identity);
          Debug.Log("Spawn Stairs");
          StairsCount++;
          break;

          default:
          Instantiate(Pavement_Prefab, new Vector3(i * X_Constant, StairsCount * Y_Constant, 0), Quaternion.identity);
          Debug.Log("Spawn DEFAULT Pavement");
          break;
        }

        Previous = Spawn_Choice;
        i++;
      }
      //Main BoundingBox, To stop the camera
      //Scales horizontally with the level blocks, scales vertically from the amount of stairs that spawn
      //Moves Horizontally to be centred with the level
        scaleChange = new Vector3(((rounds - 1) * X_Constant), (StairsCount * Y_Constant), 0f);
        positionChange = new Vector3(((rounds - 1) * (X_Constant / 2)), (StairsCount * (Y_Constant / 2)), 0f); //has to be divided by 2 to only scale it on the right/top respectively
        BoundingBox.transform.localScale += scaleChange;
        BoundingBox.transform.position += positionChange;

      //Left bounding box, to stop the player from falling off (left)
      //Scales vertically from the amount of stairs that spawn
        scaleChange = new Vector3(0f, (StairsCount * Y_Constant), 0f);
        positionChange = new Vector3(0f , (StairsCount * (Y_Constant / 2)), 0f);
        BB_Left.transform.localScale += scaleChange;
        BB_Left.transform.position += positionChange;

      //Right bounding box, to stop the player from falling off (right)
      //Scales vertically from the amount of stairs that spawn
      //Moves horizontally to be at the end of the level
        scaleChange = new Vector3(0f, (StairsCount * Y_Constant), 0f);
        positionChange = new Vector3(((rounds * X_Constant) + 2), (StairsCount * (Y_Constant / 2)), 0f);
        BB_Right.transform.localScale += scaleChange;
        BB_Right.transform.position += positionChange;
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
