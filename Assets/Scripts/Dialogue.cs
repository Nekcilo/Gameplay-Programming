using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    //Prefab References
    [SerializeField] private GameObject Pavement_Prefab;
    [SerializeField] private GameObject Road_Prefab;
    [SerializeField] private GameObject Stair_Prefab;
    [SerializeField] private GameObject Bollard_Prefab;
    [SerializeField] private GameObject TrafficLight_Prefab;

    [SerializeField] private TMP_Text DialogueText;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("RAAAAAAAAAAAAAAAH");
        
        if (collision.gameObject.tag == "Pavement")
        {
            Debug.Log("Player has entered a Pavement block");
        }

        if (collision.gameObject.tag == "Road")
        {
            Debug.Log("Player has entered a Road block");
        }

        if (collision.gameObject.tag == "Stairs")
        {
            Debug.Log("Player has entered a Stair block");
        }

        if (collision.gameObject.tag == "Bollard")
        {
            Debug.Log("Player has entered a Bollard block");
        }

        if (collision.gameObject.tag == "TrafficLights")
        {
            Debug.Log("Player has entered a Traffic Light block");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
