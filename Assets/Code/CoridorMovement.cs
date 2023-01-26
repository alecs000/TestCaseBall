using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CoridorMovement : MonoBehaviour
{
    private Transform _playerTransform;
    [Inject]
    public void Construct(PlayerMovement playerMovement)
    {
        _playerTransform = playerMovement.transform;
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _playerTransform.position.z);
    }
}
