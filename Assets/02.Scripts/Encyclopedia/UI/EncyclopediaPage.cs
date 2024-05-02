using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncyclopediaPage : MonoBehaviour
{
    [SerializeField] private List<GameObject> Contents;

    public void InitContents(int[] EncyclopediaOnion, List<Onion> onionsData, EncyclopediaPageRange pageRange)
    {
        int index;
        for(int i = 0; i < Contents.Count; i++)
        {
            index = pageRange.begain + i;
            if(index > pageRange.end)
            {
                Contents[i].SetActive(false);
                continue;
            }


            if (EncyclopediaOnion[index] >= 1)
            {
                Contents[i].GetComponent<EncyclopediaElement>().ShowInfo(index,onionsData[index]);
            }
            else
            {
                Contents[i].GetComponent<EncyclopediaElement>().HideInfo(index,onionsData[index]);
            }
        }
    }
    
}
