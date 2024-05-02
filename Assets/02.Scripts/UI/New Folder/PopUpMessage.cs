using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpMessage : MonoBehaviour
{
    //[SerializeField] private float takeTime;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TMP_Text MessageText;

    private Coroutine EffectCoroutine;
    private float TakeTime = 1.5f;
    public void ShowMessage(string message, MessageScale scale = MessageScale.Normal)
    {
        if(EffectCoroutine != null)
            StopCoroutine(EffectCoroutine);

        MessageText.text = message;
        if(scale == MessageScale.Normal)
            MessageText.color = Color.white;
        else if (scale == MessageScale.Danger)
            MessageText.color = Color.red;

        EffectCoroutine = StartCoroutine(Effect());
    }
    IEnumerator Effect()
    {
        canvasGroup.alpha = 0;
        canvasGroup.gameObject.SetActive(true);

        float restTime = 0.2f;
        float _TakeTime = TakeTime;
        _TakeTime -= restTime;

        //Show
        for (int i = 0;i<50;i++)
        {
            canvasGroup.alpha += 0.05f;
            yield return new WaitForSeconds((_TakeTime / 2)/30);
        }
        //rest
        yield return new WaitForSeconds(restTime);

        //Hide
        for (int i = 0; i < 50; i++)
        {
            canvasGroup.alpha -= 0.05f;
            yield return new WaitForSeconds((_TakeTime / 2)/30);
        }
        canvasGroup.gameObject.SetActive(false);
    }

}
public enum MessageScale
{
    Normal,
    Danger
}
