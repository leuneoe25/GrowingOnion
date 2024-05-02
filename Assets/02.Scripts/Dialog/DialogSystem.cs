using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject UIObject;
    [SerializeField] private List<Button> choiceButtons;
    [Space(5f)]
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button DialogButton;

    [Header("Data")]
    [SerializeField] private List<DialogTopic> dialogTopics;

    public void Start()
    {
        DialogButton.onClick.AddListener(() =>
        {
            ShowUI();
            SetTopicTitle(dialogTopics);
        });
        ExitButton.onClick.AddListener(() =>
        {
            HideUI();
        });
    }

    public void ShowUI()
    {
        UIObject.SetActive(true);
    }
    public void HideUI()
    {
        UIObject.SetActive(false);
    }
    private void SetTopicTitle(List<DialogTopic> topics)
    {
        for (int i = 0; i < choiceButtons.Count; i++)
        {
            int index = i;
            SetButton(choiceButtons[i], topics[i].topic, () => { SetDialogTypes(topics[index].dialogTypes); });
        }
    }
    private void SetDialogTypes(List<DialogType> dialogType)
    {
        for (int i = 0; i < choiceButtons.Count; i++)
        {
            int index = i;
            if (i < dialogType.Count)
            {
                SetButton(choiceButtons[i], dialogType[i].TypeName, () =>
                {
                    for(int j = 0; j < dialogType[index].dialogTypeEffects.Count;j++)
                    {
                        GameManager.Instance.SetOnionStat(dialogType[index].dialogTypeEffects[j].onionStat,
                            dialogType[index].dialogTypeEffects[j].value);
                        //Debug.Log($"Add {dialogType[index].dialogTypeEffects[j].onionStat.ToString()} +{}");
                    }
                    HideUI();
                    GameManager.Instance.NextRoutine();
                });
            }
            else
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }
    private void SetButton(Button button, string titleText, Action onClick)
    {
        button.gameObject.SetActive(true);

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(()=> { onClick(); });

        button.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = titleText;
    }
}
