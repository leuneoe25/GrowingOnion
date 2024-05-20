using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NutrientData")]
public class Nutrient : ScriptableObject
{
    public string Name;
    public string description;
    public Sprite NutrientSprite;

    [Header("Effect")]
    public StatValue typeEffect;
}
