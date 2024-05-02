using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncyclopediaSystem : MonoBehaviour
{
    [SerializeField] private GameObject EncyclopediaUI;
    public void OpenEncyclopedia()
    {
        EncyclopediaUI.SetActive(true);
    }
    public void CloseEncyclopedia()
    {
        EncyclopediaUI.SetActive(false);
    }
}
