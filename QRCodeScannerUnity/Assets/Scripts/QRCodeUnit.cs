using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRCodeUnit : MonoBehaviour
{
    [SerializeField] QRCodeScanner qRCodeScanner;
    void OnEnable()
    {
        qRCodeScanner.OnGetResult += DealData;
    }
    void OnDisable()
    {
        qRCodeScanner.OnGetResult -= DealData;
    }
    void DealData(string _data_str)
    {
        Debug.Log(this.name + " QRCodeUnit:" + _data_str);

    }
}
