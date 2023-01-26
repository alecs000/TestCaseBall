using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    private PlayerStartSpeed _startSpeed;
    private float _verticalSpeed = 1;
    private IInputService _inputService;

    [Inject]
    public void Construct(IInputService inputService, PlayerStartSpeed playerStartSpeed)
    {
        _startSpeed = playerStartSpeed;
        _inputService = inputService;
    }
    private void Start()
    {
        StartCoroutine(SpeedIncrease());
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(0, _inputService.Direction.y* _verticalSpeed, _startSpeed.Speed);
    }
    IEnumerator SpeedIncrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            _verticalSpeed += 0.3f;
        }
    }
}
