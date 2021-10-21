using System.Collections.Generic;
using UnityEngine;
using GrappleHook.util;

public class PushObject : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private List<Rigidbody2D> Blocks;

    private void Awake()
    {
        playerController = !playerController ? GetComponent<PlayerController>() : playerController;
    }

    public void EnableMoveBoxes()
    {
        BoxUpdateEvent.ActiveBoxPhysics();
    }

    public void DisableMoveBoxes()
    {
        BoxUpdateEvent.DeactiveBoxPhysics();
    }
}