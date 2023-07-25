using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Demonio : MonoBehaviour
{
    public GameObject objetivo;
    public int vida = 200;
    public Animator animator;
    public ZombieTacon zombie;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Objetivo"))
        {
            animator.SetBool("isMoving", false);
            animator.SetTrigger("onObjectiveReached");
        }
    }

    private void Update()
    {
    }

    public void TerminaOrden()
    {
        zombie.Iniciar();
        GetComponent<NavMeshAgent>().SetDestination(objetivo.transform.position);
        animator = GetComponent<Animator>();
        animator.SetBool("isMoving", true);
    }

    public void Da�ar()
    {
        if(objetivo) objetivo.GetComponent<Objetivo>().RecibirDa�o(40);
    }

    public void RecibirDa�o(int da�o = 5)
    {
        vida -= da�o;
    }
}
