using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField] Rigidbody2D Body;
    [SerializeField] GameObject Human;
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
            moveSpeed = 10;
        }
    }

    void FixedUpdate()
    {
        /*if(Body.velocity.x < 5 && Body.velocity.x > -5)
        {
            Body.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }*/
        transform.position = new Vector2(transform.position.x + (Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime), transform.position.y);
        
        Human.transform.position = new Vector2(transform.position.x - 0.5f, Human.transform.position.y);
    }
}