using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminJuego : MonoBehaviour
{
    public int zombiePequeñoDerrotados, zombieGrandeDerrotados, recursos;
    public delegate void RecursosModificados();
    public event RecursosModificados enRecursosModificados;


    public void ModificarRecursos(int modificacion)
    {
        recursos += modificacion;
        if (enRecursosModificados != null) enRecursosModificados();
    }

    public void ResetValores()
    {
        zombieGrandeDerrotados = 0;
        zombiePequeñoDerrotados = 0;
    }
}
