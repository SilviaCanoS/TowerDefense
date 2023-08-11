using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour, IAtacante
{
    public Vector3 destino;
    public float velocidad = 40;
    public GameObject enemigo;
    public int daño = 50;

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
