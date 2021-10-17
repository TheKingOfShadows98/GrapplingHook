using Cinemachine;
using GrappleHook.util;
using UnityEngine;

public class CamFocus : MonoBehaviour
{
    private CinemachineVirtualCamera vcam { get; set; }

    private CinemachineFramingTransposer transposer { get; set; }

    private void Awake()
    {
        vcam = FindObjectOfType<CinemachineVirtualCamera>();
        transposer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    private void Update()
    {
        if(GameManager.instance.gameState == GameStates.playing) { 
            Vector3 offset = transposer.m_TrackedObjectOffset;
            offset.x = Input.GetAxisRaw(Config.AXIS_X) * 2;
            offset.y = 2.5f + (Input.GetAxisRaw(Config.AXIS_Y) * 3.5f);
            offset.y = Mathf.Clamp(offset.y, -3.5f, 4.5f);
            transposer.m_TrackedObjectOffset = Vector3.Lerp(transposer.m_TrackedObjectOffset, offset, 2 * Time.deltaTime);
        }
    }
}