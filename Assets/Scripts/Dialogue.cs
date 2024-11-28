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

    //COLOURS
    Color Red = new Color32(237, 128, 153, 255); //RGBA
    Color Orange = new Color32(251, 107, 29, 255); //RGBA
    Color Green = new Color32(145, 219, 105, 255); //RGBA
    Color Blue = new Color32(77, 155, 230, 255); //RGBA
    Color Purple = new Color32(168, 132, 243, 255); //RGBA
    Color Pink = new Color32(240, 79, 120, 255); //RGBA

    void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.tag == "Pavement")
        {
            Debug.Log("Player has entered a Pavement block");

            DialogueText.color = Pink;
            DialogueText.outlineWidth = 0.2f;
            DialogueText.outlineColor = new Color32(255, 255, 255, 255);

            DialogueText.SetText("Pavement");
        }

        if (collision2D.gameObject.tag == "Road")
        {
            Debug.Log("Player has entered a Road block");

            DialogueText.color = Orange;
            DialogueText.outlineWidth = 0.2f;
            DialogueText.outlineColor = new Color32(255, 255, 255, 255);

            DialogueText.SetText("Road");
        }

        if (collision2D.gameObject.tag == "Stairs")
        {
            Debug.Log("Player has entered a Stair block");

            DialogueText.color = Green;
            DialogueText.outlineWidth = 0.2f;
            DialogueText.outlineColor = new Color32(255, 255, 255, 255);

            DialogueText.SetText("Stairs");
        }

        if (collision2D.gameObject.tag == "Bollard")
        {
            Debug.Log("Player has entered a Bollard block");

            DialogueText.color = Blue;
            DialogueText.outlineWidth = 0.2f;
            DialogueText.outlineColor = new Color32(255, 255, 255, 255);

            DialogueText.SetText("Bollard");
        }

        if (collision2D.gameObject.tag == "TrafficLights")
        {
            Debug.Log("Player has entered a Traffic Light block");

            DialogueText.color = Purple;
            DialogueText.outlineWidth = 0.2f;
            DialogueText.outlineColor = new Color32(255, 255, 255, 255);

            DialogueText.SetText("Traffic Lights");
        }
    }

    void Awake()
    {

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
