using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    //public List<GameObject> prefabEnemigos;
    public GameObject prefabZombiePequeño, prefabZombieGrande;
    public int oleada, tiempoDeGeneracion = 6;
    public List<int> enemigosPorOleada;
    public int enemigosDuranteEstaOleada;

    public delegate void EstadoOleada();
    public event EstadoOleada EnOleadaIniciada, EnOleadaTerminada, EnOleadaGanada;
    
    public bool laOleadaHaIniciado, terminoOleada;
    public List<GameObject> enemigosGenerados;
    public AdminUI adminUI;

    // Start is called before the first frame update
    void Start()
    {
        oleada = 0;
    }

    private void FixedUpdate()
    {
        if (laOleadaHaIniciado && enemigosGenerados.Count == 0 && terminoOleada)
        {
            GanarOla();
            terminoOleada = false;
        }
    }

    public void EmpezarOla()
    {
        laOleadaHaIniciado = true;
        if(EnOleadaIniciada != null) EnOleadaIniciada();
        enemigosGenerados.Add(Instantiate(prefabZombieGrande));
        ConfigurarCantidadDeEnemigos();
        InstanciarEnemigo();
    }

    private void GanarOla()
    {
        if(laOleadaHaIniciado && EnOleadaGanada != null)
        {
            EnOleadaGanada();
            laOleadaHaIniciado = false;
        }
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
        //int indiceAleatorio = Random.Range(0, prefabEnemigos.Count);
        //Instantiate<GameObject>(prefabEnemigos[indiceAleatorio], transform.position, Quaternion.identity);
        var enemigoTemporal = Instantiate(prefabZombiePequeño, transform.position, Quaternion.identity);
        enemigosGenerados.Add(enemigoTemporal);
        enemigosDuranteEstaOleada--;
        if(enemigosDuranteEstaOleada < 0)
        {
            terminoOleada = true;

            oleada++;

            tiempoDeGeneracion--;
            if (tiempoDeGeneracion < 1) tiempoDeGeneracion = 1;

            ConfigurarCantidadDeEnemigos();
            TerminarOla();
            return;
        }

        //si se cambia el tiempo, tambien cambiar en el script demonio 
        Invoke("InstanciarEnemigo", tiempoDeGeneracion);
    }
}
