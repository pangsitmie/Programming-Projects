using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// This script is attached to calender item (item1 is datenumber 1 and so on)
public class CalendarDateItem : MonoBehaviour
{
    public void OnDateItemClick()
    {
        CalendarHandler.calendarInstance.OnDateItemClick(gameObject.GetComponentInChildren<Text>().text);
    }
}
