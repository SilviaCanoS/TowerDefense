using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AminTorres : MonoBehaviour
{
    public AdminToques adminToques;
    public enum TorreSeleccionada { Torre1, Torre2, Torre3 }
    public TorreSeleccionada torreSeleccionada;
    public List<GameObject> prefabTorres, torresInstanciadas;

    public AdminJuego adminJuego;
    public EnemySpawner enemySpawner;
    public GameObject objetivo;

    public delegate void EnemigoObjetivoActualizado();
    public event EnemigoObjetivoActualizado EnEnemigoObjetivoActualizado;

    private void OnEnable()
    {
        adminToques.enMacetaTocada += CrearTorre;
        enemySpawner.EnOleadaIniciada += ActualizarObjetivo;
        torresInstanciadas = new List<GameObject>();
    }

    private void OnDisable()
    {
        adminToques.enMacetaTocada -= CrearTorre;
        enemySpawner.EnOleadaIniciada -= ActualizarObjetivo;
    }

    private void ActualizarObjetivo()
    {
        if(enemySpawner.laOleadaHaIniciado)
        {
            float distanciaMasCorta = float.MaxValue;
            GameObject enemigoMasCercano = null;
            foreach(GameObject enemigo in enemySpawner.enemigosGenerados)
            {
                float dist = Vector3.Distance(enemigo.transform.position, objetivo.transform.position);
                if(dist < distanciaMasCorta)
                {
                    distanciaMasCorta = dist;
                    enemigoMasCercano = enemigo;
                }
            }

            if (enemigoMasCercano != null)
            {
                foreach (GameObject torre in torresInstanciadas)
                {
                    torre.GetComponent<TorreBase>().enemigo = enemigoMasCercano;
                    torre.GetComponent<TorreBase>().Disparar();
                }

                if (EnEnemigoObjetivoActualizado != null)
                    EnEnemigoObjetivoActualizado();
            }
        }

        Invoke(nameof(ActualizarObjetivo), 2);
    }

    public void CrearTorre(GameObject maceta)
    {
        int costo = torreSeleccionada switch
        {
            TorreSeleccionada.Torre1 => 400,
            TorreSeleccionada.Torre2 => 600,
            TorreSeleccionada.Torre3 => 800,
            _ => 0
        };

        if (maceta.transform.childCount == 0 && adminJuego.recursos >= costo)
        {
            adminJuego.ModificarRecursos(-costo);
            Debug.Log("Creando Torre");
            int indiceTorre = (int)torreSeleccionada;
            Vector3 posParaInstanciar = maceta.transform.position; //new(-18.17f, 8.14f, -14.01f)

            if ((int)torreSeleccionada == 2) posParaInstanciar += new Vector3(-0.09769f, 3.47f, 0.114f);
            else posParaInstanciar += new Vector3(-3.29231f, 4.44f, -10.224f);
            
            GameObject torreInstanciada =
                Instantiate(prefabTorres[indiceTorre], posParaInstanciar, Quaternion.identity);
            torreInstanciada.transform.SetParent(maceta.transform);
            torresInstanciadas.Add(torreInstanciada);
        }
    }

    public void ConfigurarTorre(int torre)
    {
        if (Enum.IsDefined(typeof(TorreSeleccionada), torre)) torreSeleccionada = (TorreSeleccionada) torre;
        else Debug.Log("Esa torre no esta definida"); 
    }
}
