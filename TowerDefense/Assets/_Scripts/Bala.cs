using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour, IAtacante
{
    public Vector3 destino;
    public float velocidad;
    public GameObject enemigo;
    public int daño;
    public EnemySpawner enemySpawner;

    private void OnEnable()
    {
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        switch (enemySpawner.oleada) 
        {
            case 0: daño = 25; velocidad = 80;  break;
            case 1: daño = 40; velocidad = 85; break;
            case 2: daño = 60; velocidad = 90; break;
            case 3: daño = 75; velocidad = 95; break;
            case 4: daño = 95; velocidad = 100; break;
            default: daño = 110; velocidad = 105; break;

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
            Dañar(daño);
            Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Enemigo"))
    //    {
    //        enemigo = collision.gameObject;
    //        Dañar(daño);
    //        Destroy(gameObject);
    //    }
    //}

    public void Dañar(int daño)
    {
        enemigo.GetComponent<Enemigo>().RecibirDaño(daño);
    }
}
