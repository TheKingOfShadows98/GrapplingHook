using UnityEngine;

/// <summary>
/// Esta es la mecanica de los Colores V 1.0 By Tk98;
/// Requisitos:
/// - Sprite Renderer del Jugador;
/// - los objetos Azules estén en una layer separada;
/// - los objetos Negros estén en una layer separada;
/// - El Jugador esté en una layer separada;
///
/// </summary>
public class MecanicadeColores : MonoBehaviour
{
    [Header("Componentes")]
    // asignar Sprite Renderer o dejar vacio
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField, Tooltip("Controlador del Jugador")] private PlayerController playerController;

    [Header("Layers")]
    // Layer de los objetos Azules en numero
    [SerializeField, Tooltip("Layer de los objetos Azules en numero")] private int Lblue;

    // Layer de los Objetos Negros en numero
    [SerializeField, Tooltip("Layer de los Objetos Negros en numero")] private int Lblack;

    // Layer de el Jugador en numero
    [SerializeField, Tooltip("Layer de el Jugador en numero")] private int Lplayer;

    [Header("Colores")]
    // colores para referencia visual
    [SerializeField] private Color blackModeColor;

    [SerializeField] private Color blueModeColor;

    [Header("Variables [No Tocar, solo para info]")]
    // valor que indica hacia donde esta mirando [-1 para izquierda | 1 para derecha]

    [SerializeField] private int facing = 1;

    // comprueba y asigna las colisiones

    private void OnEnable()
    {
        // obtiene el SpriteRenderer del objeto asignado
        if (!spriteRenderer) spriteRenderer = GetComponent<SpriteRenderer>();

        if (!playerController) playerController = GetComponent<PlayerController>();

        // asigna una direccion por defecto de derecha [1]
        ComprobarDirección(1);
    }

    public void ComprobarDirección(int dir)
    {
        // pregunta si esta mirando hacia otra dirección [ si dir es distinto a 0, asigna dir a facing; sino, deja el valor de facing]
        facing = dir != 0 ? dir : facing;

        // asigna los valores para saber si tiene que omitir una colision [omite azul si mira a la derecha, omite negro si mira a la izquierda]
        bool blue = facing == 1;
        bool black = facing == -1;

        // Aplica las omisiones de colisiones entre la layer del player y la layer del objeto
        Physics2D.IgnoreLayerCollision(Lplayer, Lblack, black);
        Physics2D.IgnoreLayerCollision(Lplayer, Lblue, blue);

        // asigna un color como referencia visual para saber que layer esta omitiendo.
        // spriteRenderer.color = blue ? blueModeColor : blackModeColor;
        spriteRenderer.flipX = !blue;
    }
}