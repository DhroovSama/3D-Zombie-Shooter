using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    // create a public method which reduces hitpoints by the ammount of damage

    public void TakeDamage(float damage)
    {
        BroadcastMessage("onDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");

        if (GetComponent<EnemyAI>().zombieSFX.isPlaying)
        {
            GetComponent<EnemyAI>().zombieSFX.Stop();
        }
    }
}
