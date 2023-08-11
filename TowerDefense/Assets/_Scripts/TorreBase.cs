using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreBase : MonoBehaviour
{
    public GameObject enemigo, prefabBala, baseGirar;
    public List<GameObject> puntasCa�on;

    private void Update()
    {
        if (enemigo != null) Apuntar();
    }

    public void Apuntar()
    {
        baseGirar.GetComponent<Transform>().LookAt(enemigo.transform); 
        //transform.LookAt(enemigo.transform); //gira el eje z
    }

    public virtual void Disparar() //para que se pueda hacer un override
    {
        foreach(GameObject punta in puntasCa�on)
        {
            var tempBala = Instantiate<GameObject>(prefabBala, punta.transform.position, Quaternion.identity);
            tempBala.GetComponent<Bala>().destino = enemigo.transform.position;
        }
    }
}
