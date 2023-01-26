using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _passed;
    public float Passed =>_passed;
    public void TimerStart()
    {
        StartCoroutine(TimerSecond());
    }
    public void TimerStop()
    {
        StopCoroutine(TimerSecond());
    }
    IEnumerator TimerSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            _passed += 0.01f;
        }
    }
}
