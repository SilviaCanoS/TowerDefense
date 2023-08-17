using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TorreBase : MonoBehaviour
{
    public GameObject enemigo, prefabBala, baseGirar;
    public int vida;
    public List<GameObject> puntasCañon;
    public AminTorres aminTorres;
    public EnemySpawner enemySpawner;

    private void OnEnable()
    {
        aminTorres = GameObject.Find("AdminTorres").GetComponent<AminTorres>();
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();

        switch(enemySpawner.oleada)
        {
            case 0: vida = 20; break;
            case 1: vida = 18; break;
            case 2: vida = 16; break;
            case 3: vida = 14; break;
            case 4: vida = 12; break;
            default: vida = 10; break;
        }
    }

    private void Update()
    {
        if (enemigo != null) Apuntar();
        
        if(vida <= 0)
        {
            aminTorres.torresInstanciadas.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void Apuntar()
    {
        baseGirar.GetComponent<Transform>().LookAt(enemigo.transform); 
        //transform.LookAt(enemigo.transform); //gira el eje z
    }

    public virtual void Disparar() //para que se pueda hacer un override
    {
        foreach(GameObject punta in puntasCañon)
        {
            var tempBala = Instantiate<GameObject>(prefabBala, punta.transform.position, Quaternion.identity);
            tempBala.GetComponent<Bala>().destino = enemigo.transform.position;
        }
        vida--;
    }
}
