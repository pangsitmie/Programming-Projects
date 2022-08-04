using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public Slider slider;
    public float fillSpeed = 0.5f;
    private float targetProgress = 0;
    public void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        IncrementProgress(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress)
            slider.value += fillSpeed * Time.deltaTime;
    }
    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
}
