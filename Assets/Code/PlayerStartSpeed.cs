using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartSpeed
{
    private static float _speed = 2;
    public float Speed => _speed;
    public void SwitchSpeed(float speed)
    {
        _speed = speed;
    }
}
