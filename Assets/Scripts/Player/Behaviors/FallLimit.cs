using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrappleHook.util;

public class FallLimit : MonoBehaviour
{
    Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector3 velocity = rig.velocity;
        if(Mathf.Abs(velocity.y) > Config.FALL_SPEED_LIMIT)
        {
            velocity.y = velocity.y > 0 ? Config.FALL_SPEED_LIMIT : -Config.FALL_SPEED_LIMIT;
        }
        rig.velocity = velocity;
    }
}
