using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embestida : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private float timer;
    [SerializeField] private LayerMask collisionMasks;
    [SerializeField] private float speed;
    [SerializeField] private ParticleSystem particles;

    [ContextMenu("a")]
    public void test()
    {
        startEmbestida();
    }

    public void startEmbestida(float _time = 3f, float _speed = 10f)
    {
        timer = Time.time + _time;
        speed = _speed;
        particles.Play();
    }
    private void FixedUpdate()
    {
        if (timer >= Time.time)
        {
            rigid.velocity = new Vector2(speed * transform.right.x, rigid.velocity.y);
            if (WallinFront())
            {
                timer = Time.time;
                rigid.velocity = new Vector2(speed/4 * -transform.right.x, speed/2 * Vector2.up.y);
            }
        }
        else if (particles.isPlaying) particles.Stop();
    }
    private bool WallinFront() { 
        RaycastHit2D hit = Physics2D.Linecast(
            transform.position,
            (Vector2)transform.position + new Vector2(transform.right.x * 1.5f, 0f),
            collisionMasks
            );
        if(hit.collider != null)
        {
            return true;
        }
        return false;
    }
}
