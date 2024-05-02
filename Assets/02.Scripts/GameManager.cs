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
        //timeSystem.AddChangeTimeEvent((time) =>
        //{
        //    text.text = "Time\n" + time.ToString();
        //});
        //button.onClick.AddListener(() =>
        //{
        //    NextRoutine();
        //});

        //Onion Data Reset
        gameData.OnionDataReset();
    }
    public void NextRoutine()
    {
        timeSystem.GotoNextTime();
    }
    public void SetOnionStat(OnionStat stat, int value)
    {
        gameData.onionData.Stat[(int)stat] += value;
        uiManager.ShowStatMessage(stat, value);
    }
}
