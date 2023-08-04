using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Demonio : Enemigo
{
    //public UnityEvent activarZombie;

    private void Start()
    {
        vida = 200;
        dañar = 40;
        daño = 10;
    }

    public void TerminaOrden()
    {
        //activarZombie.Invoke();
        DefinirObjetivo();
    }
}
