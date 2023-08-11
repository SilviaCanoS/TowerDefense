using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Demonio : Enemigo
{
    float timer = 0, timerEfecto = 80;

    private void Start()
    {
        vida = 200;
        _da�ar = 40;
        da�o = 10;
    }
    
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerEfecto)
        {
            timer = 0;
            DefinirObjetivo();
        }

        if (vida <= 0)
        {
            enemySpawner.enemigosGenerados.Remove(this.gameObject);
            animator.SetTrigger("onDead");
            GetComponent<NavMeshAgent>().SetDestination(transform.position);
            Destroy(this.gameObject, 3);
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        adminJuego.zombieGrandeDerrotados++;
    }
}
