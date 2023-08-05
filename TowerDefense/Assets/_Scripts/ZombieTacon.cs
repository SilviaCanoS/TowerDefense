using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieTacon : Enemigo
{
    private void Start()
    {
        vida = 100;
        _dañar = 5;
        daño = 20;
        DefinirObjetivo();
    }

    //public void Iniciar()
    //{
    //    DefinirObjetivo();
    //}
}
