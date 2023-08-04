using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminUI : MonoBehaviour
{
    public GameObject canvasJuego, canvasGameOver;
    public EnemySpawner enemySpawner;
    public Objetivo objetivo;

    private void OnEnable()
    {
        objetivo.EnObjetivoDestruido += MostrarMenuGameOver;
    }

    private void OnDisable()
    {
        objetivo.EnObjetivoDestruido -= MostrarMenuGameOver;
    }

    public void MostrarMenuFinOleada()
    {

    }

    public void OcultarMenuFinOleada()
    {

    }

    public void MostrarMenuGameOver()
    {
        Time.timeScale = 0;
        canvasGameOver.SetActive(true);
    }

    public void OcultarMenuGameOver()
    {
        Time.timeScale = 1;
        canvasGameOver.SetActive(false);
    }

    public void FinalizarJuego()
    {
        Application.Quit();
    }

    public void CargarMenuPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ReiniciarNivel()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }
}
