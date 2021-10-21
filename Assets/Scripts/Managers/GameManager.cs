using GrappleHook.util;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameStates gameState;
    public Dictionary<PowerUps, bool> powerUps;
    public GameObject jugador;

    private void Awake()
    {
        instance = instance == null ? this : instance;
        gameState = GameStates.mainmenu;
        powerUps = new Dictionary<PowerUps, bool>() { { PowerUps.Betsy, false }, { PowerUps.Guantes, true }, { PowerUps.Hook, false} };
    }

    private void Update()
    {
        
        if (Input.GetButtonDown(Config.BUTTON_PAUSE))
        {
            Application.Quit();
        }
        
    }

    /// <summary>Set TimeScale to 0 or 1 and GameState to pause or playing </summary><param name="_pause"> true : pause, false : continue</param>
    public void PauseGame(bool _pause = true)
    {
        gameState = _pause ? GameStates.pause : GameStates.playing;
    }
}

