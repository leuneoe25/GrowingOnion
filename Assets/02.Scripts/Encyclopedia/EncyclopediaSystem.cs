using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncyclopediaSystem : MonoBehaviour
{
    [SerializeField] private GameObject EncyclopediaUI;
    [SerializeField] protected EncyclopediaBook encyclopediaBook;
    public void OpenEncyclopedia()
    {
        EncyclopediaUI.SetActive(true);

        encyclopediaBook.InitPage(1);
    }
    public void CloseEncyclopedia()
    {
        EncyclopediaUI.SetActive(false);
    }
}
