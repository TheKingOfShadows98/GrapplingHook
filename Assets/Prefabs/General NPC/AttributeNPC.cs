using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeNPC : MonoBehaviour
{
    public int Life { get; protected set; }
    public int Attack { get; protected set; }

    [SerializeField] Animator animator;

    public void takeDamage(int dmg)
    {
        Life -= dmg;
        if(Life <= 0)
        {
            Die();
        }
        else
        {
            try
            {
                animator.SetTrigger("TakeDamage");
            }
            catch
            {
                Debug.LogError("Animator not defined");
            }
        }
    }
    protected void Die()
    {
        try
        {
            animator.SetBool("Die", true);
        }
        catch
        {
            Debug.LogError("Animator not defined");
        }
    }
}
