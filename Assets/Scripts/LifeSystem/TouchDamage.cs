using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDamage : MonoBehaviour
{
    public string TargetTag;
    public int damage;
    [SerializeField] ParticleSystem ps;
    [SerializeField] private string errorLog;

    private bool incollision;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TargetTag))
        {
            try
            {
                if (ps) ps.Play();
                collision.GetComponent<LifeController>().TakeDamage(damage);
                collision.transform.parent.gameObject.GetComponent<Rigidbody2D>().AddForce(
                    new Vector2(transform.right.normalized.x * 1f, 1f),
                    ForceMode2D.Impulse);
            }
            catch
            {
                Debug.Log(errorLog);
            }
        }
    }

}
