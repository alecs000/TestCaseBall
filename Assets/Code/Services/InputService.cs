using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour,IInputService
{
    public Vector3 Direction { get; set; }

    private void Update()
    {
        // Не Input.GetAxis так как нужно считывать только Up.
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Direction = Vector3.up;
            return;
        }
        Direction = Vector3.down;
    }
}
