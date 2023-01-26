using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private float _distance = 10;
    [SerializeField] private float _minHeight = 0;
    [SerializeField] private float _maxHeight = 1;
    [SerializeField] private int _amount = 15;
    [SerializeField] private Obstacle _obstacle;
    private float _offset = 10;
    private float _lastPosition;
    private Queue<Transform> _obatacles;
    private Transform _playerTransform;
    private UILoseMenu _loseMenu;

    [Inject]
    public void Construct(PlayerMovement playerMovement, UILoseMenu loseMenu)
    {
        _playerTransform = playerMovement.transform;
        _loseMenu = loseMenu;
    }
    private void Start()
    {
        _lastPosition = _playerTransform.position.z + 5;
        _obatacles = new Queue<Transform>();
        for (int i = 0; i < _amount; i++)
        {
            Obstacle obstacle = Instantiate(_obstacle, new Vector3(_obstacle.transform.position.x, Random.Range(_minHeight,_maxHeight), _lastPosition), Quaternion.identity, transform);
            obstacle.LoseMenu = _loseMenu;
            _lastPosition += _distance;
            _obatacles.Enqueue(obstacle.transform);
        }
    }
    private void Update()
    {

        if (_playerTransform.position.z - _offset > _obatacles.Peek().position.z)
        {
            Transform firstObstacle = _obatacles.Dequeue();
            firstObstacle.position = new Vector3(firstObstacle.position.x, Random.Range(_minHeight, _maxHeight), _lastPosition);
            _obatacles.Enqueue(firstObstacle);
            _lastPosition += _distance;
        }
    }
}
