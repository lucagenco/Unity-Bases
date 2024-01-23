using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Ennemi : MonoBehaviour
{
    public Transform CurrentTarget;
    private NavMeshAgent Agent;
    private float elapsedAttackSpeed;
    private Animator EnnemiAnimator;
    private bool IsAttacking;
    public Transform AttackPoint;
    private bool IsDead;

    public float Health;
    public GameLogic GameLogic;
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        EnnemiAnimator = GetComponent<Animator>();
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
    
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health < 0)
        {
            EnnemiAnimator.SetBool("IsDead", true);
            Agent.enabled = false;
            IsDead = true;
            GameLogic.EnnemiKilled++;
        }
    }
    
    void Update()
    {
        if(IsDead) return;
        if(CurrentTarget == null) return;
        ManageWalkAnimation();
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.x = 0; 
        eulerAngles.z = 0; 
        transform.rotation = Quaternion.Euler(eulerAngles);
        
        if (Vector3.Distance(CurrentTarget.transform.position, transform.position) <= 1.8f) //3 de porté d'attaque
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

                var listObj = Physics.OverlapSphere(AttackPoint.position, 2).ToList();
                listObj.ForEach(x =>
                {
                    if (x.CompareTag("Player"))
                    {
                        var joueur = x.GetComponent<Player>();
                        joueur.TakeDamage(5);
                    }
                });
            }
        }
    }
}
