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
    public int outingCount;

    public void GetStat(OnionStat stat, int value = 1)
    {
        Stat[(int)stat] += value;
    }
}


public enum OnionStat
{
    knowledge,
    belief,
    concentric,
    alcohol,
    oldPower,
    feer,
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
public class TypeEffect
{
    public OnionStat onionStat;
    public int value;
}