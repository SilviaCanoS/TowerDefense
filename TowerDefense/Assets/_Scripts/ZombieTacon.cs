using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieTacon : Enemigo
{
    private void Start()
    {
        vida = 100;
        _da�ar = 5;
        da�o = 20;
        DefinirObjetivo();
    }

    //public void Iniciar()
    //{
    //    DefinirObjetivo();
    //}
}
