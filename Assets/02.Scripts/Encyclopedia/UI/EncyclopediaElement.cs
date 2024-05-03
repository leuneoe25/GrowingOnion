using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaElement : MonoBehaviour
{
    public EncyclopediaDetail encyclopediaDetail;

    [SerializeField] private Image OnionImage;
    [SerializeField] private TMP_Text OnionName;
    public void ShowInfo(int index,Onion onion)
    {
        //Sprite sprite = Resources.Load<Sprite>(onion.OnionImagePath);
        OnionImage.color = Color.white;
        OnionName.text = $"No.{index+1} {onion.OnionName}";

        GetComponent<Button>().onClick.AddListener(() =>
        {
            encyclopediaDetail.ShowDetail(onion, null);
        });
    }
    public void HideInfo(int index,Onion onion)
    {
        //Sprite sprite = Resources.Load<Sprite>(onion.OnionImagePath);
        OnionImage.color = Color.black;
        OnionName.text = $"No.{index+1} ???";
    }
}
