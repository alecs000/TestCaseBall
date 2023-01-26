using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Obstacle : MonoBehaviour
{
    public UILoseMenu LoseMenu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement playerMovement))
        {
            Lose();
        }
    }
    public void Lose()
    {
        LoseMenu.gameObject.SetActive(true);
    }
}
