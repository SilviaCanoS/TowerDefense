using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AminTorres : MonoBehaviour
{
    public AdminToques adminToques;
    public enum TorreSeleccionada { Torre1, Torre2, Torre3 }
    public TorreSeleccionada torreSeleccionada;
    public List<GameObject> prefabTorres;

    private void OnEnable()
    {
        adminToques.enMacetaTocada += CrearTorre;
    }

    private void OnDisable()
    {
        adminToques.enMacetaTocada -= CrearTorre;
    }

    public void CrearTorre(GameObject maceta)
    {
        if (maceta.transform.childCount == 0)
        {
            Debug.Log("Creando Torre");
            int indiceTorre = (int)torreSeleccionada;
            Vector3 posParaInstanciar = maceta.transform.position; //new(-18.17f, 8.14f, -14.01f)
            posParaInstanciar += new Vector3(-3.29231f, 4.44f, -10.224f);
            GameObject torreInstanciada =
                Instantiate(prefabTorres[indiceTorre], posParaInstanciar, Quaternion.identity);
            torreInstanciada.transform.SetParent(maceta.transform);
        }
    }

    public void ConfigurarTorre(int torre)
    {
        if (Enum.IsDefined(typeof(TorreSeleccionada), torre)) torreSeleccionada = (TorreSeleccionada) torre;
        else Debug.Log("Esa torre no esta definida"); 
    }
}
