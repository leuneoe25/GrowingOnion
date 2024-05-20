using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    private void Start()
    {
        GetEndingOnion(gameData);
    }
    public void GetEndingOnion(GameData gameData)
    {
        

        List<StatValue> SortedStatValues = new List<StatValue>();
        for(int i = 0; i < gameData.onionData.Stat.Count; i++)
        {
            SortedStatValues.Add(new StatValue((OnionStat)i, gameData.onionData.Stat[i]));
        }
        SortedStatValues.Sort(compare);

        Debug.Log(CheckTopStat(SortedStatValues, new List<OnionStat> { OnionStat.knowledge, OnionStat.belief }));

        if (CheckSectionEnding(gameData.EncyclopediaOnion, 1, 59) &&
            gameData.onionData.dayCount >= 8 &&
            gameData.onionData.moisture >= 60 &&
            gameData.onionData.sunlight >= 60)
        {
            //60 Ending;
        }
        else if(gameData.gameCount >= 1 &&
            gameData.onionData.dayCount >= 8 &&
            CheckRandom(0.2f))
        {
            //59 Ending
        }
        //else if ()
        //{

        //}
        else if (CheckSectionEnding(gameData.EncyclopediaOnion,28,45))
        {
            //+ 모든 지역을 갔을 때
            //57 Ending
        }
        else if (CheckSectionEnding(gameData.EncyclopediaOnion, 10, 27) &&
            CheckAllStat(gameData.onionData.Stat, 2))
        {
            // 56 Ending
        }
        //else if ()
        //{

        //}
        else if (gameData.gameCount >= 1 &&
            gameData.onionData.dayCount >= 8 &&
            CheckTopStat(SortedStatValues, new List<OnionStat> { OnionStat.innocence, OnionStat.talkativeness }))
        {
            //54 Ending
        }
        else if(gameData.gameCount >= 1 &&
            gameData.onionData.dayCount >= 8 &&
            CheckTopStat(SortedStatValues, new List<OnionStat> { OnionStat.jammin, OnionStat.confidence,OnionStat.excited }))
        {
            //53 Ending
        }
        else if(gameData.gameCount >= 1 &&
            gameData.onionData.dayCount >= 8 &&
            CheckTopStat(SortedStatValues, new List<OnionStat> { OnionStat.worry, OnionStat.innocence, OnionStat.knowledge }))
        {
            //52 Ending
        }
        else if(gameData.gameCount >= 1 &&
            gameData.onionData.dayCount >= 8 &&
            CheckTopStat(SortedStatValues, new List<OnionStat> { OnionStat.belief, OnionStat.sing }))
        {
            //51 Ending
        }
        else if (gameData.gameCount >= 1 &&
            gameData.onionData.dayCount >= 8 &&
            CheckTopStat(SortedStatValues, new List<OnionStat> { OnionStat.otaku, OnionStat.vitality,OnionStat.excited }))
        {
            //50 Ending
        }
        else if (gameData.gameCount >= 1 &&
            gameData.onionData.dayCount >= 8 &&
            CheckTopStat(SortedStatValues, new List<OnionStat> { OnionStat.muscle, OnionStat.fear }))
        {
            //49 Ending
        }
        else if (gameData.gameCount >= 1 &&
            gameData.onionData.dayCount >= 8 &&
            CheckTopStat(SortedStatValues, new List<OnionStat> { OnionStat.alcohol, OnionStat.oldPower }))
        {
            //48 Ending
        }
        else if (gameData.gameCount >= 1 &&
            gameData.onionData.dayCount >= 8 &&
            CheckTopStat(SortedStatValues, new List<OnionStat> { OnionStat.comedy, OnionStat.game }))
        {
            //47 Ending
        }
        else if (gameData.gameCount >= 1 &&
            gameData.onionData.dayCount >= 8 &&
            CheckTopStat(SortedStatValues, new List<OnionStat> { OnionStat.knowledge, OnionStat.depressed,OnionStat.impoverished }))
        {
            //46 Ending
        }

    }
    public void GetEndingOnion(int index)
    {

    }

    public bool CheckSectionEnding(int[] EncyclopediaOnion,int begin,int end)
    {
        begin -= 1;
        end -= 1;
        for (int i = begin;i < end;i++)
        {
            if(EncyclopediaOnion[i] < 1)
                return false;
        }
        return true;
    }
    public bool CheckMoisture(MyOnionData data, int value)
    {
        if (data.moisture >= value)
            return true;
        else
            return false;
    }
    public bool CheckRandom(float percentage)
    {
        if (Random.Range(0f, 100f) <= percentage)
            return true;
        else
            return false;

    }
    public bool CheckAllStat(List<int> Stat,int value)
    {
        for (int i = 0; i < Stat.Count; i++)
        {
            if (Stat[i] < value)
                return false;
        }
        return true;
    }
    public bool CheckTopStat(List<StatValue> Stat, List<OnionStat> index)
    {
        int repeatCount = index.Count;
        for (int i = 0;i < repeatCount; i++)
        {
            if (index.Contains(Stat[i].onionStat))
            {
                index.Remove(Stat[i].onionStat);
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    private int compare(StatValue a, StatValue b)
    {
        return a.value > b.value ? -1 : 1;
    }
}
