using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAura : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            Debug.Log("AHHHH");
            collision.gameObject.GetComponent<LifeController>().TakeDamage(damage);
        }
        catch { }
    }

}
