using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("플레이어 카메라 이동관리")]
    public Transform target;
    private Vector3 _offset;
    private Vector3 _currentVelocity = Vector3.zero;
    private float smoothTime = 0.3f;
    private float fixedYPosition = 0.0f;
    void Awake()
    {
        _offset = transform.position - target.position;
    }

    void Start()
    {
        
    }
    void Update()
    {
        Vector3 targetPosition = target.position + _offset;
        targetPosition.y = fixedYPosition;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }
}
