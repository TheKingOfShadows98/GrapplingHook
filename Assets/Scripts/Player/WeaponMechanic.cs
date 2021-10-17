using GrappleHook.util;
using UnityEngine;

public class WeaponMechanic : MonoBehaviour
{
    [SerializeField, Tooltip("Controlador del Jugador")] private PlayerController playerController;
    [SerializeField, Tooltip("Posicion con respecto al jugador")] private Vector2 weaponPosition;
    [SerializeField, Tooltip("Objeto del Arma")] private GameObject weapon;
    [SerializeField, Tooltip("Objeto de la bala")] private GameObject bullet;

    private void Start()
    {
    }

    private void OnEnable()
    {
        if (!playerController) playerController = GetComponent<PlayerController>();
        weapon.SetActive(true);
    }

    private void OnDisable()
    {
        weapon.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.instance.gameState != GameStates.playing) return;
        // Activacion del disparo cuando se presiona el hotkey "Action"
        if (Input.GetButtonDown(Config.BUTTON_ACTION))
        {
            Fire();
        }
        // mueve el arma hacia donde este mirando el jugador
        if (playerController.GetFacing() > 0)
        {
            weapon.transform.rotation = Quaternion.Euler(0, 0, 0);
            weapon.transform.position = transform.position + (Vector3)weaponPosition;
        }
        else
        {
            weapon.transform.rotation = Quaternion.Euler(0, -180, 0);
            weapon.transform.position = transform.position - (Vector3)weaponPosition;
        }
    }

    private void Fire()
    {
        // crea una bala
        var nbullet = Instantiate(bullet, weapon.transform);
        // quita el parent de la bala
        nbullet.transform.parent = null;
        nbullet.transform.position = weapon.transform.position;
        nbullet.transform.localScale = Vector3.one;
        // alinea la rotacion con respecto al arma
        nbullet.transform.rotation = weapon.transform.rotation;
    }
}