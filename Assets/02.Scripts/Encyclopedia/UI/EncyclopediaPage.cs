using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaPage : MonoBehaviour
{
    [SerializeField] private List<GameObject> Contents;
    public EncyclopediaDetail encyclopediaDetail;

    public void InitContents(int[] EncyclopediaOnion, List<Onion> onionsData, EncyclopediaPageRange pageRange)
    {
        int index;
        for(int i = 0; i < Contents.Count; i++)
        {
            index = pageRange.begain + i;
            if(index > pageRange.end)
            {
                //Contents[i].SetActive(false);
                Contents[i].GetComponent<CanvasGroup>().alpha = 0;
                Contents[i].GetComponent<CanvasGroup>().interactable = false;
                continue;
            }


            if (EncyclopediaOnion[index] >= 1)
            {
                Contents[i].GetComponent<EncyclopediaElement>().encyclopediaDetail = encyclopediaDetail;
                Contents[i].GetComponent<EncyclopediaElement>().ShowInfo(index,onionsData[index]);
            }
            else
            {
                Contents[i].GetComponent<EncyclopediaElement>().HideInfo(index,onionsData[index]);
            }
        }
    }
    
}
