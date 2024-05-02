using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlaceData", menuName = "Outing/Place")]
public class Place : ScriptableObject
{
    public string PlaceName;

    public OutingEvent NomalEvent;
    public OutingEvent HiddenEvent;
}
