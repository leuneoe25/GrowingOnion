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
                return "Áö½Ä";
            case OnionStat.belief:
                return "½Å³ä";
            case OnionStat.innocence:
                return "µ¿½É";
            case OnionStat.alcohol:
                return "¾ËÄÚ¿Ã";
            case OnionStat.oldPower:
                return "²Á´ë·Â";
            case OnionStat.fear:
                return "°øÆ÷";
            case OnionStat.contactForce:
                return "ÁÖÁ¢·Â";
            case OnionStat.game:
                return "°ÔÀÓ";
            case OnionStat.muscle:
                return "±ÙÀ°";
            case OnionStat.talkativeness:
                return "¼ö´Ù·Â";
            case OnionStat.otaku:
                return "¾Ã´ö·Â";
            case OnionStat.excited:
                return "½Å³²";
            case OnionStat.sing:
                return "³ë·¡";
            case OnionStat.confidence:
                return "ÀÚ½Å°¨";
            case OnionStat.vitality:
                return "È°·Â";
            case OnionStat.depressed:
                return "¿ì¿ï";
            case OnionStat.jammin:
                return "Àë¹Î·Â";
            case OnionStat.worry:
                return "°í¹Î";
            case OnionStat.impoverished:
                return "ÇÇÆó";
            case OnionStat.comedy:
                return "°³±×";
            default:
                return string.Empty;
        }
        
    }
}
