using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHitPoints = 100f;
    [SerializeField] Canvas startCanvas;
    [SerializeField] float startCanvasDuration = 2f;

    void Start()
    {
        startCanvas.enabled = false;
        StartCoroutine((startScreen()));
    }

    IEnumerator startScreen()
    {
        startCanvas.enabled = true;
        yield return new WaitForSeconds(startCanvasDuration);
        startCanvas.enabled = false;
    }
    public void TakeDamage(float damage)
    {
        playerHitPoints -= damage;
        if (playerHitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath(); 
        }
    }
}
