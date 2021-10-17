using GrappleHook.util;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Config.TAG_PLAYER))
        {
            collision.gameObject.GetComponent<PlayerController>().AddPen();
            Destroy(gameObject);
        }
    }
}