using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrappleHook.util;
public class boxSounds : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField]AudioSource audioSource;
    [SerializeField]AudioSource dropSource;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rigid.velocity.x > 0.1 || rigid.velocity.x < -0.1)
        {
            if (!audioSource.isPlaying) audioSource.Play();
            //float _volumen = rigid.velocity.x;


        }
        else audioSource.Pause();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(Config.TAG_SOLID))
        {
            dropSource.pitch = Random.Range(0.6f, 1f);
            dropSource.Play();
        }
    }
}
