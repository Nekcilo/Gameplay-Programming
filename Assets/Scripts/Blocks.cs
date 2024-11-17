using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    string[] Type = { "Pavement", "Stairs", "Road", "Bollard", "TrafficLights" };
    [SerializeField] public GameObject Block_Prefab;
    
    public void Spawn()
    {
        Instantiate(Block_Prefab, new Vector3(5.0f, 0, 0), Quaternion.identity);
        Debug.Log("Spawn");
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
