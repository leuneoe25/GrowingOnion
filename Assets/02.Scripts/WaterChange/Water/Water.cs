using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaterData")]
public class Water : ScriptableObject
{
    public string Name;
    public string description;
    public Sprite WaterSprite;

    [Header("Effect")]
    public int water;
    public StatValue typeEffect;
    public bool doubleStat;

}
