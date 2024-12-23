using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerColliderScript : MonoBehaviour
{
    [SerializeField] private GameObject Player_BB;
    int StairsCount = 5;
    float X_Constant = 0.2f;
    float Y_Constant = 10f;
    int Increase = 0;
    private Vector3 scaleChange, positionChange;

    void Scaling()
    {
        Increase++;
        //Bounding Box to 'follow' behind the player, stops them from going backwards
        scaleChange = new Vector3((Increase * X_Constant), (StairsCount * Y_Constant), 0f);
        positionChange = new Vector3(((Increase * (X_Constant / 2)) - 20f), ((StairsCount /2) * Y_Constant), 0f); //has to be divided by 2 to only scale it on the right/top respectively (StairsCount * (Y_Constant / 2))
        Player_BB.transform.localScale = scaleChange; //Player_BB.transform.localScale += scaleChange;
        Player_BB.transform.position = positionChange;  //Player_BB.transform.position += positionChange; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Scaling();
        } 
    }

    // Start is called before the first frame update
    void Start()
    {       
    }
}
