using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5.0f;
     NavMeshAgent navMeshAgent;
    [SerializeField] float turnspeed = 5f;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget<=chaseRange)
        {
            isProvoked = true;
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
    private void EngageTarget()
    {
        if(distanceToTarget>=navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if(distanceToTarget<=navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }
    private void ChaseTarget()
    {
        if(GetComponent<EnemyHealth>().IsDead()==false)
        {
            GetComponent<Animator>().SetBool("attack", false);
            GetComponent<Animator>().SetTrigger("move");
            navMeshAgent.SetDestination(target.position);
        }
    }
    private void AttackTarget()
    {
        if (GetComponent<EnemyHealth>().IsDead() == false)
        {
            GetComponent<Animator>().SetBool("attack", true);
            FaceTarget();
            FindObjectOfType<PlayerHealth>().TakeDamage(0.01f);
            Debug.Log(name + "destroying" + target.name);
        }
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnspeed);
    }
    public void OnDamageTaken()
    {
        isProvoked = true;
    }

}
