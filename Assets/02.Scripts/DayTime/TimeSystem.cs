using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    private int Day = 1;
    public TMP_Text text;
    private DayTime nowTime;

    public delegate void ChangeTimeEvent(DayTime time);
    private ChangeTimeEvent changeTime;
    void Start()
    {
        nowTime = DayTime.Morning;
        text.text = Day.ToString();
    }

    public void GotoNextTime()
    {
        if(nowTime == DayTime.Evening)
        {
            //날짜 변경
            GameManager.Instance.EndDayEvent();

            //날짜 변경 이벤트

            GotoNextDay();
        }
        else
            nowTime++;

        ChangeTime(nowTime);
    }
    private void GotoNextDay()
    {
        Day++;
        text.text = Day.ToString();
        nowTime = DayTime.Morning;
    }

    public void ChangeTime(DayTime dayTime)
    {
        nowTime = dayTime;

        if (changeTime != null)
            changeTime(nowTime);
    }

    public void AddChangeTimeEvent(ChangeTimeEvent tevent)
    {
        changeTime += tevent;
    }
}
public enum DayTime
{
    Morning,
    Afternoon,
    Evening
}
