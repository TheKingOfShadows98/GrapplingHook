using UnityEngine;
using GrappleHook.util;

#if UNITY_EDITOR
using UnityEditor;

#endif

public class PlayerController : MonoBehaviour
{
    private const string ANIMATOR_PARAM_ACTION = "action";
    private const string ANIMATOR_PARAM_FACING = "facing";

    [Header("Componentes")]
    [SerializeField, Tooltip("Animator del Jugador")] private Animator animator;

    [SerializeField, Tooltip("Script de Movimiento del Jugador")] private Movimiento MovimientoScript;
    [SerializeField, Tooltip("Script de mecanica de Arma")] private WeaponMechanic weaponMechanic;
    [SerializeField, Tooltip("Script de mecanica de Gancho")] private GanchoMechanic ganchoMechanic;
    [SerializeField, Tooltip("Script de mecanica de Guantes")] private PushObject pushMechanic;
    [SerializeField, Tooltip("Sprite Renderer")] private SpriteRenderer spriteRenderer;

    [Header("Variables [solo para info]")]
    [SerializeField, Tooltip("Mecanica activa \n||Guantes \n|Gancho \n|2: Arma \n"), ReadOnly] private PowerUps activeMechanic;

    [SerializeField, Tooltip("Cantidad de objetos Coleccionables"), ReadOnly] private int colectibles;

    [SerializeField, Tooltip("|0: Inactivo \n|1: Caminando \n|2: Saltando \n|3: atacando \n|4: Agachado"), ReadOnly] private int action;
    [SerializeField, Tooltip("|-1: Mirando Izquierda \n|1: Mirando Derecha"), ReadOnly] private int facing;
    public Vector2 Velocity => MovimientoScript.rig.velocity;
    /// <summary>
    /// asigna la accion que esta en el momento (info el el tooltip de la variable)
    /// </summary>
    /// <param name="newAction"></param>
    public void SetAction(int newAction)
    {
        // Actualiza el valor action del animator
        animator.SetInteger(ANIMATOR_PARAM_ACTION, newAction);

        // asigna a action el nuevo valor
        action = newAction;
    }

    /// <summary>
    /// Retorna la Accion que se esta ejecuando
    /// </summary>
    /// <returns></returns>
    public int GetAction() => action;

    public void AddPen()
    {
        colectibles++;
    }

    /// <summary>
    /// Cambia la mecanica activa
    /// [Guantes, Gancho, Arma]
    /// </summary>
    /// <param name="_newBuff"></param>
    public void ChangeBuff(PowerUps _newBuff)
    {
        if (_newBuff != activeMechanic)
        {
            weaponMechanic.enabled = false;
            ganchoMechanic.enabled = false;
            pushMechanic.DisableMoveBoxes();
            switch (_newBuff)
            {
                case PowerUps.Guantes:
                    {
                        // no entra
                        pushMechanic.EnableMoveBoxes();
                        break;
                    }
                case PowerUps.Hook:
                    {
                        ganchoMechanic.enabled = true;
                        break;
                    }
                case PowerUps.Betsy:
                    {
                        weaponMechanic.enabled = true;
                        break;
                    }
            }

            activeMechanic = _newBuff;
        }
    }

    /// <summary>Set Player facing and flip sprite</summary>
    /// <param name="newFacing"></param>
    public void SetFacing(int newFacing)
    {
        spriteRenderer.flipX = newFacing < 0;
        animator.SetInteger(ANIMATOR_PARAM_FACING, newFacing);

        facing = newFacing;
    }

    public int GetFacing() => facing;

    public void DisableMovement()
    {
        //MovimientoScript.enabled = false;
        MovimientoScript.FreezeMovement(true);
    }

    public void EnableMovement()
    {
        //MovimientoScript.enabled = true;
        MovimientoScript.FreezeMovement(false);
    }

    private void OnEnable()
    {
        // pregunta si elcomponente esta asignado, si no lo esta lo busca en el gameObject
        animator = !animator ? GetComponent<Animator>() : animator;
        MovimientoScript = !MovimientoScript ? GetComponent<Movimiento>() : MovimientoScript;
        //MDCScrpit = !MDCScrpit ? GetComponent<MecanicadeColores>() : MDCScrpit;
        ganchoMechanic = !ganchoMechanic ? GetComponent<GanchoMechanic>() : ganchoMechanic;
        pushMechanic = !pushMechanic ? GetComponent<PushObject>() : pushMechanic;
        weaponMechanic = !weaponMechanic ? GetComponent<WeaponMechanic>() : weaponMechanic;

        ChangeBuff(PowerUps.Guantes);
    }
}

