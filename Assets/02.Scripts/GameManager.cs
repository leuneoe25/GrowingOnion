using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TimeSystem timeSystem;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameData gameData;
    [SerializeField] private MoistureSunlightSystem moistureSunlightSystem;

    public Action NextDayEvent;

    #region <singleton>
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    #endregion
    void Start()
    {
        

        //Onion Data Reset
        //gameData.OnionDataReset();
    }
    public void NextRoutine()
    {
        timeSystem.GotoNextTime();
    }
    public void SetOnionStat(OnionStat stat, int value,bool effectText = false)
    {
        gameData.onionData.Stat[(int)stat] += value;
        if (effectText)
            uiManager.ShowStatMessage(stat, value);
    }
    public void SetOnionStat(StatValue onionStatEffect, bool effectText = false)
    {
        gameData.onionData.Stat[(int)onionStatEffect.onionStat] += onionStatEffect.value;
        if(effectText)
            uiManager.ShowStatMessage(onionStatEffect.onionStat, onionStatEffect.value);
    }
    public void SetMoisture(int value)
    {
        gameData.onionData.moisture += value;
    }
    public void EndDayEvent()
    {
        moistureSunlightSystem.Execute();
    }
    public void GameEnd()
    {

    }
}
