using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "GameData")]
public class GameData : ScriptableObject
{
    public string PhonePath;
    public MyOnionData onionData;

    public void OnionDataReset()
    {
        onionData.Stat = new List<int>();
        for (int i = 0; i < 20; i++)
        {
            onionData.Stat.Add(0);
        }
        onionData.moisture = 100;
        onionData.sunlight = 100;

        onionData.outingCount = 0;
    }
}
