using NiobiumStudios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Player : MonoBehaviour
{



    public Chair initiateC = new Chair(null,null,0,0,null);
    public static List<Chair> ChairColl;

    public Table initiateT = new Table(null, null, 0, 0, null);
    public static List<Table> TableColl;
    
    public Speaker initiateSpeaker = new Speaker(null, null, 0, 0, null);
    public static List<Speaker> SpeakerColl;

    public Lamp initiateLamp= new Lamp(null, null, 0, 0, null);
    public static List<Lamp> LampColl;


    public Monitor initiateMonitor = new Monitor(null, null, 0, 0, null,null);
    public static List<Monitor> MonitorColl;


    public House initiateH = new House(null, 0, null);
    public static List<House> HouseColl;


    //public Reward daily = new Reward();//aneh
    [Space]
    public float nextActionTime = 3f;
    public float Moneyperiod = 3f;
    public float period;//hubungan e mbe gold container
    public double bitcoinTime=0;
    public int GoldContainer = 0;
    public GameObject claimGoldContainer;
    public GameObject GoldNotReadyText;
    public double bitcoinReward;
    //XP Progress Bar
    public Slider slider;
    public float fillSpeed = 0.5f;
    private float targetProgress = 0;
    public int vibrateSetting;
    public static int currentVibrateSetting;

    [Space]
    [Header("Stats Text")]
    public Text MoneyText;
    public Text LevelText;
    public GameObject LevelUpUI;
    public Text LevelTextUI;
    public Text GoldText;
    public Text EPSText;
    public Text workingTextAnim;
    public Text workingTextAnim2;
    public Text GoldContainerText;
    public Text BitcoinRewardText;

    [Space]
    [Header("House")]
    //public Text HouseName;
    //public Text HousePrice;
    //reward
    [Space]
    public Text Timer;
    int IdleTimeSetting = 60;
    float LastIdleTime;


    public  static double moneys;
    [Space]
    [Header("Money")]
    public double  money;
    public double getMoneys()
    {
        return money;
    }
    public double tempMoney;
    public static int golds;
    public int gold;
    public int getGolds()
    {
        return golds;
    }
    
    public int level=1;
    static float countToNextLevel = 25;
    public double eps=5;

    [Space]
    [Header("Last Item Index")]
    public int LastChairIndex = 0;
    public int CurrentChairIndex = 0;
    public int LastTableIndex = 0;
    public int CurrentTableIndex = 0;
    public int LastSpeakerIndex = 0;
    public int CurrentSpeakerIndex = 0;
    public int LastLampIndex = 0;
    public int CurrentLampIndex = 0;
    public int LastMonitorIndex = 0;
    public int LastHouseIndex = 1;

    [Space]
    public double AwayEps = 1;
    public int giftMultiplier = 0;
    public int GoldTime = 1800;
    public float exp = 1;
    public float countToNextLevelTemp = 0;
    public DateTime timeOff=DateTime.Now;
    public DateTime timeOn = DateTime.Now;
    public int maxAwayEarnings = 100000;

    [Space]
    [Header("Skills Level")]
    public int PublicSpeakingLevel = 1;
    public int ClosingLevel = 1;
    public int EmailMarketingLevel = 1;
    public int SocialMediaMarketingLevel = 1;
    public int InvestingLevel = 1;
    public int DigitalMarketingLevel = 1;
    public int CopyWritingLevel = 1;

    [Space]
    [Header("Skills LevelText")]
    public Text CopyWritingText;
    public Text InvestingText;
    public Text DigitalMarketingText;
    public Text SocialMediaMarketingText;
    public Text EmailMarketingText;
    public Text ClosingText;
    public Text PublicSpeakingText;

    [Space]
    [Header("Skills Price")]
    public int CopywritingPrice = 0;
    public int InvestingPrice = 0;
    public int DigitalmarketingPrice = 0;
    public int SocialmediaPrice = 0;
    public int EmailmarketingPrice = 0;
    public int ClosingPrice = 0;
    public int PublicspeakingPrice = 0;

    [Space]
    [Header("Skills Bonus")]
    public Text CopyWritingLevelBonus;
    public Text InvestingLevelBonus;
    public Text DigitalMarketingLevelBonus;
    public Text SocialMediaMarketingLevelBonus;
    public Text EmailMarketingLevelBonus;
    public Text ClosingLevelBonus;
    public Text PublicSpeakingLevelBonus;

    [Space]
    [Header("Skills EXP")]
    public Text CopyWritingEXP;
    public Text InvestingEXP;
    public Text DigitalMarketingEXP;
    public Text SocialMediaMarketingEXP;
    public Text EmailMarketingEXP;
    public Text ClosingEXP;
    public Text PublicSpeakingEXP;

    [Space]
    [Header("Skills Timer")]
    public GameObject CopywritingTimer;
    public Text CopywritingTimerText;

    public GameObject InvestingTimer;
    public Text InvestingTimerText;

    public GameObject DigitalMarketingTimer;
    public Text DigitalMarketingTimerText;

    public GameObject SocialMediaMarketingTimer;
    public Text SocialMediaMarketingTimerText;

    public GameObject EmailMarketingTimer;
    public Text EmailMarketingTimerText;

    public GameObject ClosingTimer;
    public Text ClosingTimerText;

    public GameObject PublicSpeakingTimer;
    public Text PublicSpeakingTimerText;



    [Space]
    [Header("Computer Level")]
    public int ComputerLevel = 1;
    public int ProcessorLevel = 1;
    public int MemoryLevel = 1;
    public int GraphicsLevel = 1;
    public int StorageLevel = 1;
    public int InternetLevel = 1;
    [Space]
    [Header("Computer Price")]
    //public int ComputerPrice = 20000;
    public int ProcessorPrice = 25000;
    public int MemoryPrice = 30000;
    public int GraphicPrice = 35000;
    public int StoragePrice = 40000;
    public int InternetPrice = 50000;

    [Space]
    [Header("Computer Level Text")]
    public Text ProcessorText;
    public Text MemoryText;
    public Text GraphicsText;
    public Text StorageText;
    public Text InternetText;

    [Space]
    [Header("Computer Bonus Text")]
    public Text ProcessorTextBonus;
    public Text MemoryTextBonus;
    public Text GraphicsTextBonus;
    public Text StorageTextBonus;
    public Text InternetTextBonus;

    [Space]
    [Header("Computer EXP Text")]
    public Text ProcessorTextEXP;
    public Text MemoryTextEXP;
    public Text GraphicsTextEXP;
    public Text StorageTextEXP;
    public Text InternetTextEXP;



    [Space]
    [Header("Animator")]
    public Animator AppearanceUIAnim;
    public Animator SkillsUIAnim;
    public Animator ProductivityAnim;
    public Animator ShopUIAnim;
    public Animator HouseAnim;
    public Animator PurchaseFX;
    public Animator HouseFX;
    public Animator GadgetPurchaseFX;
    public Animator BitcoinFX;
    //public Animator AddMoneyFX;
    //public Animator AddMoneyFX2;

    [Space]
    [Header("Sprites Renderer")]
    public SpriteRenderer BackgroundSR;//house sprite
    public SpriteRenderer ShirtSR;
    public SpriteRenderer ChairSR;
    public SpriteRenderer TableSR;
    public SpriteRenderer SpeakerSR;
    public SpriteRenderer MonitorSR;
    public SpriteRenderer CPUSR;

    [Space]
    [Header("Computer UI")]
    public Image MonitorUI;
    public Image CPUUI;
    public Text Computer;
    public Text ComputerLevelText;

    [Space]
    [Header("Chair Price Text")]
    //Chair Price Text & image
    public Text RChairPrice;
    public Text EChairPrice;
    public Text LChairPrice;
    public Image RChairImage;
    public Image EChairImage;
    public Image LChairImage;

    [Space]
    [Header("Table Price Text")]
    //Table Price Text & image
    public Text RTablePrice;
    public Text ETablePrice;
    public Text LTablePrice;
    public Image RTableImage;
    public Image ETableImage;
    public Image LTableImage;

    [Space]
    [Header("Speaker Price Text")]
    //Headphone Price Text & image
    public Text RSpeakerPrice;
    public Text ESpeakerPrice;
    public Text LSpeakerPrice;
    public Image RSpeakerImage;
    public Image ESpeakerImage;
    public Image LSpeakerImage;
    public SpriteRenderer CSpeakerSprite;
    public SpriteRenderer RSpeakerSprite;
    public SpriteRenderer RSpeakerSpriteInLeft;
    public SpriteRenderer RSpeakerSpriteInRight;
    public SpriteRenderer ESpeakerSprite;
    public SpriteRenderer ESpeakerSpriteIn;
    public SpriteRenderer LSpeakerSprite;
    public SpriteRenderer LSpeakerSpriteInLeft;
    public SpriteRenderer LSpeakerSpriteInRight;
    

    [Space]
    [Header("Lamp Price Text")]
    //glasses Price Text & image
    public Text RLampPrice;
    public Text ELampPrice;
    public Text LLampPrice;
    public Image RLampImage;
    public Image ELampImage;
    public Image LLampImage;
    public SpriteRenderer CLampSprite;
    public SpriteRenderer RLampSprite;
    public SpriteRenderer ELampSprite;
    public SpriteRenderer LLampSprite;


    [Space]
    [Header("Computer Price Text")]
    //Computer Upgrade
    public Text Procesor;
    public Text Memory;
    public Text Graphics;
    public Text Storage;
    public Text Internet;

    [Space]
    [Header("FX Image")]
    public Image PreviousImage;
    public Image NextImage;
    public Image GadgetPreviousImage;
    public Image GadgetNextImage;

    [Space]
    [Header("Start_Up")]
    public Text StartUpPriceText;
    public int StartUpLevel;
    public int StartUpPrice = 100;
    public int StartUpBonus = 0;
    public bool funnelClicked = false;
    public bool affiliateClicked = false;

    [Space]
    [Header("Away Reward")]
    public Text AwayRewardText;
    public GameObject claimAwayEarnings;

    [Space]
    [Header("Away Earnings Canvas")]
    public GameObject awayEarningsCanvas;

    [Space]
    [Header("Idle")]
    public GameObject idleReminder;

    double rand = 1000;
    double baseSkillsUpgradeTime =60;
    public double remainingSkillsUpgradeTime;
    public int skillState = 0;
    
    
    



    public void SavePlayer()
    {
        //timeOff = DateTime.Now;
        SaveSystem.SavePlayer(this);
        //jsut tring to save the first item purchased
        //SaveSystem.SaveItem(ItemsColl[0]);        

    }
   
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        money = data.money;
        gold = data.gold;
        eps = data.eps;
        timeOff = data.timeOff;
        Debug.Log("data time off" + data.timeOff);
        LastChairIndex = data.LastChairIndex;
        CurrentChairIndex = data.CurrentChairIndex;
        LastTableIndex = data.LastTableIndex;
        CurrentTableIndex = data.CurrentTableIndex;
        LastSpeakerIndex = data.LastSpeakerIndex;
        CurrentSpeakerIndex = data.CurrentSpeakerIndex;
        LastLampIndex = data.LastLampIndex;
        CurrentLampIndex = data.CurrentLampIndex;
        LastMonitorIndex = data.LastMonitorIndex;
        LastHouseIndex = data.LastHouseIndex;
        PublicSpeakingLevel = data.PublicSpeakingLevel;
        ClosingLevel = data.ClosingLevel;
        EmailMarketingLevel = data.EmailMarketingLevel;
        SocialMediaMarketingLevel = data.SocialMediaMarketingLevel;
        InvestingLevel = data.InvestingLevel;
        DigitalMarketingLevel = data.DigitalMarketingLevel;
        CopyWritingLevel = data.CopyWritingLevel;
        ProcessorLevel = data.ProcessorLevel;
        MemoryLevel = data.MemoryLevel;
        GraphicsLevel = data.GraphicsLevel;
        StorageLevel = data.StorageLevel;
        InternetLevel = data.InternetLevel;
        
        maxAwayEarnings = data.maxAwayEarnings;
        StartUpLevel = data.StartUpLevel;
        StartUpPrice = data.StartUpPrice;
        StartUpBonus = data.StartUpBonus;
        GoldContainer = data.GoldContainer;
        funnelClicked = data.funnelClicked;
        affiliateClicked = data.affiliateClicked;
        vibrateSetting = data.vibrateSetting;
        skillState = data.skillState;
        remainingSkillsUpgradeTime = data.remainingSkillUpgradeTime;

        
    }
    public void skillButtonClicked()
    {
        CopywritingPrice = CopyWritingLevel * 5000 * 4;
        InvestingPrice = InvestingLevel * 11000 * 6;
        DigitalmarketingPrice = DigitalMarketingLevel * 15000 * 6;
        SocialmediaPrice = SocialMediaMarketingLevel * 18000 * 6;
        EmailmarketingPrice = EmailMarketingLevel * 22000 * 4;
        ClosingPrice = ClosingLevel * 26000 * 4;
        PublicspeakingPrice = PublicSpeakingLevel * 30000 * 8;


        GameObject.Find("buttonPS").GetComponentInChildren<Text>().text = "$" + moneyConverter(PublicspeakingPrice);
        GameObject.Find("buttonCL").GetComponentInChildren<Text>().text = "$" + moneyConverter(ClosingPrice);
        GameObject.Find("buttonEM").GetComponentInChildren<Text>().text = "$" + moneyConverter(EmailmarketingPrice);
        GameObject.Find("buttonSM").GetComponentInChildren<Text>().text = "$" + moneyConverter(SocialmediaPrice);
        GameObject.Find("buttonDM").GetComponentInChildren<Text>().text = "$" + moneyConverter(DigitalmarketingPrice);
        GameObject.Find("buttonINV").GetComponentInChildren<Text>().text = "$" + moneyConverter(InvestingPrice);
        GameObject.Find("buttonCW").GetComponentInChildren<Text>().text = "$" + moneyConverter(CopywritingPrice);

    }

    public void startUpClicked()
    {
         printStartup();
        int StartUpPrice = ((int)(Math.Pow(2, StartUpLevel) * 100));
        StartUpPriceText.text = "$" + StartUpPrice.ToString();
           if (funnelClicked == true)
        {
            GameObject.Find("FunnelButton").GetComponent<Button>().interactable = false;
        }

        if (affiliateClicked == true)
        {
            GameObject.Find("AffiliateButton").GetComponent<Button>().interactable = false;
        }
    }

    /*
    void OnApplicationQuit()
    {
        if (System.Timers.Timer.enabled == true) {
            Timer.Stop();
        }
    }
    */

    void Start()
    {
        Debug.Log("Timeoff sblm load: " + timeOff);
        //Debug.Log(Application.persistentDataPath);


        PublicSpeakingLevel = 1;
        ClosingLevel = 1;
        EmailMarketingLevel = 1;
        SocialMediaMarketingLevel = 1;
        InvestingLevel = 1;
        DigitalMarketingLevel = 1;
        CopyWritingLevel = 1;

        level = 1;
        money = 100;


        ProcessorLevel = 1;
        MemoryLevel = 1;
        GraphicsLevel = 1;
        StorageLevel = 1;
        InternetLevel = 1;
        
        LoadPlayer();

        updateSetting();
            /*
        if (vibrateSetting == 1)
            currentVibrateSetting = 1;
        else
            updateSetting();
            */





        //Debug.Log("vibraet setting: " + vibrateSetting);




        timeOn = DateTime.Now;

        Debug.Log("Timeon: " + timeOn);
        
        Debug.Log("Timeoff: " + timeOff);

        TimeSpan ts = timeOn - timeOff;
        
        
        Debug.Log("seconds passed: " + ts.TotalSeconds);
        
        if(ts.TotalSeconds>=120)//tiap 2 menit off baru isa masuk away earnings cekno ga benkali buka metu canvase trs
        {
            EarningWhileAway(ts.TotalSeconds * AwayEps);
        }
        Debug.Log("Startskillstaete: " + skillState);
        if(skillState==1)
        {
            remainingSkillsUpgradeTime -= ts.TotalSeconds;
            CopywritingTimerText.text = remainingSkillsUpgradeTime.ToString();
            Debug.Log("remaining upgrade time: "+remainingSkillsUpgradeTime);
        }
         



        ComputerLevel = LastMonitorIndex+1;
        
        printMoney();
        printSkills();
        printGold();
        printEps();
        

        initiateC.addChair(this);
        ChairColl = Chair.Chairs;

        initiateT.addTable(this);
        TableColl = Table.Tables;

        initiateSpeaker.addSpeaker(this);
        SpeakerColl = Speaker.Speakers;

        initiateLamp.addLamp(this);
        LampColl = Lamp.Lamps;


        initiateMonitor.addMonitor(this);
        MonitorColl = Monitor.Monitors;


        initiateH.addHouse(this);
        HouseColl = House.Houses;

        



        ChairSR.sprite = ChairColl[CurrentChairIndex].getItemSprite();
        TableSR.sprite = TableColl[CurrentTableIndex].getItemSprite();
        startSpeaker(CurrentSpeakerIndex);
        startLamp(CurrentLampIndex);
        MonitorSR.sprite = MonitorColl[LastMonitorIndex].getItemSprite();
        CPUSR.sprite = MonitorColl[LastMonitorIndex].getItemSprite2();//2 ini maksude ndapetno atribut sprite ke 2
        BackgroundSR.sprite = HouseColl[LastHouseIndex].getItemSprite();

        LevelText.text = level.ToString();//stats level player e

        printHardware();
        ComputerUI(ComputerLevel);//print all computer UI
        printHouse(LastHouseIndex+2);
        printFurniture();
        rand = UnityEngine.Random.Range(1, 10) * 5;//dapetno berapa menit setelah period mari trs lek menit ini ws mari bitcoin bakal muncul
        Debug.Log("start random bitcoin:" + rand);
    }
    void Update()
    {
        addDailyReward();
        printMoney();
        printGold();
        printEps();
        GoldContainerText.text = GoldContainer.ToString();
        checkGoldCanBeCollected();
        checkIfQuitButtonIsPressed();///buat application quit


        //updateSetting();


        double epsR = Math.Round((double)eps, 2);
        //Debug.Log(Time.time);
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + Moneyperiod;
            money += (float)epsR * (level / 10);
            tempMoney = money;
            countToNextLevelTemp += fillSpeed;
        }
        period += Time.deltaTime;
        bitcoinTime += Time.deltaTime;
        printSkillTimer();//buat ngeprint dan update skill timer countdown

        /*
        if (StartUpLevel > 0)
        {
            if(period/300>0)
            {
                //setiap 5 mnt dapet bonus startupbonus
                GoldContainer += StartUpBonus;
            }
        }
        */
        if (period >= 600)//aslie 600
        {
            period = 0;
            GoldContainer += StartUpBonus;//ws tak masukno nde function savegold
            SaveGold();

            //buat ngeaktifno bitcoin
            Debug.Log("sblm randm");
            if (bitcoinTime > rand)
            {
                rand = UnityEngine.Random.Range(30, 60);//dapetno berapa menit setelah period mari trs lek menit ini ws mari bitcoin bakal muncul
                rand *= 10;
                Debug.Log("Random value created: " + rand);
            }
            

        }
        if(bitcoinTime>=rand)
        {
            bitcoinTime = 0;
            Debug.Log("period>=rand and bitcoin animation activated");
            PopBitcoin();
        }

        if (Input.anyKey)
        {
            LastIdleTime = Time.time;
            timeOff = DateTime.Now;
        }
        


        IdleCheck();

        //Debug.Log(LastMonitorIndex);

        refreshSlider();
        SavePlayer();
    }
    public void printSkillTimer()
    {
        if (skillState == 1)
        {
            CopywritingTimer.SetActive(true);
            remainingSkillsUpgradeTime -= Time.deltaTime;

            CopywritingTimerText.text = remainingSkillsUpgradeTime.ToString("0");
            Debug.Log("skill state" + skillState);
            if (remainingSkillsUpgradeTime <= 0)
            {
                skillState = 0;
            }
        }
        else if (skillState ==0)
        {
            Debug.Log("upgrade finish");
            remainingSkillsUpgradeTime = baseSkillsUpgradeTime;
            CopywritingTimer.SetActive(false);
            skillState = 0;
            Debug.Log("skill state" + skillState);
        }
            
    }
    

    void checkIfQuitButtonIsPressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Application.Quit();
            }
            else
                SceneManager.LoadScene(1);
        }
    }

    /*
    void checkAwayEarningCanBeCollected(int earnings)
    {
        
        if (earnings >= 0)
        {
            claim.SetActive(true);
            GoldNotReadyText.SetActive(false);
        }
        else
        {
            claimGoldContainer.SetActive(false);
            GoldNotReadyText.SetActive(true);

        }
        
    }
    */
    void checkGoldCanBeCollected()
    {
        if(GoldContainer>=5)
        {
            claimGoldContainer.SetActive(true);
            GoldNotReadyText.SetActive(false);
        }
        else
        {
            claimGoldContainer.SetActive(false);
            GoldNotReadyText.SetActive(true);

        }
    }

    public void EarningWhileAway(double earnings)
    {
        if(earnings > maxAwayEarnings)
        {
            earnings = maxAwayEarnings;
        }
        money += earnings;
        AwayRewardText.text ="$ " + moneyConverter((int)earnings);
        showAwayEarnings();
    }

    public void refreshSlider()
    {
        if (countToNextLevelTemp >= countToNextLevel)
        {
            //increase the level and then print it
            level++;
            eps = eps + (eps * level / 200);
            LevelText.text = level.ToString();
            LevelUpUI.SetActive(true);
            LevelTextUI.text = level.ToString();

            //increase the required press to get to next level

            countToNextLevelTemp = countToNextLevelTemp - countToNextLevel;
            countToNextLevel = countToNextLevel * (float)2.0;
        }
        slider.value = countToNextLevelTemp / countToNextLevel;
    }
   
    public void SaveGold()
    {
        if(GoldContainer < 20)
        {
            GoldContainer++;
            GoldContainer += StartUpBonus;
        }
    }

    /*
    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
    */
    public void addDailyReward()
    {
        gold += golds;
        money += moneys;
        golds = 0;
        moneys = 0;
        printMoney();
        printGold();
    }
    public void updateSetting()
    {

        vibrateSetting = currentVibrateSetting;
        SavePlayer();
    }

    public void addMoney()
    {
        //increase the money and print it
        double epsR = Math.Round((double)eps, 2);
        money += (float)epsR;
        tempMoney = money;
        printMoney();
        
        vibrate();
        //Debug.Log(currentVibrateSetting + "." + vibrateSetting);
        

        //increase the count needed to next level
        countToNextLevelTemp+= exp;
        refreshSlider();


        //timeOff = DateTime.Now;
        //XP Progress Bar
        //IncrementProgress(0.1f);

    }
    public void addBonusMoney(float n)
    {
        money += n;
    }
    public void addBonusGold(int n)
    {
        gold += n;
    }
    void printGold()
    {
        GoldText.text = gold.ToString();
    }

    void printMoney()
    {
       
        if(money>1000 && money < 1000000)
        {
            tempMoney=money / 1000;
            MoneyText.text = tempMoney.ToString("F2")+ "K";
        }
        else if(money>=1000000 && money < 1000000000)
        {
            tempMoney = money / 1000000;
            MoneyText.text = tempMoney.ToString("F2") + "M";
        }
        else if (money >= 1000000000 && money < 1000000000000)
        {
            tempMoney = money / 1000000000;
            MoneyText.text = tempMoney.ToString("F2") + "B";
        }
        else if (money >= 1000000000000 && money < 1000000000000000)
        {
            tempMoney = money / 1000000000000;
            MoneyText.text = tempMoney.ToString("F2") + "T";
        }
        else if (money >= 1000000000000000 && money < 1000000000000000000)
        {
            tempMoney = money / 1000000000000000;
            MoneyText.text = tempMoney.ToString("F2") + "Qi";
        }
        else
        {
            MoneyText.text = money.ToString("F2");
        }

    }


    string moneyConverter(int moneys) {

        string converted = "";
        if (moneys >= 1000 && moneys < 1000000)
        {
            tempMoney = moneys / 1000;
            converted = tempMoney.ToString("F2") + "K";
        }
        else if (moneys >= 1000000 && moneys < 1000000000)
        {
            tempMoney = moneys / 1000000;
            converted = tempMoney.ToString("F2") + "M";
        }
        else if (money >= 1000000000 && money < 1000000000000)
        {
            tempMoney = money / 1000000000;
            MoneyText.text = tempMoney.ToString("F2") + "B";
        }
        else if (money >= 1000000000000 && money < 1000000000000000)
        {
            tempMoney = money / 1000000000000;
            MoneyText.text = tempMoney.ToString("F2") + "T";
        }
        else if (money >= 1000000000000000 && money < 1000000000000000000)
        {
            tempMoney = money / 1000000000000000;
            MoneyText.text = tempMoney.ToString("F2") + "Qi";
        }
        else
        {
            converted = moneys.ToString("F2");
        }

        return converted;  
    }

    
    void printEps()
    {
        double epsR = Math.Round((double)eps, 2);
        

        if (epsR >= 1000 && epsR < 1000000)
        {
            epsR = epsR / 1000;
            EPSText.text = epsR.ToString("F2") + "K";           
        }
        else if (epsR >= 1000000 && epsR < 1000000000)
        {
            epsR = epsR / 1000000;
            EPSText.text = epsR.ToString("F2") + "M";            
        }
        else if (epsR >= 1000000000 && epsR < 1000000000000)
        {
            epsR = epsR / 1000000000;
            EPSText.text = epsR.ToString("F2") + "B";
        }
        else if (epsR >= 1000000000000 && epsR < 1000000000000000)
        {
            epsR = epsR / 1000000000000;
            EPSText.text = epsR.ToString("F2") + "T";
        }
        else if (epsR >= 1000000000000000 && epsR < 1000000000000000000)
        {
            epsR = epsR / 1000000000000000;
            EPSText.text = epsR.ToString("F2") + "Qi";
        }
        else
        {
            EPSText.text = epsR.ToString("F2");
        }
        workingTextAnim.text = "$ " + EPSText.text;
        //workingTextAnim2.text = "$ " + EPSText.text;
    }
    void printSkills()
    {
        //print the level
        CopyWritingText.text ="Level "+ CopyWritingLevel.ToString();
        InvestingText.text = "Level " + InvestingLevel.ToString();
        DigitalMarketingText.text = "Level " + DigitalMarketingLevel.ToString();
        SocialMediaMarketingText.text = "Level " + SocialMediaMarketingLevel.ToString();
        EmailMarketingText.text = "Level " + EmailMarketingLevel.ToString();
        ClosingText.text = "Level " + ClosingLevel.ToString();
        PublicSpeakingText.text = "Level " + PublicSpeakingLevel.ToString();
        //print the bonus
        CopyWritingLevelBonus.text = "+" + (CopyWritingLevel * 5 * fillSpeed/fillSpeed).ToString() + "% exp gain per second";
        InvestingLevelBonus.text = "+" + (InvestingLevel * 3 * exp/exp).ToString() + "% exp per tap";
        DigitalMarketingLevelBonus.text = "-" + (DigitalMarketingLevel * 2 * GoldTime/GoldTime).ToString() + "% filling gold time";
        SocialMediaMarketingLevelBonus.text = "+" + (SocialMediaMarketingLevel * 2).ToString() + "00% gift multiplier";
        EmailMarketingLevelBonus.text = "+" + (EmailMarketingLevel * 1.5 * AwayEps/AwayEps).ToString() + "% away earnings per second";
        ClosingLevelBonus.text = "- 15% auto tap time";
        PublicSpeakingLevelBonus.text = "+" + (PublicSpeakingLevel * 2 * eps/eps).ToString() + "% earnings per second";
       
        //print additional exp
        CopyWritingEXP.text = "+ " + ((CopyWritingLevel+1)*10) + " EXP";
        InvestingEXP.text = "+ " + ((InvestingLevel+1) * 10) + " EXP";
        DigitalMarketingEXP.text = "+ " + ((DigitalMarketingLevel) * 10) + " EXP";
        SocialMediaMarketingEXP.text = "+ " + ((SocialMediaMarketingLevel+1) * 10) + " EXP";
        EmailMarketingEXP.text = "+ " + ((EmailMarketingLevel+1) * 10) + " EXP";
        ClosingEXP.text = "+ " + ((ClosingLevel+1) * 10) + " EXP";
        PublicSpeakingEXP.text = "+ " + ((PublicSpeakingLevel+1) * 10) +" EXP";
    }

    void printHardware()
    {

        ProcessorPrice = ProcessorLevel * 21500 * 8;
        MemoryPrice = MemoryLevel * 26000 * 10;
        GraphicPrice = GraphicsLevel * 31000 * 12;
        StoragePrice = StorageLevel * 35000 * 14;
        InternetPrice = InternetLevel * 41000 * 16;

        //print hardware level
        ProcessorText.text = "Level " + ProcessorLevel.ToString();
        MemoryText.text = "Level " + MemoryLevel.ToString();
        GraphicsText.text = "Level " + GraphicsLevel.ToString();
        StorageText.text = "Level " + StorageLevel.ToString();
        InternetText.text = "Level " + InternetLevel.ToString();
        //print hardware bonus effect
        ProcessorTextBonus.text = "+" + (ProcessorLevel * 15 * eps/eps) + "% earnings per second"; ;
        MemoryTextBonus.text = "- 45% auto tap time";
        GraphicsTextBonus.text = "+" + (GraphicsLevel * 20 * AwayEps/AwayEps) + "% away earnings per second";
        StorageTextBonus.text = "-" + (StorageLevel * 8 * GoldTime/GoldTime) + "% filling gold time";
        InternetTextBonus.text = "+" + (InternetLevel * 30 * fillSpeed / fillSpeed) + "% exp gain per second";


        GameObject.Find("buttonGPU").GetComponentInChildren<Text>().text = "$" + moneyConverter(GraphicPrice);
        GameObject.Find("buttonST").GetComponentInChildren<Text>().text = "$" + moneyConverter(StoragePrice);
        GameObject.Find("buttonINT").GetComponentInChildren<Text>().text = "$" + moneyConverter(InternetPrice);
        GameObject.Find("buttonMM").GetComponentInChildren<Text>().text = "$" + moneyConverter(MemoryPrice);
        GameObject.Find("buttonCPU").GetComponentInChildren<Text>().text = "$" + moneyConverter(ProcessorPrice);

        //print hardware exp
        ProcessorTextEXP.text = "+ " + ((ProcessorLevel+1)*30) + " EXP";
        MemoryTextEXP.text = "+ " + ((MemoryLevel + 1)*30) + " EXP";
        GraphicsTextEXP.text = "+ " + ((GraphicsLevel + 1)*30) + " EXP";
        StorageTextEXP.text = "+ " + ((StorageLevel + 1)*30) + " EXP";
        InternetTextEXP.text = "+ " + ((InternetLevel + 1)*30) + " EXP";
    }

    public void GoldContainerClick()
    {
        if(GoldContainer < 5)
        {
            Debug.Log("Still Under 5");
        }
        else
        {
            //GameObject.Find("Gold Button").GetComponentInChildren<Text>().text = moneyConverter(CopywritingPrice);
            claimGoldContainer.SetActive(false);
            gold += GoldContainer;
            GoldContainer = 0;
        }
    }

    public void AwayEarningClick()
    {

    }

    //SkillsClick
    public void CopyWritingClick()
    {
        if (CopyWritingLevel < level && money >= CopywritingPrice)
        {
            Debug.Log("copyclicked");
            money -= CopywritingPrice;
            printMoney();
            CopywritingPrice = CopyWritingLevel * 8000 * 2;
            GameObject.Find("buttonCW").GetComponentInChildren<Text>().text = "$" + moneyConverter(CopywritingPrice);

            CopywritingTimer.SetActive(true);
            skillState = 1; 




            //----------------------------efek ini kebawah baru aktif setelah remainingUpgradeTime<=0-----------------------------
            CopyWritingLevel += 1;
            exp += CopyWritingLevel * 10;
            //CopyWritingLevelBonus.text = "+" + (CopyWritingLevel * 20).ToString() + "% permanent exp gain per second";
            fillSpeed = fillSpeed + ((CopyWritingLevel * 5 * fillSpeed) / 100);
            //Debug.Log("FillSpeed: " + fillSpeed);
            printSkills();
            //---------------------------------------------------------------------------------------------------------------------
            SavePlayer();





        }
        else
        {
            //Debug.Log("Maxed");
        }
    }
    public void PublicSpeakingClick()
    {
        if(PublicSpeakingLevel < level && money >= PublicspeakingPrice)
        {
            PublicSpeakingLevel += 1;
            //PublicSpeakingLevelBonus.text = "+" + (PublicSpeakingLevel * 10).ToString() + "% earnings per second";
            eps = eps + ((PublicSpeakingLevel * 2 * eps)/eps);
            Debug.Log("EPS: " + eps);
            money -= PublicspeakingPrice;
            exp += PublicSpeakingLevel*10;
            printMoney();
            printEps();
            PublicspeakingPrice = PublicSpeakingLevel * 30000 * 4;
            GameObject.Find("buttonPS").GetComponentInChildren<Text>().text = "$"+moneyConverter(PublicspeakingPrice);
            printSkills();
            //PublicSpeakingTimer.SetActive(true);
        }
        else
        {
            Debug.Log("Maxed");
        }
    }
    public void ClosingClick()
    {
        if (ClosingLevel < level && money >= ClosingPrice)
        {
            ClosingLevel += 1;
            //ClosingLevelBonus.text = "-" + ((float)ClosingLevel*0.2).ToString() + "auto tap time";
            Moneyperiod = Moneyperiod * 0.98f;
            //nextActionTime -= (float)((float)ClosingLevel * 0.2);
            Debug.Log("Next action time: " + nextActionTime);
            money -= ClosingPrice;
            exp += ClosingLevel*10;
            printMoney();
            ClosingPrice = ClosingLevel * 26000 * 3;
            GameObject.Find("buttonCL").GetComponentInChildren<Text>().text = "$" + moneyConverter(ClosingPrice);
            printSkills();
            //ClosingTimer.SetActive(true);
        }
        else
        {
            Debug.Log("Maxed");
        }
    }
    public void EmailMarketingClick()
    {
        if (EmailMarketingLevel < level && money >= EmailmarketingPrice)
        {
            EmailMarketingLevel += 1;
            exp += EmailMarketingLevel*10;
            //EmailMarketingLevelBonus.text = "+" + (EmailMarketingLevel * 20).ToString() + "% away earnings per second";
            AwayEps = AwayEps + ((EmailMarketingLevel * 1.5 * AwayEps) / AwayEps);
            Debug.Log("Away EPS: " + AwayEps);
            money -= EmailmarketingPrice;
            printMoney();
            EmailmarketingPrice = EmailMarketingLevel * 22000 * 5;
            GameObject.Find("buttonEM").GetComponentInChildren<Text>().text = "$" + moneyConverter(EmailmarketingPrice);
            printSkills();
            //EmailMarketingTimer.SetActive(true);
        }
        else
        {
            Debug.Log("Maxed");
        }
    }
    public void SocialMediaClick()
    {
        if (SocialMediaMarketingLevel < level && money >= SocialmediaPrice)
        {
            SocialMediaMarketingLevel += 1;
            exp += SocialMediaMarketingLevel*10;
            //SocialMediaMarketingLevelBonus.text = "+" + (SocialMediaMarketingLevel * 10).ToString() + "% gift multiplier";
            giftMultiplier = giftMultiplier + (SocialMediaMarketingLevel*2);
            Debug.Log("gift Multiplier: " + giftMultiplier);
            money -= SocialmediaPrice;
            printMoney();
            SocialmediaPrice = SocialMediaMarketingLevel * 18000 * 4;
            GameObject.Find("buttonSM").GetComponentInChildren<Text>().text = "$" + moneyConverter(SocialmediaPrice);
            printSkills();
            //SocialMediaMarketingTimer.SetActive(true);
        }
        else
        {
            Debug.Log("Maxed");
        }
    }
    public void DigitalMarketingClick()
    {
        if (DigitalMarketingLevel < level && money >= DigitalmarketingPrice)
        {
            DigitalMarketingLevel += 1;
            exp += DigitalMarketingLevel*10;
            //DigitalMarketingLevelBonus.text = "-" + (DigitalMarketingLevel * 5).ToString() + "% filling gold time";
            GoldTime -= ((DigitalMarketingLevel * 2 * GoldTime) / 100);
            //Debug.Log("Gold Time: " + GoldTime);
            money -= DigitalmarketingPrice;
            printMoney();
            DigitalmarketingPrice = DigitalMarketingLevel * 15000 * 3;
            GameObject.Find("buttonDM").GetComponentInChildren<Text>().text = "$" + moneyConverter(DigitalmarketingPrice);
            printSkills();
            //DigitalMarketingTimer.SetActive(true);
        }
        else
        {
            //Debug.Log("Maxed");
        }
    }
    public void InvestingClick()
    {
        if (InvestingLevel < level && money >= InvestingPrice)
        {
            InvestingLevel += 1;
            exp += InvestingLevel*10;
            //InvestingLevelBonus.text = "+" + (InvestingLevel * 25).ToString() + "% exp per tap";
            exp = exp + ((InvestingLevel * 3 * exp) / 100);
            //Debug.Log("exp: " + exp);
            money -= InvestingPrice;
            printMoney();
            InvestingPrice = InvestingLevel * 11000 * 3;
            GameObject.Find("buttonINV").GetComponentInChildren<Text>().text = "$" + moneyConverter(InvestingPrice);
            printSkills();
            //InvestingTimer.SetActive(true);
        }
        else
        {
            //Debug.Log("Maxed");
        }
    }
    

    //Hardwares Click
    public void ProcessorClick()
    {
        ////Debug.Log("Proc");
        if(ProcessorLevel < level && money >= ProcessorPrice)
        {
            ProcessorLevel++;
            eps = eps + ((ProcessorLevel *5 * eps) / 100);
            //Debug.Log("EPS: " + eps);
            money -= ProcessorPrice;
            exp += ProcessorLevel*30;
            printMoney();
            printEps();
            printHardware();
            ProcessorPrice = ProcessorLevel * 31500 * 8;
            GameObject.Find("buttonCPU").GetComponentInChildren<Text>().text = "$"+moneyConverter(ProcessorPrice);
        }
        else
        {
            //Debug.Log("Maxed");
        }
    }
    public void MemoryClick()
    {
        ////Debug.Log("Memo");
        if (MemoryLevel < level && money >= MemoryPrice)
        {
            MemoryLevel++;
            Moneyperiod = Moneyperiod * 0.9f;
            money -= MemoryPrice;
            exp += MemoryLevel*30;
            printMoney();
            MemoryPrice = MemoryLevel * 21000 * 10;
            GameObject.Find("buttonMM").GetComponentInChildren<Text>().text = "$" + moneyConverter(MemoryPrice);
            printHardware();

        }
        else
        {
            //Debug.Log("Maxed");
        }
    }
    public void GraphicsClick()
    {
        ////Debug.Log("Grap");
        if (GraphicsLevel < level && money >= GraphicPrice)
        {
            GraphicsLevel++;
            money -= GraphicPrice;
            printMoney();
            exp += GraphicsLevel*30;
            GraphicPrice =  GraphicsLevel * 29000 * 12;
            AwayEps = AwayEps + ((GraphicsLevel * 5 * AwayEps) / 100);
            //Debug.Log("Away EPS: " + AwayEps);
            GameObject.Find("buttonGPU").GetComponentInChildren<Text>().text = "$" + moneyConverter(GraphicPrice);
            printHardware();

        }
        else
        {
            //Debug.Log("Maxed");
        }
    }
    public void StorageClick()
    {
        ////Debug.Log("Stor");
        if (StorageLevel < level && money >= StoragePrice)
        {
            StorageLevel++;
            money -= StoragePrice;
            printMoney();
            exp += StorageLevel*30;
            StoragePrice = StorageLevel * 33000 * 14;
            GoldTime -= ((StorageLevel * 5 * GoldTime) / 100);
            //Debug.Log("Gold Time: " + GoldTime);
            GameObject.Find("buttonST").GetComponentInChildren<Text>().text = "$" + moneyConverter(StoragePrice);
            printHardware();

        }
        else
        {
            //Debug.Log("Maxed");
        }
    }
    public void InternetClick()
    {
        ////Debug.Log("Inte");
        if (InternetLevel < level && money >= InternetPrice)
        {
            InternetLevel++;
            money -= InternetPrice;
            printMoney();
            exp += InternetLevel*30;
            InternetPrice = InternetLevel * 41000 * 16;
            fillSpeed = fillSpeed + ((InternetLevel * 15 * fillSpeed) / 100);
            //Debug.Log("FillSpeed: " + fillSpeed);
            GameObject.Find("buttonINT").GetComponentInChildren<Text>().text = "$" + moneyConverter(InternetPrice);
            printHardware();
        }
        else
        {
           //Debug.Log("Maxed");
        }
    }


    //-------------------------------------------------------------------START UP------------------------------------------
    public void StartUpCLick() {
        if(gold >= StartUpPrice && StartUpLevel <= level)
        {
            //Debug.Log("befor print startup sucess ");
            
            StartUpLevel++;
            gold -= StartUpPrice;
            StartUpPrice = StartUpPrice * 2;
            StartUpPriceText.text = StartUpPrice.ToString();
            printStartup();
            //Debug.Log("after print startup sucess ");

        }
    }
    public void buyStartUp(int n)
    {
        if(gold>=n)
        {
            gold -= n;
            StartUpBonus += 2;
            //GameObject.Find(s).GetComponent<Button>().interactable = false;
        }
    }
    public void printStartup()
    {
        if(StartUpLevel ==0)
        {
            GameObject.Find("FunnelButton").GetComponent<Button>().interactable = false;
            GameObject.Find("AffiliateButton").GetComponent<Button>().interactable = false;
        }
        else
        {
            GameObject.Find("FunnelButton").GetComponent<Button>().interactable = true;
            GameObject.Find("AffiliateButton").GetComponent<Button>().interactable = true;
        }
    }

    public void funnelClick()
    {
        if (gold >= 25) {
            funnelClicked = true;
            StartUpBonus += 1;
            exp += 300;
            GameObject.Find("FunnelButton").GetComponent<Button>().interactable = false;
        }
    }

    public void AffilateClick()
    {
        if (gold >= 25)
        {
            affiliateClicked = true;
            StartUpBonus += 1;
            exp += 300;
            GameObject.Find("AffiliateButton").GetComponent<Button>().interactable = false;
        }
    }

    public void printFurniture()
    {
        //chair
        if(LastChairIndex==1)
        {
            RChairPrice.text = "";
            RChairImage.enabled = false;
        }
        else if(LastChairIndex == 2)
        {
            RChairPrice.text = "";
            RChairImage.enabled = false;
            EChairPrice.text = "";
            EChairImage.enabled = false;
        }
        else if(LastChairIndex == 3)
        {
            RChairPrice.text = "";
            RChairImage.enabled = false;
            EChairPrice.text = "";
            EChairImage.enabled = false;
            LChairPrice.text = "";
            LChairImage.enabled = false;
        }
        
        //table
        if(LastTableIndex==1)
        {
            RTablePrice.text = "";
            RTableImage.enabled = false;
        }
        else if(LastTableIndex==2)
        {
            RTablePrice.text = "";
            RTableImage.enabled = false;
            ETablePrice.text = "";
            ETableImage.enabled = false;
        }
        else if (LastTableIndex == 3)
        {
            RTablePrice.text = "";
            RTableImage.enabled = false;
            ETablePrice.text = "";
            ETableImage.enabled = false;
            LTablePrice.text = "";
            LTableImage.enabled = false;
        }
            
    }

    void printHouse(int n)
    {
        GameObject.Find("HouseButton1").GetComponent<Button>().interactable = false;
        for (int i = 2; i <= 8; i++)//8 = index total banyak house +1
        {
            string house = "HouseButton" + i.ToString();
            //Debug.Log(house);
            if (i < 8)
            {
                if (i != n)
                {
                    GameObject.Find(house).GetComponent<Button>().interactable = false;
                    //GameObject.Find(house).GetComponent<Button>().gameObject.SetActive(false);
                }
                else
                {
                    GameObject.Find(house).GetComponent<Button>().interactable = true;
                    //GameObject.Find(house).GetComponent<Button>().gameObject.SetActive(true);
                }
            }

        }

    }
    //House purchas
    public void housePurchase(int index)
    {
        if (HouseColl[index].Checklocked() == true)
        {
            //Debug.Log("Still Locked");
        }
        else
        {
            if (money >= HouseColl[index].getItemPrice())
            {
                PopHouseFX();
                money = money - HouseColl[index].getItemPrice();
                eps += HouseColl[index].getItemPrice() * 0.005;
                printMoney();
                HouseColl[index].bought();
                
                BackgroundSR.sprite = HouseColl[index].getItemSprite();
                if (index > LastHouseIndex)
                {
                    LastHouseIndex = index;
                }
                if (index < HouseColl.Count - 1)
                {
                    HouseColl[index + 1].unlocked();
                }
                printHouse(index+2);
                ////Debug.Log(ChairColl[index + 1].Checklocked());
                SavePlayer();
            }
            else
            {
                //Debug.Log("Uang tidak mencukupi");
            }
        }

    }

    //Gadget purchases

    public void chairPurchase(int index)
    {
        if (ChairColl[index].Checklocked() == true)
        {
            //Debug.Log("Still Locked");
        }
        else
        {
            if (gold >= ChairColl[index].getItemPrice())
            {
                
                Debug.Log("pop chair berhasil");
                ////Debug.Log(ChairColl[index].getName());
                ////Debug.Log("Before:" + gold);
                gold = gold - ChairColl[index].getItemPrice();
                ////Debug.Log("After:" + gold);
                printGold();
                //changeChairCommon();
                ////Debug.Log("change chaircommon succesfull");
                ChairColl[index].bought();
                if (index == 1)
                {
                    RChairPrice.text = "";
                    RChairImage.enabled = false;
                }
                if (index == 2)
                {
                    EChairPrice.text = "";
                    EChairImage.enabled = false;
                }
                if (index == 3)
                {
                    LChairPrice.text = "";
                    LChairImage.enabled = false;
                }
                PopChairPurchaseFX(index);

                CurrentChairIndex = index;
                ChairSR.sprite = ChairColl[CurrentChairIndex].getItemSprite();
                

                if (index > LastChairIndex)
                {
                    LastChairIndex = index;
                }
                if (index < ChairColl.Count - 1)
                {
                    ChairColl[index + 1].unlocked();
                }
                ////Debug.Log(ChairColl[index + 1].Checklocked());
                
                SavePlayer();
            }
            else
            {
                //Debug.Log("Uang tidak mencukupi");
            }
        }
    }
   
    public void tablePurchase(int index)
    {
        if (TableColl[index].Checklocked() == true)
        {
            //Debug.Log("Still Locked");
        }
        else
        {
            if (gold >= TableColl[index].getItemPrice())
            {
                ////Debug.Log("Before:" + gold);
                gold = gold - TableColl[index].getItemPrice();
                // //Debug.Log("After:" + gold);
                printGold();
                //changeChairCommon();
                // //Debug.Log("change chaircommon succesfull");
                TableColl[index].bought();
                if (index == 1)
                {
                    RTablePrice.text = "";
                    RTableImage.enabled = false;
                }
                if (index == 2)
                {
                    ETablePrice.text = "";
                    ETableImage.enabled = false;
                }
                if (index == 3)
                {
                    LTablePrice.text = "";
                    LTableImage.enabled = false;
                }
                PopTablePurchaseFX(index);

                CurrentTableIndex = index;
                TableSR.sprite = TableColl[CurrentTableIndex].getItemSprite();
                if (index > LastTableIndex)
                {
                    LastTableIndex = index;
                }
                if (index < TableColl.Count - 1)
                {
                    TableColl[index + 1].unlocked();
                }
                
                SavePlayer();
            }
            else
            {
                //Debug.Log("Uang tidak mencukupi");
            }
        }
    }
    void startSpeaker(int index)
    {
        if (index == 1)
        {
            RSpeakerPrice.text = "";
            RSpeakerImage.enabled = false;

            CSpeakerSprite.enabled = false;
            RSpeakerSprite.enabled = true;
            RSpeakerSpriteInLeft.enabled = true;
            RSpeakerSpriteInRight.enabled = true;
            ESpeakerSprite.enabled = false;
            ESpeakerSpriteIn.enabled = false;
            LSpeakerSprite.enabled = false;
            LSpeakerSpriteInLeft.enabled = false;
            LSpeakerSpriteInRight.enabled = false;

            Debug.Log("rare");
        }
        if (index == 2)
        {
            ESpeakerPrice.text = "";
            ESpeakerImage.enabled = false;

            CSpeakerSprite.enabled = false;
            RSpeakerSprite.enabled = false;
            RSpeakerSpriteInLeft.enabled = false;
            RSpeakerSpriteInRight.enabled = false;
            ESpeakerSprite.enabled = true;
            ESpeakerSpriteIn.enabled = true;
            LSpeakerSprite.enabled = false;
            LSpeakerSpriteInLeft.enabled = false;
            LSpeakerSpriteInRight.enabled = false;
            Debug.Log("epic");
        }
        if (index == 3)
        {
            LSpeakerPrice.text = "";
            LSpeakerImage.enabled = false;

            CSpeakerSprite.enabled = false;
            RSpeakerSprite.enabled = false;
            RSpeakerSpriteInLeft.enabled = false;
            RSpeakerSpriteInRight.enabled = false;
            ESpeakerSprite.enabled = false;
            ESpeakerSpriteIn.enabled = false;
            LSpeakerSprite.enabled = true;
            LSpeakerSpriteInLeft.enabled = true;
            LSpeakerSpriteInRight.enabled = true;
            Debug.Log("legend");
        }
    }
    public void speakerPurchase(int index)
    {
        if (SpeakerColl[index].Checklocked() == true)
        {
            //Debug.Log("Still Locked");
        }
        else
        {
            if (gold >= SpeakerColl[index].getItemPrice())
            {
                ////Debug.Log("Before:" + gold);
                gold = gold - SpeakerColl[index].getItemPrice();
                // //Debug.Log("After:" + gold);
                printGold();
                //changeChairCommon();
                // //Debug.Log("change chaircommon succesfull");
                SpeakerColl[index].bought();
                if (index == 1)
                {
                    RSpeakerPrice.text = "";
                    RSpeakerImage.enabled = false;

                    CSpeakerSprite.enabled = false;
                    RSpeakerSprite.enabled = true;
                    RSpeakerSpriteInLeft.enabled = true;
                    RSpeakerSpriteInRight.enabled = true;
                    ESpeakerSprite.enabled = false;
                    ESpeakerSpriteIn.enabled = false;
                    LSpeakerSprite.enabled = false;
                    LSpeakerSpriteInLeft.enabled = false;
                    LSpeakerSpriteInRight.enabled = false;

                    Debug.Log("rare");
                }
                if (index == 2)
                {
                    ESpeakerPrice.text = "";
                    ESpeakerImage.enabled = false;

                    CSpeakerSprite.enabled = false;
                    RSpeakerSprite.enabled = false;
                    RSpeakerSpriteInLeft.enabled = false;
                    RSpeakerSpriteInRight.enabled = false;
                    ESpeakerSprite.enabled = true;
                    ESpeakerSpriteIn.enabled = true;
                    LSpeakerSprite.enabled = false;
                    LSpeakerSpriteInLeft.enabled = false;
                    LSpeakerSpriteInRight.enabled = false;
                    Debug.Log("epic");
                }
                if (index == 3)
                {
                    LSpeakerPrice.text = "";
                    LSpeakerImage.enabled = false;

                    CSpeakerSprite.enabled = false;
                    RSpeakerSprite.enabled = false;
                    RSpeakerSpriteInLeft.enabled = false;
                    RSpeakerSpriteInRight.enabled = false;
                    ESpeakerSprite.enabled = false;
                    ESpeakerSpriteIn.enabled = false;
                    LSpeakerSprite.enabled = true;
                    LSpeakerSpriteInLeft.enabled = true;
                    LSpeakerSpriteInRight.enabled = true;
                    Debug.Log("legend");
                }
                PopSpeakerPurchaseFX(index);
                CurrentSpeakerIndex = index;
               
                if (index > LastSpeakerIndex)
                {
                    LastSpeakerIndex = index;
                }
                if (index < SpeakerColl.Count - 1)
                {
                    SpeakerColl[index + 1].unlocked();
                }
                SavePlayer();
            }
            else
            {
                //Debug.Log("Uang tidak mencukupi");
            }
        }
    }

    //asdf

    void startLamp(int index)
    {
        if (index == 1)
        {
            RLampPrice.text = "";
            RLampImage.enabled = false;

            CLampSprite.enabled = false;
            RLampSprite.enabled = true;
            ELampSprite.enabled = false;
            LLampSprite.enabled = false;

            Debug.Log("rare");
        }
        if (index == 2)
        {
            ELampPrice.text = "";
            ELampImage.enabled = false;

            CLampSprite.enabled = false;
            RLampSprite.enabled = false;
            ELampSprite.enabled = true;
            LLampSprite.enabled = false;

            Debug.Log("epic");
        }
        if (index == 3)
        {
            LLampPrice.text = "";
            LLampImage.enabled = false;

            CLampSprite.enabled = false;
            RLampSprite.enabled = false;
            ELampSprite.enabled = false;
            LLampSprite.enabled = true;

            Debug.Log("legend");
        }
    }
    public void lampPurchase(int index)
    {
        if (LampColl[index].Checklocked() == true)
        {
            //Debug.Log("Still Locked");
        }
        else
        {
            if (gold >= LampColl[index].getItemPrice())
            {
                ////Debug.Log("Before:" + gold);
                gold = gold - LampColl[index].getItemPrice();
                // //Debug.Log("After:" + gold);
                printGold();
                //changeChairCommon();
                // //Debug.Log("change chaircommon succesfull");
                LampColl[index].bought();
                if (index == 1)
                {
                    RLampPrice.text = "";
                    RLampImage.enabled = false;

                    CLampSprite.enabled = false;
                    RLampSprite.enabled = true;
                    ELampSprite.enabled = false;
                    LLampSprite.enabled = false;

                    Debug.Log("rare");
                }
                if (index == 2)
                {
                    ELampPrice.text = "";
                    ELampImage.enabled = false;

                    CLampSprite.enabled = false;
                    RLampSprite.enabled = false;
                    ELampSprite.enabled = true;
                    LLampSprite.enabled = false;

                    Debug.Log("epic");
                }
                if (index == 3)
                {
                    LLampPrice.text = "";
                    LLampImage.enabled = false;

                    CLampSprite.enabled = false;
                    RLampSprite.enabled = false;
                    ELampSprite.enabled = false;
                    LLampSprite.enabled = true;

                    Debug.Log("legend");
                }
                PopLampPurchaseFX(index);
                CurrentLampIndex = index;
                
                if (index > LastLampIndex)
                {
                    LastLampIndex = index;
                }
                if (index < LampColl.Count - 1)
                {
                    LampColl[index + 1].unlocked();
                }
                SavePlayer();
            }
            else
            {
                //Debug.Log("Uang tidak mencukupi");
            }
        }
    }
    //
    void PopPurchaseFX(int n)
    {
        PreviousImage.sprite = Resources.Load<Sprite>("Images/Monitor/monitorkeyboard" + (n-1).ToString());
        NextImage.sprite = Resources.Load<Sprite>("Images/Monitor/monitorkeyboard" + n.ToString());
        PurchaseFX.SetInteger("Pop", 1);
        Invoke("setZero",4.5f);//invoke itu ngeaktifno method after wait a given timne
    }
    void PopChairPurchaseFX(int n)
    {
        GadgetPreviousImage.sprite = ChairColl[CurrentChairIndex].getItemSprite();
        GadgetNextImage.sprite = Resources.Load<Sprite>("Images/Chair/chair" + (n+1).ToString());
        GadgetPurchaseFX.SetInteger("Pop", 1);
        Invoke("setZero", 4.5f);//invoke itu ngeaktifno method after wait a given timne
    }
    void PopTablePurchaseFX(int n)
    {
        GadgetPreviousImage.sprite = TableColl[CurrentTableIndex].getItemSprite();
        GadgetNextImage.sprite = Resources.Load<Sprite>("Images/Table/table" + (n+1).ToString());
        GadgetPurchaseFX.SetInteger("Pop", 1);
        Invoke("setZero", 4.5f);//invoke itu ngeaktifno method after wait a given timne
    }
    void PopSpeakerPurchaseFX(int n)
    {
        GadgetPreviousImage.sprite = SpeakerColl[CurrentSpeakerIndex].getItemSprite();
        GadgetNextImage.sprite = Resources.Load<Sprite>("Images/Speaker/speakerfx" + (n + 1).ToString());
        GadgetPurchaseFX.SetInteger("Pop", 1);
        Invoke("setZero", 4.5f);//invoke itu ngeaktifno method after wait a given timne
    }
    void PopLampPurchaseFX(int n)
    {
        GadgetPreviousImage.sprite = LampColl[CurrentLampIndex].getItemSprite();
        GadgetNextImage.sprite = Resources.Load<Sprite>("Images/Lamp/lamp" + (n + 1).ToString());
        GadgetPurchaseFX.SetInteger("Pop", 1);
        Invoke("setZero", 4.5f);//invoke itu ngeaktifno method after wait a given timne
    }
    void PopBitcoin()
    {
        BitcoinFX.SetInteger("show", 1);
        Invoke("setZero", 5.3f);//invoke itu ngeaktifno method after wait a given timne
    }
    
    public void bitcoinIsPressed()
    {
        
        bitcoinReward = UnityEngine.Random.Range(1, 10) * eps;
        BitcoinRewardText.text = "$ "+bitcoinReward.ToString("0");
        //disini belum di calim duite belum masuk money masuk money saat di void claimBitcoinReward() atau claimDoubleBitcoinReward()
        Debug.Log("earn from bitcoin:" + bitcoinReward);
        Invoke("setZero", 0.1f);//invoke itu ngeaktifno method after wait a given timne
        

    }
    public void claimBitcoinReward()
    {
        money += bitcoinReward;

    }
    public void claimDoubleBitcoinReward()
    {
        money += 2*bitcoinReward;
    }

    void PopHouseFX()
    {
        HouseFX.SetInteger("Pop", 1);
        Invoke("setZero", 1.2f);
    }
    void setZero()
    {
        PurchaseFX.SetInteger("Pop", 0);
        HouseFX.SetInteger("Pop", 0);
        GadgetPurchaseFX.SetInteger("Pop", 0);
        BitcoinFX.SetInteger("show", 0);
        //AddMoneyFX.SetInteger("Pressed", 0);
    }

    //appearance controller popup popdown
    public void PopAppearance()
    {
        if (AppearanceUIAnim.GetInteger("HideA") == 0)//masih idle, dipencet masuk popup
        {
            AppearanceUIAnim.SetInteger("HideA", 1);
        }
        else if (AppearanceUIAnim.GetInteger("HideA") == 1)//pop down
        {
            AppearanceUIAnim.SetInteger("HideA", 2);
            

        }
        else if(AppearanceUIAnim.GetInteger("HideA") == 2)//pop up
        {
            AppearanceUIAnim.SetInteger("HideA", 1);

        }

    }
    public void PopSkill()
    {

        if (SkillsUIAnim.GetInteger("HideA") == 0)//masih idle, dipencet masuk popup
        {
            SkillsUIAnim.SetInteger("HideA", 1);
        }
        else if (SkillsUIAnim.GetInteger("HideA") == 1)
        {

            SkillsUIAnim.SetInteger("HideA", 2);
        }
        else if (SkillsUIAnim.GetInteger("HideA") == 2)
        {
            SkillsUIAnim.SetInteger("HideA", 1);

        }

        
    }
    public void PopShop()
    {
        if (ShopUIAnim.GetInteger("HideA") == 0)//masih idle, dipencet masuk popup
        {
            ShopUIAnim.SetInteger("HideA", 1);
        }
        else if (ShopUIAnim.GetInteger("HideA") == 1)//pop down
        {
            ShopUIAnim.SetInteger("HideA", 2);
        }
        else if (ShopUIAnim.GetInteger("HideA") == 2)//pop up
        {
            ShopUIAnim.SetInteger("HideA", 1);

        }

    }
    public void PopProductivity()
    {

        if (ProductivityAnim.GetInteger("HideA") == 0)//masih idle, dipencet masuk popup
        {
            ProductivityAnim.SetInteger("HideA", 1);
        }
        else if (ProductivityAnim.GetInteger("HideA") == 1)
        {
            ProductivityAnim.SetInteger("HideA", 2);
        }
        else if (ProductivityAnim.GetInteger("HideA") == 2)
        {
            ProductivityAnim.SetInteger("HideA", 1);

        }

    }
    public void PopHouse()
    {

        if (HouseAnim.GetInteger("HideA") == 0)//masih idle, dipencet masuk popup
        {
            HouseAnim.SetInteger("HideA", 1);
        }
        else if (HouseAnim.GetInteger("HideA") == 1)
        {
            HouseAnim.SetInteger("HideA", 2);

        }
        else if (HouseAnim.GetInteger("HideA") == 2)
        {
            HouseAnim.SetInteger("HideA", 1);

        }

    }
    public void ComputerUI(int n)
    {
        if(n < 10)
        {
            MonitorUI.sprite = Resources.Load<Sprite>("Images/Monitor/monitorkeyboard"+n.ToString()+"F");
            //Debug.Log("Images/Monitor/monitorkeyboard" + n.ToString() + "F");////Debug
            CPUUI.sprite = Resources.Load<Sprite>("Images/CPU/cpu"+n.ToString()+"F");
            ComputerLevelText.text = "Level " + ComputerLevel.ToString();
            Computer.text = "$" + moneyConverter(MonitorColl[n].getItemPrice());
        }else if(n == 10)
        {
            MonitorUI.sprite = Resources.Load<Sprite>("Images/Monitor/monitorkeyboard" + n.ToString() + "F");
            //Debug.Log("Images/Monitor/monitorkeyboard" + n.ToString() + "F");////Debug
            CPUUI.sprite = Resources.Load<Sprite>("Images/CPU/cpu" + n.ToString() + "F");
            ComputerLevelText.text = "Level " + ComputerLevel.ToString();
            Computer.text = "Maxed";
        }

    }
   
    public void computerUp()
    {
        if (LastMonitorIndex < 9 && LastMonitorIndex <= level)
        {
            if (money >= MonitorColl[LastMonitorIndex + 1].getItemPrice())
            {
                ////Debug.Log("Before:" + gold);
                money = money - MonitorColl[LastMonitorIndex + 1].getItemPrice();
                eps += MonitorColl[LastMonitorIndex + 1].getItemEps();
                // //Debug.Log("After:" + gold);
                printMoney();
                MonitorColl[LastMonitorIndex + 1].bought();
                MonitorSR.sprite = MonitorColl[LastMonitorIndex + 1].getItemSprite();
                CPUSR.sprite = MonitorColl[LastMonitorIndex + 1].getItemSprite2();
                
                ComputerLevel++;
                ComputerUI(ComputerLevel);

                PopPurchaseFX(ComputerLevel);
                if (LastMonitorIndex+1 < 10)
                {
                    LastMonitorIndex++;
                }
            }
        }
        SavePlayer();
           
    }
    
    void showAwayEarnings()
    {
        awayEarningsCanvas.active=true;

    }
    public void IdleCheck()
    {
        if(Time.time - LastIdleTime > IdleTimeSetting)
        {
            idleReminder.active = true;
        }
        else
        {
            idleReminder.active = false;
        }
    }

    public void switchScene(int n)
    {
        SceneManager.LoadScene(n);
    }
 
    public void Debugging()
    {
        //Debug.Log("is press");
    }
    public void vibrate()
    {
        if (currentVibrateSetting == 1)
            Handheld.Vibrate();
    }
    public void goldPurchaseSuccessful(int n)
    {
        gold += n;
    }
    public void moneyPurchaseSuccessful(double n)
    {
        money += n;
    }


}
