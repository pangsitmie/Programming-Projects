using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wheel : MonoBehaviour
{
    // Start is called before the first frame update
    private int randomValue;
    private float timeInterval;
    //private bool couroutineAllowed;
    private int finalAngle;




    [SerializeField]
    private Text winText;


    private Player player;
    // Use this for initialization

    void Start()
    {
        player = GameObject.Find("player").GetComponent<Player>();
        player.addBonusGold(10);
        //couroutineAllowed = true;
    }

    // Update is called once per frame

    
    private IEnumerator Spin()
    {
        //couroutineAllowed = false;
        randomValue = Random.Range(20, 30);
        timeInterval = 0.1f;
        for(int i=0;i<randomValue;i++)
        {
            transform.Rotate(0, 0, 22.5f);
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.2f;
            if (i > Mathf.RoundToInt(randomValue * 0.85f))
                timeInterval = 0.4f;
            yield return new WaitForSeconds(timeInterval);

        }
        if (Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
            transform.Rotate(0, 0, 22.5f);

        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);

        switch(finalAngle)
        {
            case 0:
                winText.text = "you get 10 Gold";
                player.addBonusGold(10);
                break;
            case 45:
                winText.text = "you get 10K Dollar";
                player.addBonusMoney(10000); 
                break;
            case 90:
                winText.text = "you get 15 Gold";
                player.addBonusGold(15); 
                break;
            case 135:
                winText.text = "you get 25K Dollar";
                player.addBonusMoney(25000); 
                break;
            case 180:
                winText.text = "you get 20 Gold";
                player.addBonusGold(20);
                break;
            case 225:
                winText.text = "you get 50K Dollar";
                player.addBonusMoney(50000); 
                break;
            case 270:
                winText.text = "you get 5 Gold";
                player.addBonusGold(5);
                break;
            case 315:
                winText.text = "you get 5K Dollar";
                player.addBonusMoney(5000);
                break;
        }
        //couroutineAllowed = true;
    }
    public void startSpin()
    {
        StartCoroutine(Spin());
    }
}
