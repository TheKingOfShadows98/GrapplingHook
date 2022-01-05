using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweep : MonoBehaviour
{
    [SerializeField] GameObject hitBox;
    [SerializeField] private float cd;
    [SerializeField] private float offTime;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource audioSource;

    private float time;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }

    bool ready()
    {
        return time <= Time.time; 
    }
    private void Stop()
    {
       hitBox.SetActive(false);
    }
    private void Attack()
    {
        anim.SetTrigger("Play");
        audioSource.Stop();
        audioSource.Play();
        time = Time.time + cd;
        hitBox.SetActive(true);
        Invoke("Stop", offTime);
    }
}
