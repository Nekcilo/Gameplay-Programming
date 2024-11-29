using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField] Rigidbody2D Body;
    public float moveSpeed;
    private float moveHorizontal;
    private bool left;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal"); 
        if (Input.GetAxisRaw("Horizontal") > -1.5 && Input.GetAxisRaw("Horizontal") < 0)
        {
            Debug.Log("Left");
            moveSpeed = 1;
        } 
        else
        {
            moveSpeed = 15;
        }
    }

    void FixedUpdate()
    {
        if(Body.velocity.x < 5 && Body.velocity.x > -5)
        {
            Body.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }
        Debug.Log("DOG:" + transform.position.y);
    }
}