using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] Dialogue dialogueScript; 

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
}
