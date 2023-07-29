using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemigo : MonoBehaviour
{
    public GameObject objetivo;
    public int vida = 200, dañar = 0, daño = 0;
    public Animator animator;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Objetivo"))
        {
            animator.SetBool("isMoving", false);
            animator.SetTrigger("onObjectiveReached");
        }
    }

    public void DefinirObjetivo()
    {
        animator.SetBool("isMoving", true);
        GetComponent<NavMeshAgent>().SetDestination(objetivo.transform.position);
        animator = GetComponent<Animator>();
        
    }

    public void Dañar()
    {
        if (objetivo) objetivo.GetComponent<Objetivo>().RecibirDaño(dañar);
    }

    public void RecibirDaño(int daño)
    {
        vida -= daño;
    }

    private void OnEnable()
    {
        objetivo = GameObject.Find("Casa");
    }

    private void OnDisable()
    {
        
    }
}
