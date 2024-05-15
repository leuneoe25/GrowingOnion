using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoistureSunlightSystem : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    [Header("Moisture")]
    [SerializeField]  private Image MoistureImage;
    [Header("Sunlight")]
    [SerializeField] private Image SunlightImage;
    void Start()
    {

    }
    public void Execute()
    {
        GameManager.Instance.NextDayEvent();

        if(gameData.onionData.moisture > 100)
            gameData.onionData.moisture = 100;

        gameData.onionData.moisture -= 40;
        ChangeMoisture();


        if (gameData.onionData.outingCount >= 1)
        {
            gameData.onionData.sunlight -= 10;
            gameData.onionData.outingCount--;
        }
        else
        {
            gameData.onionData.sunlight -= 40;
        }
        ChangeSunlight();
    }

    public void ChangeMoisture()
    {
        MoistureImage.fillAmount = (gameData.onionData.moisture / 100f);
        if(gameData.onionData.moisture <= 0)
            GameManager.Instance.GameEnd();
    }
    public void ChangeSunlight()
    {
        SunlightImage.fillAmount = (gameData.onionData.sunlight / 100f);

        if(gameData.onionData.sunlight <= 0)
            GameManager.Instance.GameEnd();
    }
}
