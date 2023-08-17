using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieTacon : Enemigo
{
    private void Start()
    {
        _da�ar = 5;
        da�o = 20;
        DefinirObjetivo();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        adminJuego.zombiePeque�oDerrotados++;
    }
}
