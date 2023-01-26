using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _offset;
    private Transform _playerTransform;
    [Inject]
    public void Construct(PlayerMovement playerMovement)
    {
        _playerTransform = playerMovement.transform;
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _playerTransform.position.z + _offset);
    }
}
