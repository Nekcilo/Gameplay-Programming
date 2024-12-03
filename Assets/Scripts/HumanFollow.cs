using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanFollow : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField] Rigidbody2D Body;

    // Update is called once per frame
    /*void FixedUpdate()
    {
        //Vector2 TargetPosition = new Vector2(Target.transform.position.x, transform.position.y); //-2.783624f
        transform.position = new Vector2(Target.transform.position.x, 0f);
        //Vector2.MoveTowards(transform.position, TargetPosition, 15 * Time.deltaTime);
        Debug.Log("HUMAN:" + transform.position.y);
    }*/

    void FixedUpdate()
    {
        if(Body.velocity.x < 5 && Body.velocity.x > -5)
        {
            Body.AddForce(new Vector2(Target.transform.position.x * 15, 0f), ForceMode2D.Impulse);
        }
        Debug.Log("HUMAN:" + transform.position.y);
    }
}
