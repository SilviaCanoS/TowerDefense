using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreCactus : TorreBase, IAtacante
{
    float timer = 0, timerEfecto = 30;
    public float divisionesRayo = 10;
    public LineRenderer LRRayo;
    public List<Vector3> puntos;
    public int potenciaRayo;

    private void Start()
    {
        LRRayo = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (enemigo != null) Apuntar();

        timer += Time.deltaTime;
        if (timer >= timerEfecto)
        {
            aminTorres.torresInstanciadas.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(enemigo != null)
        {
            Disparar();
            Da�ar(potenciaRayo);
        }
        else LRRayo.positionCount = 0;
    }

    public override void Disparar()
    {
        puntos = ObtenerPuntos();
        puntos.Insert(0, puntasCa�on[0].transform.position);
        var posEnemigo = enemigo.transform.position;
        posEnemigo.y += 1;
        puntos.Add(posEnemigo);
        LRRayo.positionCount = puntos.Count;
        LRRayo.SetPositions(puntos.ToArray());
    }

    private List<Vector3> ObtenerPuntos()
    {
        List<Vector3> puntosTemporales = new List<Vector3>();
        float divisor = 1 / divisionesRayo;
        float linear = 0;
        bool esPositivo = false;

        if(divisionesRayo == 0)
        {
            Debug.LogError("No podemos dividir entre 0, por favor ingresa otro valor en el prefab");
            return null;
        }

        if(divisionesRayo == 1)
        {
            var punto = Vector3.Lerp(puntasCa�on[0].transform.position, enemigo.transform.position, 0.5f);
            puntosTemporales.Add(punto);
            return puntosTemporales;
        }

        for(int i = 0; i < divisionesRayo; i++)
        {
            if (i == 0) linear = divisor / 2;
            else linear += divisor;

            //lerp = linear interpolation
            var punto = Vector3.Lerp(puntasCa�on[0].transform.position, enemigo.transform.position, linear);
            if(esPositivo)
            {
                punto.x += Random.value * 2;
                esPositivo = false;
            }
            else
            {
                punto.x -= Random.value * 2;
                esPositivo = true;
            }
            puntosTemporales.Add(punto);
        }

        return puntosTemporales;
    }

    public void Da�ar(int da�o = 0)
    {
        enemigo.GetComponent<Enemigo>().RecibirDa�o(potenciaRayo);
    }
}
