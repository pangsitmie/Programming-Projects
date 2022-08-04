using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class BarcodeCam : MonoBehaviour
{

    // QR code texture storage
    private Texture2D encoded;

    // Display the QR code in the UI
    [Tooltip("Put a picture of a rawimage")]
    public RawImage codeimage;

    // Identify the camera used by the QR code
    private WebCamTexture camTexture;

    // thread
    private Thread qrThread;

    //colour 
    private Color32[] c;
    //Width Height 
    private int W, H;

    //Screen rect
    private Rect screenRect;

    // Whether to quit
    private bool isQuit;

    //The final result
    [Tooltip("Detect url here, don't have to fill in")]
    public string LastResult;

    // Is it possible to code
    private bool shouldEncodeNow;

    // Is it possible to use
    private bool Isuse = false;

    void OnGUI()
    {
        GUI.DrawTexture(screenRect, camTexture, ScaleMode.ScaleToFit);
    }

    #region This method is used to identify
    /// <summary>
    /// This method is for identification
    /// </summary>
    void OnEnable()
    {
        if (camTexture != null)
        {
            //     camTexture.Play();
            W = camTexture.width;
            H = camTexture.height;
        }
    }

    void OnDisable()
    {
        if (camTexture != null)
        {
            camTexture.Pause();
        }
    }

    void OnDestroy()
    {
        if (qrThread != null)
        {
            qrThread.Abort();
        }

        if (camTexture != null)
        {
            camTexture.Stop();
        }
    }
    #endregion

    /// <summary>
    ///Program exit
    /// </summary>
    void OnApplicationQuit()
    {
        isQuit = true;
    }

    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        // encode the last found
        //use or not 
        if (Isuse)
        {
            // Get the last url
            var textForEncoding = LastResult;

            //can decode and the text is not empty
            if (shouldEncodeNow && textForEncoding != null)
            {
                // Get the QR code after production
                var color32 = Encode(textForEncoding, encoded.width, encoded.height);
                //pixel setting
                encoded.SetPixels32(color32);
                //application
                encoded.Apply();
                // QR code picture assignment
                codeimage.GetComponent<RawImage>().texture = encoded;
                // No need to parse again
                shouldEncodeNow = false;
            }
        }
    }

    void DecodeQR()
    {
        // Create a custom reader source brightness
        var barcodeReader = new BarcodeReader { AutoRotate = false, TryHarder = false };

        while (true)
        {
            if (isQuit)
                break;
            try
            {
                // decode the current frame
                var result = barcodeReader.Decode(c, W, H);
                // Determine whether the current is empty
                if (result != null)
                {
                    // Get the result text
                    LastResult = result.Text;
                    // Can display
                    shouldEncodeNow = true;
                    //URL
                    print(result.Text);
                }


                // Sleep a little and set the signal to get the next frame
                Thread.Sleep(200);
                c = null;
            }
            catch
            {
            }
        }
    }

    /// <summary>
    /// Create a QR code
    /// </summary>
    /// <param name="textForEncoding"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    private static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }

    /// <summary>
    /// Change the last url
    /// </summary>
    /// <param name="str"></param>
    public void ChangeLastResult(string str)
    {
        // Can be used to be true
        Isuse = true;
        // Set the texture
        encoded = new Texture2D(256, 256);
        // Get the last url
        LastResult = str;
        //I can decode now
        shouldEncodeNow = true;

        //screenRect = new Rect(0, 0, Screen.width, Screen.height);

        //camTexture = new WebCamTexture();
        //camTexture.requestedHeight = Screen.height; // 480;
        //camTexture.requestedWidth = Screen.width; //640;
        //OnEnable();

        // Open the thread
        qrThread = new Thread(DecodeQR);
        qrThread.Start();
    }
}
