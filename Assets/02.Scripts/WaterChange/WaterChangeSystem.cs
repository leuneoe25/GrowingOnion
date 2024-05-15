using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaterChangeSystem : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private ChangeCamera changeCamera;

    [Header("Prefab")]
    [SerializeField] private GameObject WaterChangeElementPrefab;
    [SerializeField] private Water TapWater;

    [Header("UI")]
    [SerializeField] private GameObject NutrientScrollViewContent;
    [SerializeField] private GameObject NutrientScrollViewContentChild;
    [SerializeField] private GameObject WaterScrollViewContent;
    [SerializeField] private GameObject WaterScrollViewContentChild;


    [SerializeField] private Button WaterPurifierButton;
    [SerializeField] private Button NutrientCancelButton;

    [Header("Object")]
    [SerializeField] private GameObject Beaker;
    [SerializeField] private GameObject MainBeaker;

    private bool isProgress;
    private Water selectWater;
    void Start()
    {
        Init();

        WaterPurifierButton.onClick.AddListener(() =>
        {
            if (selectWater != null)
                return;

            SelectWater(TapWater);
        });
        NutrientCancelButton.onClick.AddListener(() =>
        {
            NutrientCancelButton.gameObject.SetActive(false);
            SelectNutrient(null);
        });
    }

    public void Init()
    {
        if (isProgress)
            return;

        StartCoroutine(InitData());
    }
    private IEnumerator InitData()
    {
        //destry
        for (int i = 0; i < NutrientScrollViewContentChild.transform.childCount; i++)
        {
            Destroy(NutrientScrollViewContentChild.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < WaterScrollViewContentChild.transform.childCount; i++)
        {
            Destroy(WaterScrollViewContentChild.transform.GetChild(i).gameObject);
        }

        //init
        foreach(var item in gameData.myNutrients)
        {
            GameObject obj = Instantiate(WaterChangeElementPrefab, NutrientScrollViewContentChild.transform);

            obj.transform.GetChild(0).GetComponent<TMP_Text>().text = item.nutrient.Name;
            obj.transform.GetChild(1).GetComponent<TMP_Text>().text = item.count.ToString();

            obj.GetComponent<Button>().onClick.AddListener(() =>
            {
                NutrientCancelButton.gameObject.SetActive(false);
                SelectNutrient(item.nutrient);
            });
        }
        NutrientScrollViewContentChild.GetComponent<CanvasGroup>().interactable = false;


        foreach (var item in gameData.myWater)
        {
            GameObject obj = Instantiate(WaterChangeElementPrefab, WaterScrollViewContentChild.transform);

            obj.transform.GetChild(0).GetComponent<TMP_Text>().text = item.water.Name;
            obj.transform.GetChild(1).GetComponent<TMP_Text>().text = item.count.ToString();

            obj.GetComponent<Button>().onClick.AddListener(() =>
            {
                SelectWater(item.water);
            });
        }
        WaterScrollViewContentChild.GetComponent<CanvasGroup>().interactable = true;

        yield return new WaitForFixedUpdate();
        NutrientScrollViewContent.GetComponent<RectTransform>().sizeDelta =
            NutrientScrollViewContentChild.GetComponent<RectTransform>().sizeDelta;
        WaterScrollViewContent.GetComponent<RectTransform>().sizeDelta =
            WaterScrollViewContentChild.GetComponent<RectTransform>().sizeDelta;
    }
    private void SelectWater(Water water)
    {
        //물 사라지기 예약
        Debug.Log($"선택 : {water.Name}");
        selectWater = water;
        Beaker.SetActive(true);

        WaterScrollViewContentChild.GetComponent<CanvasGroup>().interactable = false;

        ReadyNutrient();
    }
    private void ReadyNutrient()
    {
        //반짝반짝
        NutrientCancelButton.gameObject.SetActive(true);
        NutrientScrollViewContentChild.GetComponent<CanvasGroup>().interactable = true;
    }
    private void SelectNutrient(Nutrient nutrient)
    {
        
        if(nutrient != null)
        {
            GameManager.Instance.NextDayEvent += () =>
            {
                if(selectWater.doubleStat)
                {
                    GameManager.Instance.SetOnionStat(
                    nutrient.typeEffect.onionStat, nutrient.typeEffect.value * 2);
                }
                else
                {
                    GameManager.Instance.SetOnionStat(nutrient.typeEffect);
                }
            };
        }

        GameManager.Instance.NextDayEvent += () =>
        {
            GameManager.Instance.SetMoisture(selectWater.water);

            GameManager.Instance.SetOnionStat(selectWater.typeEffect);
        };



        StartCoroutine(EndWaterChange());
    }
    private IEnumerator EndWaterChange()
    {
        yield return new WaitForSeconds(0.5f);
        changeCamera.ChangeMainScene();
        yield return new WaitForSeconds(0.5f);
        MainBeaker.GetComponent<Image>().DOFade(0, 0.7f).SetLoops(2, LoopType.Yoyo);
    }
}
