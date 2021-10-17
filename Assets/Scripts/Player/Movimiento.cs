using GrappleHook.util;
using System.Collections;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField, Tooltip("Controlador del Jugador")] private PlayerController playerController;

    [SerializeField, Tooltip("RigidBody 2d del Jugador")] public Rigidbody2D rig;

    [Header("Atributos")]
    [SerializeField, Tooltip("Unidades por segundo de desplazamiento")] private float speed;

    [SerializeField, Tooltip("Fuerza del salto")] private float jumpForce;
    [SerializeField, Tooltip("Altura Maxima del salto")] private float maxHeightJump;
    [SerializeField, Tooltip("Tiempo maximo en el aire")] private float jumpTime;

    [SerializeField, Tooltip("Posicion de los pies")] private Vector3 footPositonA;
    [SerializeField, Tooltip("Posicion de los pies")] private Vector3 footPositonB;

    [SerializeField, Tooltip("Layers interpretadas como suelos")] private LayerMask layersColliders;

    [Header("Variables [No Tocar, solo para info]")]
    [SerializeField, Tooltip("Coord del ultimo toque de algo solido"), ReadOnly] private float lastTouchGroundHigh;

    [SerializeField, Tooltip("Distancia de reconocimiento del suelo"), ReadOnly] private float jumpAreaDetection = 0.05f;
    [SerializeField] private bool jumping;
    [SerializeField] private bool freeze;

    public void FreezeMovement(bool _freeze)
    {
        rig.bodyType = _freeze ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
        freeze = _freeze;
    }

    private void OnEnable()
    {
        // asigna el rigidbody si no esta asignado ya.
        if (!playerController) playerController = GetComponent<PlayerController>();
        if (!rig) rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!(GameManager.instance.gameState != GameStates.playing || freeze))
        {
            Move();
            Jump();
        }
    }

    private void Move()
    {
        int dirRaw = Mathf.FloorToInt(Input.GetAxisRaw(Config.AXIS_X));
        float dir = Input.GetAxis(Config.AXIS_X);
        if (dirRaw != 0)
        {
            if (playerController.GetAction() != 2 && playerController.GetAction() != 1) playerController.SetAction(1);
            if (playerController.GetFacing() != dirRaw) playerController.SetFacing(dirRaw);
        }
        else
        {
            if (playerController.GetAction() != 2) playerController.SetAction(0);
        }
        rig.velocity = new Vector2(dir * speed, rig.velocity.y);
    }

    private void Jump()
    {
        Collider2D hit = Physics2D.OverlapArea(new Vector2(footPositonA.x, footPositonA.y + jumpAreaDetection / 2) + (Vector2)transform.position, new Vector2(footPositonB.x, footPositonA.y - jumpAreaDetection / 2) + (Vector2)transform.position, layersColliders);
        if (hit != null)
            if (Input.GetButtonDown(Config.BUTTON_JUMP) && hit.CompareTag(Config.TAG_SOLID))
            {
                playerController.SetAction(2);
                jumping = true;
                lastTouchGroundHigh = transform.position.y;
                StartCoroutine(ISalto());
            }

        if (Input.GetButtonUp(Config.BUTTON_JUMP))
        {
            jumping = false;
        }
    }

    private IEnumerator ISalto()
    {
        float airTime = 0;

        while (jumping)
        {
            float force = jumpForce * (1 - (transform.position.y - lastTouchGroundHigh) / maxHeightJump);
            rig.velocity = new Vector2(rig.velocity.x, force);
            if (airTime >= jumpTime)
            {
                jumping = false;
            }
            else
            {
                airTime += Time.deltaTime;
            }
            yield return new WaitForEndOfFrame();
        }
        playerController.SetAction(0);
        yield return null;
    }
}