using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminGPGS : MonoBehaviour
{
    public TMPro.TMP_Text GPGSText;
    public EnemySpawner enemySpawner;

    private void OnEnable()
    {
        enemySpawner.EnOleadaGanada += DesbloquearLogro;
    }

    private void OnDisable()
    {
        enemySpawner.EnOleadaGanada -= DesbloquearLogro;
    }

    void Start()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(ProcesarAutenticacion);
    }

    internal void ProcesarAutenticacion(SignInStatus status)
    {
        if(status == SignInStatus.Success)
            GPGSText.text = $"Good Auth \n {Social.localUser.userName} \n {Social.localUser.id}";
        else GPGSText.text = "Bad Auth";
    }

    internal void DesbloquearLogro()
    {
        string mStatus;
        Social.ReportProgress(
            GPGSIds.achievement_primeroleadaganada, 100, (bool succes) =>
            {
                mStatus = succes ? "Logro Desbloqueado" : "Fallo en el Desbloqueo del Logro";
                GPGSText.text = mStatus;
            });
    }
}
