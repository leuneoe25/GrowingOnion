using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaDetail : MonoBehaviour
{
    [SerializeField] private Image DarkBackground;
    [SerializeField] private GameObject DetailObject;

    [Header("Detail")]
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private TMP_Text ExplanationText;
    [SerializeField] private Image OnionImage;

    void Start()
    {
        
    }

    public void ShowDetail(Onion onion,Sprite onionSprite)
    {
        InitDetail(onion, onionSprite);
        DetailObject.GetComponent<CanvasGroup>().alpha = 0;
        DarkBackground.color = new Color(0, 0, 0, 0);
        DetailObject.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        DetailObject.transform.localScale = new Vector3(0f, 0f, 0f);
        DarkBackground.gameObject.SetActive(true);
        DetailObject.gameObject.SetActive(true);

        DarkBackground.DOFade(0.5f, 0.3f);
        DetailObject.transform.DOScale(new Vector3(1,1,1),0.3f).SetEase(Ease.InOutCubic);
    }

    public void HideDetail()
    {
        DetailObject.GetComponent<CanvasGroup>().DOFade(0, 0.3f);
        DarkBackground.DOFade(0, 0.3f).OnComplete(() =>
        {
            DarkBackground.gameObject.SetActive(false);
        });
        DetailObject.transform.DOScale(new Vector3(0f, 0f, 0f), 0.3f).SetEase(Ease.InOutCubic).OnComplete(() =>
        {
            DetailObject.gameObject.SetActive(false);
        });
    }
    private void InitDetail(Onion onion, Sprite onionSprite)
    {
        if(onionSprite != null)
            OnionImage.sprite = onionSprite;

        NameText.text = onion.OnionName;
        ExplanationText.text = onion.Desc;
    }
}
