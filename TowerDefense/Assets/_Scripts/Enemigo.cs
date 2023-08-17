using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemigo : MonoBehaviour, IAtacable, IAtacante
{
    public GameObject objetivo;
    public int vida, _dañar = 0, daño = 0, recursosGanados;
    public Animator animator;
    public AdminJuego adminJuego;
    public EnemySpawner enemySpawner;

    private void OnEnable()
    {
        objetivo = GameObject.Find("Baker_house");
        adminJuego = GameObject.Find("AdminJuego").GetComponent<AdminJuego>();
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        objetivo.GetComponent<Objetivo>().EnObjetivoDestruido += Detener;

        switch (enemySpawner.oleada)
        {
            case 0: vida = 100; break;
            case 1: vida = 120; break;
            case 2: vida = 140; break;
            case 3: vida = 160; break;
            case 4: vida = 180; break;
            default: vida = 200; break;
        }
        recursosGanados = vida;
    }

    private void OnDisable()
    {
        if(objetivo != null)
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
