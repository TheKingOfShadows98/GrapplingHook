using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldBetsyCC : MonoBehaviour
{
    const string TOOL_INPUT = "inputTool";
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private float cd;
    [SerializeField] private AudioSource audio;
    private float timer;

    private void Update()
    {
        if (Input.GetButtonDown(TOOL_INPUT) && isReady())
        {
            SpawnProyectil();
        }
    }
    private bool isReady()
    {
        return timer <= Time.time;
    }
    private void SpawnProyectil()
    {
        float _pitch = 1 + Random.Range(-0.1f, 0.1f);
        audio.pitch = _pitch;
        audio.Stop();
        audio.Play();
        GameObject _proyectil = Instantiate(proyectilPrefab, gameObject.transform);
        _proyectil.transform.parent = null;
        timer = Time.time + cd;
    }

}
