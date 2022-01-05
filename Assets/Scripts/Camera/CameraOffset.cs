using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraOffset : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private float maxrange;
    [SerializeField] private float speed;
    [SerializeField] private float deadTime;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool notIdle = Input.GetAxisRaw("Horizontal") != 0;
        if (notIdle) time = Time.time + deadTime;
        float _speed = 0;
        CinemachineFramingTransposer transposer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
        if (time <= Time.time && !notIdle)
            _speed = (0.5f - transposer.m_ScreenX) * speed * Time.deltaTime * 2;
        else
        {
            _speed = -Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        }
        transposer.m_ScreenX = Mathf.Clamp((transposer.m_ScreenX  + _speed), 0.5f -maxrange,0.5f + maxrange);
        
    }
}
