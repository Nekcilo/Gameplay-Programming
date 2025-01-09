using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] Dialogue dialogueScript; 
    [SerializeField] GameObject EndTriggerBox; 
    int TotalScore;
    int MaxPossibleScore;
    int HalfThreshold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject == EndTriggerBox)
        {
            //Debug Checks
            Debug.Log("EventCount: " + dialogueScript.EventCount);
            Debug.Log("GoodCount: " + dialogueScript.GoodScore);
            Debug.Log("BadCount: " + dialogueScript.BadScore);

            MaxPossibleScore = dialogueScript.EventCount * 10;
            HalfThreshold = MaxPossibleScore/2;
            Debug.Log("Half Threshold: " + HalfThreshold);

            dialogueScript.GoodScore = (dialogueScript.GoodScore * 10); //Each good point earnt = 10
            dialogueScript.BadScore = (dialogueScript.BadScore * 5); //Each bad point earnt = 5
            TotalScore = dialogueScript.GoodScore - dialogueScript.BadScore; //GoodScore minus BadScore to get the total score
            Debug.Log("Final Score: " + TotalScore);

            if (TotalScore > HalfThreshold)
            {
                Debug.Log("GOOD FINAL SCORE");
            }
            if (TotalScore < HalfThreshold)
            {
                Debug.Log("BAD FINAL SCORE");
            }
        }
    }
}
