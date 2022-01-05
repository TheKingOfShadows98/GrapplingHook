using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    Vector2 initialPosition;
    float maxOffset = 20;
    [SerializeField] bool activeX;
    [SerializeField] bool activeY;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var _speed = transform.position.z / maxOffset;
        var _speedY = maxOffset / transform.position.z;
        Vector2 _offset;
        _offset.x = Camera.main.transform.position.x * _speed;
        _offset.y = Camera.main.transform.position.y / _speedY;
        Vector3 position = transform.position;
        position.x = initialPosition.x + _offset.x;
        position.y = initialPosition.y + _offset.y;
        if (!activeY) position.y = transform.position.y;
        if(!activeX) position.x = transform.position.x;
        transform.position = position;
    }
}
