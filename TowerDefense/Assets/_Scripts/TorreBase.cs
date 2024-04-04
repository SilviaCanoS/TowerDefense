using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

/**Esta clase controla las torres peaShooter y DoublePeaShooter \n
 * y sirve de base para la torre Cactus
 */
public class TorreBase : MonoBehaviour
{
    public GameObject enemigo, prefabBala, baseGirar;
    public int vida;
    public List<GameObject> puntasCañon;
    public AminTorres aminTorres;
    public EnemySpawner enemySpawner;


    /**Al activarse se inicializan el administrador de torres y el generador de enemigos \n
     * Tambien se asigna la vida de la torre dependiendo del número de oleada
     */
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

    /**Detecta si hay algun enemigo en el escenario para apuntarle con el metodo Apuntar \n
     * Si la vida de la torre es 0, la elimina de la lista de torres instanciadas \n
     * y la destruye
     */
    private void Update()
    {
        if (enemigo != null) Apuntar();
        
        if(vida <= 0)
        {
            aminTorres.torresInstanciadas.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    /**Este metodo gira la torre para apuntar directamente al enemigo mas cercano
    */
    public void Apuntar()
    {
        baseGirar.GetComponent<Transform>().LookAt(enemigo.transform); 
        //transform.LookAt(enemigo.transform); //gira el eje z
    }

    /**Este metodo permite que la torre dispare \n
     * Busca todas las salidas del cañon disponible e instancia una bala \n
     * Define el objetivo de la bala como el enemigo mas cercano \n
     * Resta una vida a la torre por cada bala disparada
     */
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
