using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using TMPro;
using UnityEngine.UI;


public class QRCodeScanner : MonoBehaviour
{
    //========================================================================================
    #region 參數
    //=================================================================
    [Header("Reference")]
    [SerializeField] private RawImage display_rawImage;
    [SerializeField] private AspectRatioFitter _aspectRatioFilter;

    //=================================================================
    private bool _isCamAvailable;
    private WebCamTexture _cameraTexture;

    //=================================================================
    public event System.Action<string> OnGetResult;//success result

    //=================================================================
    #endregion
    //========================================================================================
    #region UnityEvent
    //=================================================================
    void Start()
    {
        StartCoroutine(Test());
        SetCamera();

    }

    //=================================================================
    void Update()
    {
        if (display_rawImage == null)
        {
            return;
        }
        UpdateCameraRender();
        Scan();
    }

    //=================================================================
    #endregion
    //========================================================================================
    #region 實作內容
    //=================================================================
    IEnumerator Test()
    {
        yield return new WaitForSeconds(1.0f);
        OnGetResult?.Invoke("Test");
    }
    public bool SetCamera()
    {
        //-------------------------------------------------------------
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            _isCamAvailable = false;
            print("no device");
            return false;
        }

        //-------------------------------------------------------------
        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing == false)
            {
                _cameraTexture = new WebCamTexture(devices[i].name, (int)Screen.width, (int)Screen.height, 60);
            }

        }

        //-------------------------------------------------------------
        _cameraTexture.Play();
        display_rawImage.texture = _cameraTexture;
        _isCamAvailable = true;
        return true;

        //-------------------------------------------------------------
    }

    private void UpdateCameraRender()
    {
        if (_isCamAvailable == false)
        {
            return;
        }
        float ratio = (float)_cameraTexture.width / (float)_cameraTexture.height;
        _aspectRatioFilter.aspectRatio = ratio;

        int orientation = -_cameraTexture.videoRotationAngle;
        display_rawImage.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }
    private void Scan()
    {
        try
        {
            BarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(_cameraTexture.GetPixels32(), _cameraTexture.width, _cameraTexture.height);
            if (result == null)
            {
                Debug.LogWarning("Failed to read qr code");
            }
            OnGetResult?.Invoke(result.Text);
        }
        catch
        {
            Debug.LogError("Failed in try");
        }
    }
    //=================================================================
    #endregion
    //========================================================================================
}
