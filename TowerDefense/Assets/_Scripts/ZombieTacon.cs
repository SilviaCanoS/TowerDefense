using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieTacon : Enemigo
{
    private void Start()
    {
        vida = 100;
        da�ar = 5;
        da�o = 20;
    }

    public void Iniciar()
    {
        DefinirObjetivo();
    }
}