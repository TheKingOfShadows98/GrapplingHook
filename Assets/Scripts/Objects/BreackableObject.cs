using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreackableObject : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float delayDestroy;
    [SerializeField] private bool isPersistantState;

    private void Start()
    {
        if (isPersistantState)
        {
            int a = PlayerPrefs.GetInt(gameObject.name);
            if (a == 0) Destroy(gameObject);
        }

    }
    [ContextMenu("Romper")]
    public void Impact()
    {
        audioSource.Stop();
        audioSource.Play();
        particles.Play();

        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        if (isPersistantState) PlayerPrefs.SetInt(gameObject.name, 0);

        Destroy(gameObject, delayDestroy);
    }
}
