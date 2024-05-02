using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] PopUpMessage popUpMessage;
    [SerializeField] private StatMessage statMessage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            ShowPopUpMessage("�̰��� ���� �޼����̴�");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowPopUpMessage("�̰��� ���� �޼����̴�", MessageScale.Danger);
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            ShowStatMessage(OnionStat.knowledge, 2);
        }
    }

    public void ShowPopUpMessage(string message,MessageScale messageScale = MessageScale.Normal)
    {
        popUpMessage.ShowMessage(message, messageScale);
    }
    public void ShowStatMessage(OnionStat stat, int value)
    {
        statMessage.ShowMessage(stat, value);
    }
}
