using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrappleHook.util;
using UnityEngine.SceneManagement;

public class CambiarNivel : MonoBehaviour
{
    [SerializeField] string nextLeve;
    [SerializeField] Vector2 position;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Config.TAG_PLAYER))
        {
            try
            {
                SceneManager.LoadScene(nextLeve);
                GameManager.instance.jugador.transform.position = position;
            }
            catch { Debug.Log("LA ESCENA NO EXISTE WEY"); }
        }
    }
}
