using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdminUI : MonoBehaviour
{
    public GameObject canvasJuego, canvasGameOver, canvasOlaGanada, canvasFinOla, buttonComenzar, canvasPausa;
    public EnemySpawner enemySpawner;
    public Objetivo objetivo;
    public AdminJuego adminJuego;
    public TMPro.TMP_Text textoRecursos, textoOleada, textoEnemigos, textoJefes;

    private void OnEnable()
    {
        objetivo.EnObjetivoDestruido += MostrarMenuGameOver;
        enemySpawner.EnOleadaIniciada += ActualizarOla;
        enemySpawner.EnOleadaTerminada += MostrarMensajeUltimoEnemigo;
        enemySpawner.EnOleadaGanada += MostrarCanvasOlaGanada;
        adminJuego.enRecursosModificados += ActualizarRecursos;
        textoRecursos.text = $"Recursos: {adminJuego.recursos}";
    }

    private void OnDisable()
    {
        objetivo.EnObjetivoDestruido -= MostrarMenuGameOver;
        enemySpawner.EnOleadaIniciada -= ActualizarOla;
        enemySpawner.EnOleadaTerminada -= MostrarMensajeUltimoEnemigo;
        enemySpawner.EnOleadaGanada -= MostrarCanvasOlaGanada;
        adminJuego.enRecursosModificados -= ActualizarRecursos;
    }

    private void Update()
    {
        if(enemySpawner.laOleadaHaIniciado)
            buttonComenzar.GetComponent<Button>().interactable = false;
        if (!enemySpawner.laOleadaHaIniciado)
            buttonComenzar.GetComponent<Button>().interactable = true;
    }

    public void ActualizarOla()
    {
        textoOleada.text = $"Ola: {enemySpawner.oleada + 1}";
        OcultarCanvasOlaGanada();
    }

    public void MostrarPausa()
    {
        Time.timeScale = 0;
        canvasJuego.SetActive(false);
        canvasPausa.SetActive(true);
    }

    public void OcultarPausa()
    {
        Time.timeScale = 1;
        canvasJuego.SetActive(true);
        canvasPausa.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void MostrarMensajeUltimoEnemigo()
    {
        canvasFinOla.SetActive(true);
        Invoke("OcultarMensajeUltimoEnemigo", 3);
    }

    public void OcultarMensajeUltimoEnemigo()
    {
        canvasFinOla.SetActive(false);
    }

    public void MostrarCanvasOlaGanada()
    {
        textoEnemigos.text = $"Enemigos: {adminJuego.zombiePequeñoDerrotados + 1}";
        textoJefes.text = $"Jefes: {adminJuego.zombieGrandeDerrotados}";
        canvasOlaGanada.SetActive(true);
    }

    public void OcultarCanvasOlaGanada()
    {
        canvasOlaGanada.SetActive(false);
    }

    public void ActualizarRecursos()
    {
        textoRecursos.text = $"Recursos: {adminJuego.recursos}";
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
        Time.timeScale = 1;
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }
}
