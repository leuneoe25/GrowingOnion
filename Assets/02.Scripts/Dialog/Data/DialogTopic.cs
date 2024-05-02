using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogTopic", menuName = "Dialog/DialogTopic")]
public class DialogTopic : ScriptableObject
{
    public string topic;
    public List<DialogType> dialogTypes;
}
