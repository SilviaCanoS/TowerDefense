using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> prefabEnemigos;
    public int oleada;
    public List<int> enemigosPorOleada;
    private int enemigosDuranteEstaOleada;
    public delegate void OleadaTerminada();
    public event OleadaTerminada EnOleadaTerminada;

    // Start is called before the first frame update
    void Start()
    {
        oleada = 0;
        ConfigurarCantidadDeEnemigos();
        InstanciarEnemigo();
    }

    public void TerminarOla()
    {
        if (EnOleadaTerminada != null) EnOleadaTerminada();
    }

    public void ConfigurarCantidadDeEnemigos()
    {
        enemigosDuranteEstaOleada = enemigosPorOleada[oleada];
    }

    public void InstanciarEnemigo()
    {
        int indiceAleatorio = Random.Range(0, prefabEnemigos.Count);
        Instantiate<GameObject>(prefabEnemigos[indiceAleatorio], transform.position, Quaternion.identity);
        enemigosDuranteEstaOleada--;
        if(enemigosDuranteEstaOleada < 0)
        {
            oleada++;
            ConfigurarCantidadDeEnemigos();
            TerminarOla();
            return;
        }
        Invoke("InstanciarEnemigo", 2);
    }
}
