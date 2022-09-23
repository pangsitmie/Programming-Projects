using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Location : MonoBehaviour
{
    string GPSResult = "";

    //=================================================================
    public event System.Action<string> OnGetGPS;//success result
    public event System.Action<string> OnGetAddress;//success result




    [System.Serializable]
    public class AddressClass
    {
        public int place_id;
        public string licence;
        public string osm_type;
        public long osm_id;
        public string lat;
        public string lon;
        public string display_name;
    }

    void Start()
    {
        StartCoroutine(StartGPS());
        StartCoroutine(GetAddress("http://nominatim.openstreetmap.org/reverse?format=json&lat=" + Input.location.lastData.latitude + "&lon=" + Input.location.lastData.longitude + "&zoom=18&addressdetails=1"));
    }

    IEnumerator StartGPS()
    {
        if (!Input.location.isEnabledByUser)
        {
            GPSResult = "isEnabledByUser value is:" + Input.location.isEnabledByUser.ToString() + "Please Turn on GPS";
            yield return false;
        }

        //location service starts
        Input.location.Start(10.0f, 10.0f);

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 1)
        {
            GPSResult = "Init GPS service time out";
            yield return false;
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GPSResult = "Unable to determine device location";
            yield return false;
        }
        else
        {
            GPSResult = "Lat: " + Input.location.lastData.latitude +
                    "\nLong: " + Input.location.lastData.longitude +
                    "\nTime: " + Input.location.lastData.timestamp;
            Debug.Log(GPSResult);
            OnGetGPS?.Invoke(GPSResult); //ACTION
            yield return new WaitForSeconds(100);
        }
    }

    void StopGPS()
    {
        Input.location.Stop();
        GPSResult = "Lat: " + Input.location.lastData.latitude +
                    "\nLong: " + Input.location.lastData.longitude +
                    "\nTime: " + Input.location.lastData.timestamp;
        Debug.Log(GPSResult);
    }
    public void updateGPS()
    {
        StartCoroutine(StartGPS());
        GPSResult = "Lat: " + Input.location.lastData.latitude +
                    "\nLong: " + Input.location.lastData.longitude +
                    "\nTime: " + Input.location.lastData.timestamp;
        Debug.Log(GPSResult);

        //get the address
        // A correct website page.
        StartCoroutine(GetAddress("http://nominatim.openstreetmap.org/reverse?format=json&lat=" +
                    Input.location.lastData.latitude + "&lon=" + Input.location.lastData.longitude + "&zoom=18&addressdetails=1"));
    }
    IEnumerator GetAddress(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;


            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    var text = webRequest.downloadHandler.text;
                    AddressClass addressClass = JsonUtility.FromJson<AddressClass>(text);
                    string jsonUtility = webRequest.downloadHandler.text;
                    string address = addressClass.display_name;

                    OnGetAddress?.Invoke(address); //ACTION
                    break;
            }
        }
    }
}