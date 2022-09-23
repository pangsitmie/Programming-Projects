using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarHandler : MonoBehaviour
{
    [SerializeField] private GameObject calendarPanel;
    [SerializeField] private Text yearNumText;
    [SerializeField] private Text monthNumText;
    [SerializeField] private GameObject item;
    [SerializeField] private List<GameObject> dateItems = new List<GameObject>();
    Text target; // Where to display the result
    const int totalDateNum = 42;
    private DateTime dateTime;
    public static CalendarHandler calendarInstance;

    //public event System.Action<string> OnGetDateResult;//success result

    private bool isCalActive = false;
    void Start()
    {
        calendarInstance = this;
        Vector3 startPos = item.transform.localPosition;
        dateItems.Clear();
        dateItems.Add(item);

        for (int i = 1; i < totalDateNum; i++)
        {
            GameObject _item = GameObject.Instantiate(item) as GameObject;
            _item.name = "Item" + (i + 1).ToString();
            _item.transform.SetParent(item.transform.parent);
            _item.transform.localScale = Vector3.one;
            _item.transform.localRotation = Quaternion.identity;
            //Debug.Log("_item: " + _item.transform.GetComponent<RectTransform>().rect.width + "height: " + _item.transform.GetComponent<RectTransform>().rect.height);
            float padding = 10.0f;
            _item.transform.localPosition = new Vector3((i % 7) * (_item.transform.GetComponent<RectTransform>().rect.width + padding) +
                                            startPos.x, startPos.y - (i / 7) * (_item.transform.GetComponent<RectTransform>().rect.height + padding), startPos.z);
            dateItems.Add(_item);
        }

        dateTime = DateTime.Now;

        CreateCalendar();
        calendarPanel.SetActive(isCalActive);
    }
    void Update()
    {
        foreach (Touch touch in Input.touches)//If user press other than the Calender panel -> we will SetActive(false)
        {
            if (touch.position.y < (Screen.height * 0.25) || touch.position.y > (Screen.height * 0.75))
            {
                isCalActive = false;
                calendarPanel.SetActive(isCalActive);
            }
        }
    }

    void CreateCalendar()
    {
        DateTime firstDay = dateTime.AddDays(-(dateTime.Day - 1));
        int index = GetDays(firstDay.DayOfWeek);

        int date = 0;
        for (int i = 0; i < totalDateNum; i++)
        {
            Text label = dateItems[i].GetComponentInChildren<Text>();
            dateItems[i].SetActive(false);

            if (i >= index)
            {
                DateTime thatDay = firstDay.AddDays(date);
                if (thatDay.Month == firstDay.Month)
                {
                    dateItems[i].SetActive(true);

                    label.text = (date + 1).ToString();
                    date++;
                }
            }
        }
        yearNumText.text = dateTime.Year.ToString();
        monthNumText.text = dateTime.Month.ToString();
    }

    int GetDays(DayOfWeek _day)
    {
        switch (_day)
        {
            case DayOfWeek.Monday: return 1;
            case DayOfWeek.Tuesday: return 2;
            case DayOfWeek.Wednesday: return 3;
            case DayOfWeek.Thursday: return 4;
            case DayOfWeek.Friday: return 5;
            case DayOfWeek.Saturday: return 6;
            case DayOfWeek.Sunday: return 0;
        }

        return 0;
    }
    public void YearPrev()
    {
        dateTime = dateTime.AddYears(-1);
        CreateCalendar();
    }
    public void YearNext()
    {
        dateTime = dateTime.AddYears(1);
        CreateCalendar();
    }
    public void MonthPrev()
    {
        dateTime = dateTime.AddMonths(-1);
        CreateCalendar();
    }
    public void MonthNext()
    {
        dateTime = dateTime.AddMonths(1);
        CreateCalendar();
    }


    public void ShowCalendar(Text _target)
    {
        target = _target;
        isCalActive = !isCalActive;
        calendarPanel.SetActive(isCalActive);
    }

    public void OnDateItemClick(string _day)
    {
        string dateResult = yearNumText.text + "/" + monthNumText.text + "/" + _day;
        target.text = dateResult;
        //OnGetDateResult?.Invoke(dateResult);
        isCalActive = false;
        calendarPanel.SetActive(isCalActive);
    }
}
