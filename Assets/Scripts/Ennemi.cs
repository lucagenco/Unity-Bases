using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemi : MonoBehaviour
{
    public Transform CurrentTarget;
    private NavMeshAgent Agent;
    private float elapsedAttackSpeed;
    private Animator EnnemiAnimator;
    private bool IsAttacking;
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
    
    public void ManageWalkAnimation()
    {
        if (Agent.velocity.magnitude < 0.25f)
        {
            EnnemiAnimator.SetBool("IsWalking", false);
        }
        else
        {
            EnnemiAnimator.SetBool("IsWalking", true);
        }
    }
    
    void Update()
    {
        if(CurrentTarget == null) return;
        ManageWalkAnimation();
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.x = 0; 
        eulerAngles.z = 0; 
        transform.rotation = Quaternion.Euler(eulerAngles);
        
        if (Vector3.Distance(CurrentTarget.transform.position, transform.position) <= 3) //3 de porté d'attaque
        {
            Agent.isStopped = true;
            IsAttacking = true;
        }
        else
        {
            Agent.SetDestination(CurrentTarget.transform.position);
            Agent.isStopped = false;
            IsAttacking = false;
        }

        if (IsAttacking)
        {
            elapsedAttackSpeed += Time.deltaTime;
            if (elapsedAttackSpeed >= 1) //1 attaque par seconde
            {
                elapsedAttackSpeed = 0;
                EnnemiAnimator.SetTrigger("Attack");
            }
        }
    }
}
