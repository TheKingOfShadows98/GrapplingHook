using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrappleHook.util;
public class GetTool : MonoBehaviour
{
    [SerializeField] private PowerUps buff;
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Config.TAG_PLAYER))
        {
            GameManager.instance.powerUps[buff] = true;
            Destroy(gameObject);
        }
    }
}
