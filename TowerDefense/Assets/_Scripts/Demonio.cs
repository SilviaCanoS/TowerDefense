using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Demonio : Enemigo
{
    //public UnityEvent activarZombie;
    public EnemySpawner enemySpawner;
    float timer = 0, timerEfecto = 40;

    private void Start()
    {
        vida = 200;
        dañar = 40;
        daño = 10;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerEfecto)
        {
            timer = 0;
            DefinirObjetivo();
        }
    }

    public void TerminaOrden()
    {
        //activarZombie.Invoke();
        DefinirObjetivo();
    }
}
