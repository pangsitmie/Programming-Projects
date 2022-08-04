using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentHour;
    float currentMinute;
    float currentSecond;

    float startingHour = 0f;
    float startingMinute = 0f;
    float startingSecond = 0f;

    float progress = 0f;
    float target = 0f;

    [SerializeField] Image circleImg;

    [SerializeField] Text countDownText;
    [SerializeField] Text rewardText;


    public Text hourText;
    public Text minuteText;
    public Text secondText;

    // Start is called before the first frame update

    IEnumerator Start()
    {
        return null;
    }

    IEnumerator DoSomething()
    {
        target = (currentHour * 3600 + currentMinute * 59 + currentSecond);
        while (true)
        {
            countDownText.text = currentHour.ToString("0") + " : " + currentMinute.ToString("0") + " : " + currentSecond.ToString("0");
            
            float pluss = 1 / target;
            progress += pluss * Time.deltaTime;
            circleImg.fillAmount = progress;
            

            currentSecond -= 1 * Time.deltaTime;
            if (currentSecond <= 0)
            {
                if (currentMinute > 0)
                {
                    currentMinute--;
                    currentSecond = 59;
                }
                else if (currentHour == 0 && currentMinute == 0)
                {
                    currentSecond = 0;
                    rewardText.text = "GOOD JOB! \n YOU EARN "+ startingMinute+startingHour+"K DOLLAR \n FOR YOUR PRODUCTIVITY";
                }
                else
                {
                    currentHour--;
                    currentMinute = 60;
                    currentSecond = 0;
                }

            }


            // Yield execution of this coroutine and return to the main loop until next frame
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startTimer()
    {
        currentHour = startingHour;
        currentMinute = startingMinute;
        currentSecond = startingSecond;
        StartCoroutine("DoSomething");
        

    }
    public void plusHour()
    {
        startingHour++;
        if (startingHour >= 24)
            startingHour = 0;
        hourText.text = startingHour.ToString("0");
    }
    public void minHour()
    {
        startingHour--;
        if (startingHour < 0)
            startingHour = 23;
        hourText.text = startingHour.ToString("0");
    }
    public void plusMinute()
    {
        startingMinute++;
        if (startingMinute >= 60)
            startingMinute = 0;
        minuteText.text = startingMinute.ToString("0");
    }
    public void minMinute()
    {
        startingMinute--;
        if (startingMinute < 0)
            startingMinute = 59;
        minuteText.text = startingMinute.ToString("0");
    }
    public void plusSecond()
    {
        startingSecond++;
        if (startingSecond >= 60)
            startingSecond = 0;
        secondText.text = startingSecond.ToString("0");
    }
    public void minSecond()
    {
        startingSecond--;
        if (startingSecond < 0)
            startingSecond = 59;
        secondText.text = startingSecond.ToString("0");
    }
}
