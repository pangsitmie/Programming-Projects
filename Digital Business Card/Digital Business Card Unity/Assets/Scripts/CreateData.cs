using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CreateData : MonoBehaviour
{

    public BarcodeCam barcode;//BarcodeCam.cs


    public InputField inputMandarinName;
    public InputField inputEnglishName;
    public InputField inputJob;

    public InputField inputPhoneNumber;
    public InputField inputFixedNumber;
    public InputField inputMobileNumber;

    public InputField inputAddress;
    public InputField inputEmail;
    public Button submitButton;

    public Text hashText;


    private string url = "http://localhost/"; //the url or ip or domain of the destination database
    private string destinationUrl;

   public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        //if need more field just create new one
        //The format of AddField("database_fieldName", unity input.text);
        WWWForm form = new WWWForm();
        form.AddField("mandarinName", inputMandarinName.text);
        form.AddField("englishName", inputEnglishName.text);
        form.AddField("job", inputJob.text);
        form.AddField("phoneNumber", inputPhoneNumber.text);
        form.AddField("fixedNumber", inputFixedNumber.text);
        form.AddField("mobileNumber", inputMobileNumber.text);
        form.AddField("address", inputAddress.text);
        form.AddField("email", inputEmail.text);

        WWW www = new WWW("http://localhost/sqlconnect/register.php",form);
        
        
        yield return www;
        if(www.text =="0")
        {
            Debug.Log("User created succesfully");
            
        }
        else
        {
            Debug.Log("User creation fail"+www.text);

        }
        Debug.Log(www.text);
        hashText.text = www.text;
        destinationUrl = url + "sqlconnect/getContact.php?id=" + www.text;
        Debug.Log("destination url: "+destinationUrl);
        barcode.ChangeLastResult(destinationUrl);
    }
    public void VerifyInput()
    {
        //ngecek data valid atau ga untuk di submit
        submitButton.interactable = (inputEnglishName.text.Length >=8);
    }
}
