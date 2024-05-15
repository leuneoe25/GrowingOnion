using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "GameData")]
public class GameData : ScriptableObject
{
    public string PhonePath;
    public int[] EncyclopediaOnion;
    public MyOnionData onionData;

    [Header("Item")]
    public List<MyNutrient> myNutrients;
    public List<MyWater> myWater;

    public void OnionDataReset()
    {
        onionData.Stat = new List<int>();
        for (int i = 0; i < 20; i++)
        {
            onionData.Stat.Add(0);
        }

        EncyclopediaOnion = new int[60];
        for (int i = 0; i < 60; i++)
        {
            EncyclopediaOnion[i] = 0;
        }

        myNutrients = new List<MyNutrient>();
        myWater = new List<MyWater>();

        onionData.moisture = 100;
        onionData.sunlight = 100;

        onionData.outingCount = 0;
    }
}
