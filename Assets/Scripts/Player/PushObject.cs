using System.Collections.Generic;
using UnityEngine;

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
        foreach (var block in Blocks)
        {
            if (block) block.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void DisableMoveBoxes()
    {
        foreach (var block in Blocks)
        {
            if (block) block.bodyType = RigidbodyType2D.Static;
        }
    }
}