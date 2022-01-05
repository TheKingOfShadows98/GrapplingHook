using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldBetsiProyectil : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float lifeTime = 3f;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private AudioSource audio;
    private float time;

    private void Start()
    {
        time = Time.time + lifeTime;
    }
    private void FixedUpdate()
    {
        if(time - Time.time >= lifeTime * 0.9f)
        {
            rigid.velocity = transform.right.normalized * speed;
        }
        
        if (time <= Time.time)
        {
            Die();
        }
    }
    private void Die()
    {
        particles.Play();
        particles.gameObject.transform.parent = null;
        audio.Play();
        Destroy(particles.gameObject, 2f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("BreakableObject"))
        {
            try
            {
                collision.GetComponent<BreackableObject>().Impact();
            }
            catch
            {
                Debug.Log("no era él");
            }
        }
        Die();
    }
}
