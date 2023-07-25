using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieTacon : MonoBehaviour
{
    public GameObject objetivo;
    public int vida = 100;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Objetivo"))
        {
            animator.SetBool("isMoving", false);
            animator.SetTrigger("onObjectiveReached");
        }
    }

    public void Iniciar()
    {
        GetComponent<NavMeshAgent>().SetDestination(objetivo.transform.position);
        animator.SetBool("isMoving", true);
    }

    public void Dañar()
    {
        if(objetivo) objetivo.GetComponent<Objetivo>().RecibirDaño(5);
        //objetivo?.GetComponent<Objetivo>().RecibirDaño(40);
    }

    public void RecibirDaño(int daño = 20)
    {
        vida -= daño;
    }
}
