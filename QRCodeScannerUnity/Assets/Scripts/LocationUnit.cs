using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationUnit : MonoBehaviour
{
    [SerializeField] Location location;
    // public Text resultText;
    public Text result;
    void OnEnable()
    {
        location.OnGetGPS += DealGPSData;
        location.OnGetAddress += DealAddressData;
    }
    void OnDisable()
    {
        location.OnGetGPS += DealGPSData;
        location.OnGetAddress += DealAddressData;
    }

    void DealGPSData(string _data_str)
    {
        Debug.Log(this.name + " DealGPSData: " + _data_str);
    }

    void DealAddressData(string _data_str)
    {
        result.text = _data_str;
        Debug.Log(this.name + " DealAddressData: " + _data_str);
    }

}
