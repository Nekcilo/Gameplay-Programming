using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] Dialogue dialogueScript; 
    [SerializeField] GameObject EndTriggerBox; 
    int TotalScore;

    // Start is called before the first frame update
    void Start()
    {
        //Dialogue dialogueScript = this.gameObject.GetComponent<Dialogue>();
        Debug.Log(dialogueScript.TestString);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject == EndTriggerBox)
        {
            //Rounds = GoodScore + BadScore
            //(Rounds/2)*10 to get 50%

            dialogueScript.GoodScore = (dialogueScript.GoodScore * 10); //Each good point earnt = 10
            dialogueScript.BadScore = (dialogueScript.BadScore * 5); //Each bad point earnt = 5
            TotalScore = dialogueScript.GoodScore - dialogueScript.BadScore; //GoodScore minus BadScore to get the total score
            Debug.Log("Final Score: " + TotalScore);

            //if TotalScore>50% = good
            //if TotalScore<50% = bad
        }
    }
}
