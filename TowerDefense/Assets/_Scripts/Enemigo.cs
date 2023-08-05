using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemigo : MonoBehaviour, IAtacable, IAtacante
{
    public GameObject objetivo;
    public int vida = 200, _dañar = 0, daño = 0;
    public Animator animator;

    private void OnEnable()
    {
        objetivo = GameObject.Find("Casa");
        objetivo.GetComponent<Objetivo>().EnObjetivoDestruido += Detener;
    }

    private void OnDisable()
    {
        objetivo.GetComponent<Objetivo>().EnObjetivoDestruido -= Detener;
    }

    private void Update()
    {
        if (vida <= 0)
        {
            animator.SetTrigger("onDead");
            GetComponent<NavMeshAgent>().SetDestination(transform.position);
            Destroy(this.gameObject, 3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Objetivo"))
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

    public void Dañar(int dañar)
    {
        if (dañar == 0) dañar = _dañar;
        if (objetivo) objetivo.GetComponent<Objetivo>().RecibirDaño(dañar);
    }

    public void RecibirDaño(int daño)
    {
        vida -= daño;
    }

    public void Detener()
    {
        animator.SetTrigger("onObjectiveDestroyed");
        GetComponent<NavMeshAgent>().SetDestination(transform.position);
    }
}
