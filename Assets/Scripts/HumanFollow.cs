using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanFollow : MonoBehaviour
{
    [SerializeField] GameObject Target;

    // Update is called once per frame
    void Update()
    {
        Vector2 TargetPosition = new Vector2(Target.transform.position.x, -3.192613f);
        transform.position = Vector2.MoveTowards(transform.position, TargetPosition, 15 * Time.deltaTime);
    }
}
