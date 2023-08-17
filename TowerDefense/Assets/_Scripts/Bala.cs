using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour, IAtacante
{
    public Vector3 destino;
    public float velocidad;
    public GameObject enemigo;
    public int da�o;
    public EnemySpawner enemySpawner;

    private void OnEnable()
    {
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        switch (enemySpawner.oleada) 
        {
            case 0: da�o = 25; velocidad = 80;  break;
            case 1: da�o = 40; velocidad = 85; break;
            case 2: da�o = 60; velocidad = 90; break;
            case 3: da�o = 75; velocidad = 95; break;
            case 4: da�o = 95; velocidad = 100; break;
            default: da�o = 110; velocidad = 105; break;

        }
    }

    private void Start()
    {
        destino.y += 1;

    }

    private void Update()
    {
        var paso = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destino, paso);
        if (Vector3.Distance(transform.position, destino) < 0.01f) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            enemigo = other.gameObject;
            Da�ar(da�o);
            Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Enemigo"))
    //    {
    //        enemigo = collision.gameObject;
    //        Da�ar(da�o);
    //        Destroy(gameObject);
    //    }
    //}

    public void Da�ar(int da�o)
    {
        enemigo.GetComponent<Enemigo>().RecibirDa�o(da�o);
    }
}
