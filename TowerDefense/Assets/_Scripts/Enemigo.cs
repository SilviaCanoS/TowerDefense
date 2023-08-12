using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemigo : MonoBehaviour, IAtacable, IAtacante
{
    public GameObject objetivo;
    public int vida = 200, _da�ar = 0, da�o = 0, recursosGanados = 200;
    public Animator animator;
    public AdminJuego adminJuego;
    public EnemySpawner enemySpawner;

    private void OnEnable()
    {
        objetivo = GameObject.Find("Baker_house");
        adminJuego = GameObject.Find("AdminJuego").GetComponent<AdminJuego>();
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
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
            enemySpawner.enemigosGenerados.Remove(this.gameObject);
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

    public virtual void OnDestroy()
    {
        adminJuego.ModificarRecursos(recursosGanados);
        enemySpawner.enemigosGenerados.Remove(this.gameObject);
    }

    public void DefinirObjetivo()
    {
        animator.SetBool("isMoving", true);
        GetComponent<NavMeshAgent>().SetDestination(objetivo.transform.position);
        animator = GetComponent<Animator>();
        
    }

    public void Da�ar(int da�ar)
    {
        if (da�ar == 0) da�ar = _da�ar;
        if (objetivo) objetivo.GetComponent<Objetivo>().RecibirDa�o(da�ar);
    }

    public void RecibirDa�o(int da�o)
    {
        vida -= da�o;
    }

    public void Detener()
    {
        animator.SetTrigger("onObjectiveDestroyed");
        GetComponent<NavMeshAgent>().SetDestination(transform.position);
    }
}
