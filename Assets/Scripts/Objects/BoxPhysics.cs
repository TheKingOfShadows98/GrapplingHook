using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrappleHook.util;


public class BoxPhysics : MonoBehaviour
{
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        BoxUpdateEvent.onActivePhysics += ActiveRigid;
        BoxUpdateEvent.onDeactivePhysics += DeactiveRigid;
    }

    private void OnDisable()
    {
        BoxUpdateEvent.onActivePhysics -= ActiveRigid;
        BoxUpdateEvent.onDeactivePhysics -= DeactiveRigid;
    }
    private void ActiveRigid()
    {
        rigid.bodyType = RigidbodyType2D.Dynamic;
    }
    private void DeactiveRigid()
    {
        rigid.bodyType = RigidbodyType2D.Static;
    }

}
