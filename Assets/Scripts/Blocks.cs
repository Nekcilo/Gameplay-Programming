using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    string[] Type = { "Pavement", "Road", "Bollard", "TrafficLights", "Stairs" };
    [SerializeField] private GameObject Pavement_Prefab;
    [SerializeField] private GameObject Road_Prefab;
    [SerializeField] private GameObject Stair_Prefab;
    [SerializeField] public GameObject Bollard_Prefab;
    [SerializeField] public GameObject TrafficLight_Prefab;
    int num = 0;
    int rounds = 20;
    
    void help(int i) //CURRENTLY NOT BEING CALLED
    {
      num = Random.Range(0, Type.Length);
      Debug.Log("The random block is " + Type[num]);
      Debug.Log("Round " + (i+1));
    }
    
    public void Spawn()
    {
      for (int i = 0; i < rounds; i++) //C# alt to 'for i in range'
      {
        Debug.Log(i);

        if (num == 0) //Pavement
        {
          Instantiate(Pavement_Prefab, new Vector3(i * 18f, 0, 0), Quaternion.identity);
          Debug.Log("Spawn Pavement");
        }
        if (num == 1) //Road
        {
          Instantiate(Road_Prefab, new Vector3(i * 18f, 0, 0), Quaternion.identity);
          Debug.Log("Spawn Road");
        }
        if (num == 2) //Bollard
        {
          Instantiate(Bollard_Prefab, new Vector3(i * 18f, 0, 0), Quaternion.identity);
          Debug.Log("Spawn Bollard");
        }
        if (num == 3) //Traffic Lights
        {
          Instantiate(TrafficLight_Prefab, new Vector3(i * 18f, 0, 0), Quaternion.identity);
          Debug.Log("Spawn Traffic Light");
        }
        if (num == 4) //Stairs
        {
          Instantiate(Stair_Prefab, new Vector3(i * 18f, 0, 0), Quaternion.identity);
          Debug.Log("Spawn Stairs");
        }
        //Instantiate(X_Prefab, new Vector3(i * 18f, 0, 0), Quaternion.identity);
        //Debug.Log("Spawn X");
        help(i);
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
