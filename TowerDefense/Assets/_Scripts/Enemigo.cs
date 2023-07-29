using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemigo : MonoBehaviour
{
    public GameObject objetivo;
    public int vida = 200, da�ar = 0, da�o = 0;
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

    public void Da�ar()
    {
        if (objetivo) objetivo.GetComponent<Objetivo>().RecibirDa�o(da�ar);
    }

    public void RecibirDa�o(int da�o)
    {
        vida -= da�o;
    }

    private void OnEnable()
    {
        objetivo = GameObject.Find("Casa");
    }

    private void OnDisable()
    {
        
    }
}
