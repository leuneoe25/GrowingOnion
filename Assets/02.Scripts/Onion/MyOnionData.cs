using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OnionData", menuName = "OnionData")]
public class MyOnionData : ScriptableObject
{
    public string Name;
    public List<int> Stat;
    public int moisture;
    public int sunlight;

    [Header("Count")]
    public int outingCount;
    public int talkCount;
    public int phoneCount;
    public int dayCount;

    public void GetStat(OnionStat stat, int value = 1)
    {
        Stat[(int)stat] += value;
    }
}


public enum OnionStat
{
    knowledge,
    belief,
    innocence,
    alcohol,
    oldPower,
    fear,
    contactForce,
    game,
    muscle,
    talkativeness,
    otaku,
    excited,
    sing,
    confidence,
    vitality,
    depressed,
    jammin,
    worry,
    impoverished,
    comedy,
}

[Serializable]
public class StatValue
{
    public OnionStat onionStat;
    public int value;
    public StatValue(OnionStat onionStat, int value)
    {
        this.onionStat = onionStat;
        this.value = value;
    }
}