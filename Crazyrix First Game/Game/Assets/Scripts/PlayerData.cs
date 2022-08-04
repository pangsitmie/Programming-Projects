using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public double money;
    public double eps;
    public int gold;
    //appearance index
    public int LastChairIndex;
    public int CurrentChairIndex;
    public int LastTableIndex;
    public int CurrentTableIndex;
    public int LastSpeakerIndex;
    public int CurrentSpeakerIndex;
    public int LastLampIndex;
    public int CurrentLampIndex;

    public int LastMonitorIndex;
    public int LastHouseIndex;

    public int ComputerLevel;
    public int PublicSpeakingLevel;
    public int ClosingLevel;
    public int EmailMarketingLevel;
    public int SocialMediaMarketingLevel;
    public int InvestingLevel;
    public int DigitalMarketingLevel;
    public int CopyWritingLevel;
    public int ProcessorLevel;
    public int MemoryLevel;
    public int GraphicsLevel;
    public int StorageLevel;
    public int InternetLevel;
    public DateTime timeOff;
    //public DateTime timeOn;
    public int maxAwayEarnings;

    public int StartUpLevel;
    public int StartUpPrice;
    public int StartUpBonus;
    public int GoldContainer;
    public bool funnelClicked;
    public bool affiliateClicked;
    public int vibrateSetting;
    public int skillState;
    public double remainingSkillUpgradeTime;



    public PlayerData() {
        
    }

    public PlayerData(Player player)
    {
        level = player.level;
        money = player.money;
        gold = player.gold;
        eps = player.eps;
        LastChairIndex = player.LastChairIndex;
        CurrentChairIndex = player.CurrentChairIndex;
        LastTableIndex = player.LastTableIndex;
        CurrentTableIndex = player.CurrentTableIndex;
        LastSpeakerIndex = player.LastSpeakerIndex;
        CurrentSpeakerIndex = player.CurrentSpeakerIndex;
        LastLampIndex = player.LastLampIndex;
        CurrentLampIndex = player.CurrentLampIndex;
        LastMonitorIndex = player.LastMonitorIndex;
        LastHouseIndex = player.LastHouseIndex;


        ComputerLevel = player.ComputerLevel;
        PublicSpeakingLevel = player.PublicSpeakingLevel;
        ClosingLevel = player.ClosingLevel;
        EmailMarketingLevel = player.EmailMarketingLevel;
        SocialMediaMarketingLevel = player.SocialMediaMarketingLevel;
        InvestingLevel = player.InvestingLevel;
        DigitalMarketingLevel = player.DigitalMarketingLevel;
        CopyWritingLevel = player.CopyWritingLevel;
        ProcessorLevel = player.ProcessorLevel;
        MemoryLevel = player.MemoryLevel;
        GraphicsLevel = player.GraphicsLevel;
        StorageLevel = player.StorageLevel;
        InternetLevel = player.InternetLevel;
        //timeOn = player.timeOn;
        timeOff = player.timeOff;
        maxAwayEarnings = player.maxAwayEarnings;
        StartUpLevel = player.StartUpLevel;
        StartUpPrice = player.StartUpPrice;
        StartUpBonus = player.StartUpBonus;
        GoldContainer = player.GoldContainer;
        funnelClicked = player.funnelClicked;
        affiliateClicked = player.affiliateClicked;
        vibrateSetting = player.vibrateSetting;
        skillState = player.skillState;
        remainingSkillUpgradeTime = player.remainingSkillsUpgradeTime;

        //collection = player.initiate;
    }
    /*
    public float getMoney()
    {
        return money;
    }
    public int getGold()
    {
        return gold;
    }
    */
}
