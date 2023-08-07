using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminUI : MonoBehaviour
{
    public GameObject canvasJuego, canvasGameOver, canvasOlaGanada, canvasFinOla;
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
    }

    private void OnDisable()
    {
        objetivo.EnObjetivoDestruido -= MostrarMenuGameOver;
        enemySpawner.EnOleadaIniciada -= ActualizarOla;
        enemySpawner.EnOleadaTerminada -= MostrarMensajeUltimoEnemigo;
        enemySpawner.EnOleadaGanada -= MostrarCanvasOlaGanada;
        adminJuego.enRecursosModificados -= ActualizarRecursos;
    }

    private void ActualizarOla()
    {
        textoOleada.text = $"Ola: {enemySpawner.oleada}";
        OcultarCanvasOlaGanada();
    }

    private void MostrarMensajeUltimoEnemigo()
    {
        canvasFinOla.SetActive(true);
        Invoke("OcultarMensajeUltimoEnemigo", 3);
    }

    private void OcultarMensajeUltimoEnemigo()
    {
        canvasFinOla.SetActive(false);
        textoEnemigos.text = $"Enemigos: \t {adminJuego.zombiePequeñoDerrotados}";
        textoJefes.text = $"Jefes: \t\t {adminJuego.zombieGrandeDerrotados}";
    }

    private void MostrarCanvasOlaGanada()
    {
        textoEnemigos.text = $"Enemigos: \t {adminJuego.zombiePequeñoDerrotados}";
        textoJefes.text = $"Jefes: \t\t {adminJuego.zombieGrandeDerrotados}";
        canvasOlaGanada.SetActive(true);
    }

    private void OcultarCanvasOlaGanada()
    {
        canvasOlaGanada.SetActive(false);
    }

    private void ActualizarRecursos()
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
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }
}
