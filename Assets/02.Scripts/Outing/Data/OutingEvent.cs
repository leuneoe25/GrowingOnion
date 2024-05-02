using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OutingEventData", menuName = "Outing/Event")]
public class OutingEvent : ScriptableObject
{
    public string title;
    public List<string> contents;
    public List<OutingChoiceEvent> ChoiceEvent;
    public List<TypeEffect> ResultEffect;
}

[Serializable]
public class OutingChoiceEvent
{
    public List<OutingEvent> events;
}