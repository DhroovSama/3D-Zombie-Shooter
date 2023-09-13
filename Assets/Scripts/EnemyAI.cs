using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{


    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    public AudioSource zombieSFX;

    EnemyHealth health;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    Transform target;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }
    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        else
        {
            distanceToTarget = Vector3.Distance(target.position, transform.position);
            if (isProvoked)
            {
                EngageTarget();
            }
            else if (distanceToTarget <= chaseRange)
            {
                isProvoked = true;                  
                navMeshAgent.SetDestination(target.position); 
                
            }
        }
    }
    // void Update()
    // {

    //     if(health.IsDead())
    //     {
    //         enabled = false;
    //         navMeshAgent.enabled = false;
    //     }
    //     distanceToTarget = Vector3.Distance(target.position, transform.position);

    //     if(isProvoked)
    //     {
    //         EngageTarget();
    //     }
    //     else if (distanceToTarget <= chaseRange)
    //     {
    //         isProvoked = true;

    //     }
    // }

    public void onDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            chaseTarget();
        }

        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void chaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);  
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
        
        if (!zombieSFX.isPlaying)
        {
            zombieSFX.Play();
        }
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void  OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
