using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrapplingHook.Player;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [field: SerializeField] public GameObject Player { get; private set; }


    private void Awake()
    {
        Instance = !Instance ? this : Instance;
        if (Instance != this) Destroy(gameObject);
    }

    public Vector2 GetPlayerPosition()
    {
        return Player.transform.position;
    }

    public float GetPlayerHeigth()
    {
        var result = Player.transform.position.y;
        result -= 0.5f;
        return result;
    }
}
