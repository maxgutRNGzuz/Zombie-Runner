using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public bool isProvoked = false;

    [SerializeField] Transform player = null;
    [SerializeField] Transform destination = null;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    Animator animator;
    NavMeshAgent navMeshAgent;
    NavMeshObstacle navMesheshObstacle;
    Transform target;
    float targetDistance = Mathf.Infinity;
    float playerDistance = Mathf.Infinity;

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMesheshObstacle = GetComponent<NavMeshObstacle>();
        target = destination;
    }

    void Update()
    {
        targetDistance = Vector3.Distance(target.position, transform.position);
        if(target != player)
        {
            playerDistance = Vector3.Distance(player.position, transform.position);
        }

        EngageTarget();

        if (isProvoked)
        {
            target = player;
        }
        else if(playerDistance <= chaseRange)
        {
            isProvoked = true;
        }
    }
    void EngageTarget()
    {
        if (targetDistance >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (targetDistance <= navMeshAgent.stoppingDistance + 0.1f) //some buffer
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        animator.SetBool("isAttacking", false); //cancels animation if target goes out of range
        navMesheshObstacle.enabled = false;
        navMeshAgent.enabled = true;
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        FaceTarget();
        animator.SetBool("isAttacking", true);
        navMeshAgent.enabled = false;
        navMesheshObstacle.enabled = true;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
