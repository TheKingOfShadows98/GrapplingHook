using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSounds : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play();
    }
}
