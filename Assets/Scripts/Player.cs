using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator AxeAnimator;
    public float Health;
    public TMP_Text TextHealth;
    public TMP_Text TextWood;
    public Transform AttackPoint;
    public int Wood;
    public GameLogic GameLogic;
    void Start()
    {
        
    }


    void Update()
    {
        //Quand on clique gauche
        if (Input.GetMouseButtonDown(0))
        {
            AxeAnimator.SetTrigger("Attack");
            var listObj = Physics.OverlapSphere(AttackPoint.position, 2).ToList();
            listObj.ForEach(x =>
            {
                if (x.CompareTag("Ennemi"))
                {
                    var joueur = x.GetComponent<Ennemi>();
                    joueur.TakeDamage(25);
                }

                if (x.CompareTag("Tree"))
                {
                    var arbre = x.GetComponent<Tree>();
                    arbre.TakeDamage(25);
                    Wood++;
                    TextWood.text = Wood.ToString();
                }
                
                if (x.CompareTag("End"))
                {
                    GameLogic.CheckWin();
                }
            });
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        TextHealth.text = Health.ToString();
        if (Health < 0)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
