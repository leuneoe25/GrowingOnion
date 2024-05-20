using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatMessage : MonoBehaviour
{
    [SerializeField] private GameObject Canvers;
    [SerializeField] private TMP_Text MessageText;
    [Header("Pos")]
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    private float TakeTime = 1.5f;
    public void ShowMessage(OnionStat stat, int value)
    {
        TMP_Text message = Instantiate(MessageText, Canvers.transform);
        message.text = $"+ {GetKoreanStat(stat)} {value}";

        message.gameObject.transform.position = 
            new Vector3 (
                UnityEngine.Random.Range(pos1.position.x,pos2.position.x),
                UnityEngine.Random.Range(pos1.position.y, pos2.position.y), 0);

        StartCoroutine(Effect(message));
    }
    IEnumerator Effect(TMP_Text text)
    {
        text.alpha = 0;
        //canvasGroup.gameObject.SetActive(true);

        float restTime = 0.2f;
        float _TakeTime = TakeTime;
        _TakeTime -= restTime;

        //Show
        for (int i = 0; i < 50; i++)
        {
            text.alpha += 0.05f;
            yield return new WaitForSeconds((_TakeTime / 2) / 30);
        }
        //rest
        yield return new WaitForSeconds(restTime);

        //Hide
        for (int i = 0; i < 50; i++)
        {
            text.alpha -= 0.05f;
            yield return new WaitForSeconds((_TakeTime / 2) / 30);
        }
        //canvasGroup.gameObject.SetActive(false);
    }

    private string GetKoreanStat(OnionStat stat)
    {
        switch (stat)
        {
            case OnionStat.knowledge:
                return "����";
            case OnionStat.belief:
                return "�ų�";
            case OnionStat.innocence:
                return "����";
            case OnionStat.alcohol:
                return "���ڿ�";
            case OnionStat.oldPower:
                return "�����";
            case OnionStat.fear:
                return "����";
            case OnionStat.contactForce:
                return "������";
            case OnionStat.game:
                return "����";
            case OnionStat.muscle:
                return "����";
            case OnionStat.talkativeness:
                return "���ٷ�";
            case OnionStat.otaku:
                return "�ô���";
            case OnionStat.excited:
                return "�ų�";
            case OnionStat.sing:
                return "�뷡";
            case OnionStat.confidence:
                return "�ڽŰ�";
            case OnionStat.vitality:
                return "Ȱ��";
            case OnionStat.depressed:
                return "���";
            case OnionStat.jammin:
                return "��η�";
            case OnionStat.worry:
                return "���";
            case OnionStat.impoverished:
                return "����";
            case OnionStat.comedy:
                return "����";
            default:
                return string.Empty;
        }
        
    }
}
