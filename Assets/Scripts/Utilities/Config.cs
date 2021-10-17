using UnityEditor;
using UnityEngine;
namespace GrappleHook.util
{
    /// <summary>
    /// Contiene todas los strings de tags, botones y axis
    /// </summary>
    public static class Config
    {
        public const string TAG_BREACKABLE = "Breakable";
        public const string TAG_SOLID = "Solid";
        public const string TAG_GANCHO = "Gancho";
        public const string TAG_PLAYER = "Player";

        public const string BUTTON_ACTION = "Action";
        public const string BUTTON_JUMP = "Jump";
        public const string BUTTON_PAUSE = "Pause";

        public const string AXIS_X = "Horizontal";
        public const string AXIS_Y = "Vertical";

        public const int FALL_SPEED_LIMIT = 15;

        public static Color ColorDisable = new Color(0.75f, 0.75f, 0.75f);
    }
 

    public enum GameStates
    {
        mainmenu,
        playing,
        pause
    }
    public enum PowerUps
    {
        Guantes,
        Betsy,
        Hook
    }
    public class ReadOnlyAttribute : PropertyAttribute
    {
    }

#if UNITY_EDITOR

    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label);
            GUI.enabled = true;
        }
    }

#endif
}
