using System;
using Unity.VisualScripting;
using UnityEngine;

public class deathzone : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        gameManager.LoseLife();
        Destroy(other.gameObject);
    }
}
