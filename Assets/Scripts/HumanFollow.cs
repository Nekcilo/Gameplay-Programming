using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanFollow : MonoBehaviour
{
    [SerializeField] GameObject Target;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 TargetPosition = new Vector2(Target.transform.position.x, transform.position.y); //-2.783624f
        transform.position = Vector2.MoveTowards(transform.position, TargetPosition, 15 * Time.deltaTime);
        Debug.Log("HUMAN:" + transform.position.y);
    }
}
