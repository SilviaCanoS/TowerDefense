using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieTacon : MonoBehaviour
{
    public GameObject objetivo;
    public int vida = 100;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Objetivo"))
        {
            animator.SetBool("isMoving", false);
            animator.SetTrigger("onObjectiveReached");
        }
    }

    public void Iniciar()
    {
        GetComponent<NavMeshAgent>().SetDestination(objetivo.transform.position);
        animator.SetBool("isMoving", true);
    }

    public void Da�ar()
    {
        if(objetivo) objetivo.GetComponent<Objetivo>().RecibirDa�o(5);
        //objetivo?.GetComponent<Objetivo>().RecibirDa�o(40);
    }

    public void RecibirDa�o(int da�o = 20)
    {
        vida -= da�o;
    }
}
