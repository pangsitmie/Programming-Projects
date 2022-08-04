using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[System.Serializable]

public class Items
{
    protected string name;
    protected string type;
    protected int price;
    protected int eps;
    protected Sprite sprite;
    protected bool locked;
    protected Sprite sprite2;


    public Items()
    {

    }

    public string getItemName()
    {
        return name;
    }
    public string getType()
    {
        return type;
    }

    public int getItemPrice()
    {
        return price;
    }
   
    public void bought()
    {
        this.price = 0;
        this.unlocked();
    }
    public int getItemEps()
    {
        return eps;
    }

    public Sprite getItemSprite()
    {   
        return sprite;
    }
    public Sprite getItemSprite2()
    {
        return sprite2;
    }

    public void unlocked()
    {
        this.locked = false;
    }

    public bool Checklocked()
    {
        return locked;
    }

    public void additems()
    {
        //list dari semua items yang ada (name,type, price, eps, spritename)



        //Items table1 = new Items("Common Table", "table", 0, 10, Resources.Load<Sprite>("Images/Table/table1"));//4
        // Items table2 = new Items("Rare Table", "table", 20, 100, Resources.Load<Sprite>("Images/Table/table2"));
        // Items table3 = new Items("Epic Table", "table", 40, 200, Resources.Load<Sprite>("Images/Table/table3"));
        // Items table4 = new Items("Legend Table", "table", 80, 500, Resources.Load<Sprite>("Images/Table/table4"));




        // items.Add(table1);
        // items.Add(table2);
        // items.Add(table3);
        // items.Add(table4);
    }

    //feelingku save itu harus ditaruk nde script items e iki soale hargae mari dibeli lak ws jadi 0 trs 
    //mari gt save e lek mek colection e orge ya data seng ws dirubah jadi 0 iki ga ke save lakan
    //mek e lek save e mau disini yak ap akses e nde player.cs e

}


public class Chair : Items
{
    
    public static List<Chair> Chairs = new List<Chair>();
    

    public Chair(string iName, string type, int iPrice, int iEps, Sprite sprite)
    {
        this.name = iName;
        this.price = iPrice;
        this.eps = iEps;
        this.sprite = sprite;
        this.type = type;
        this.locked = true;
    }
    
    public void addChair(Player player)
    {

        Chair chair1 = new Chair("Common Chair", "chair", 0, 10, Resources.Load<Sprite>("Images/Chair/chair1"));//0
        Chair chair2 = new Chair("Rare Chair", "chair", 20, 100, Resources.Load<Sprite>("Images/Chair/chair2"));
        Chair chair3 = new Chair("Epic Chair", "chair", 40, 200, Resources.Load<Sprite>("Images/Chair/chair3"));
        Chair chair4 = new Chair("Legend Chair", "chair", 80, 500, Resources.Load<Sprite>("Images/Chair/chair4"));
        Chair chair5 = new Chair("Legend Chair", "chair", 0, 0, Resources.Load<Sprite>("Images/Chair/chair4"));//chair 5 iki ga ada mek nambahi benno index ga out of bound

        Chairs.Add(chair1);
        Chairs.Add(chair2);
        Chairs.Add(chair3);
        Chairs.Add(chair4);
        Chairs.Add(chair5);

        Chairs[0].unlocked();
        Chairs[1].unlocked();
        int size = player.LastChairIndex;
        for (int i = 0; i <=size; i++)
        {
            Chairs[i].bought();
            if (i == size && Chairs[i + 1] != null)
            {
                Chairs[i + 1].unlocked();
            }
        }

    }

}

public class Table : Items
{

    public static List<Table> Tables = new List<Table>();

    public Table(string iName, string type, int iPrice, int iEps, Sprite sprite)
    {
        this.name = iName;
        this.price = iPrice;
        this.eps = iEps;
        this.sprite = sprite;
        this.type = type;
        this.locked = true;
    }
  

    public void addTable(Player player)
    {

         Table table1 = new Table("Common Table", "table", 0, 10, Resources.Load<Sprite>("Images/Table/table1"));//4
         Table table2 = new Table("Rare Table", "table", 20, 100, Resources.Load<Sprite>("Images/Table/table2"));
         Table table3 = new Table("Epic Table", "table", 40, 200, Resources.Load<Sprite>("Images/Table/table3"));
         Table table4 = new Table("Legend Table", "table", 80, 500, Resources.Load<Sprite>("Images/Table/table4"));
         Table table5 = new Table("Legend Table", "table", 0, 0, Resources.Load<Sprite>("Images/Table/table5"));//table 5 iki ga ada mek nambahi benno index ga out of bound




         Tables.Add(table1);
         Tables.Add(table2);
         Tables.Add(table3);
         Tables.Add(table4);
         Tables.Add(table5);


        Tables[0].unlocked();
        Tables[1].unlocked();

        int size = player.LastTableIndex;
         for(int i=0;i<=size; i++)
         {
                Tables[i].bought();
            if (i == size && Tables[i + 1] != null)
            {
                Tables[i + 1].unlocked();
            }
         }

    }

}
public class Speaker : Items
{

    public static List<Speaker> Speakers = new List<Speaker>();

    public Speaker(string iName, string type, int iPrice, int iEps, Sprite sprite)
    {
        this.name = iName;
        this.price = iPrice;
        this.eps = iEps;
        this.sprite = sprite;
        this.type = type;
        this.locked = true;
    }


    public void addSpeaker(Player player)
    {

        Speaker speaker1 = new Speaker("Common Speaker", "speaker", 0, 10, Resources.Load<Sprite>("Images/Speaker/speakerfx1"));//4
        Speaker speaker2 = new Speaker("Rare Speaker", "speaker", 20, 100, Resources.Load<Sprite>("Images/Speaker/speakerfx2"));
        Speaker speaker3 = new Speaker("Epic Speaker", "speaker", 40, 200, Resources.Load<Sprite>("Images/Speaker/speakerfx3"));
        Speaker speaker4 = new Speaker("Legend Speaker", "speak", 80, 500, Resources.Load<Sprite>("Images/Speaker/speakerfx4"));




        Speakers.Add(speaker1);
        Speakers.Add(speaker2);
        Speakers.Add(speaker3);
        Speakers.Add(speaker4);

        Speakers[0].unlocked();
        Speakers[1].unlocked();

        int size = player.LastSpeakerIndex;
        for (int i = 0; i <= size; i++)
        {
            Speakers[i].bought();
            if (i == size && Speakers[i + 1] != null)
            {
                Speakers[i + 1].unlocked();
            }
        }

    }


}




public class Lamp : Items
{

    public static List<Lamp> Lamps = new List<Lamp>();

    public Lamp(string iName, string type, int iPrice, int iEps, Sprite sprite)
    {
        this.name = iName;
        this.price = iPrice;
        this.eps = iEps;
        this.sprite = sprite;
        this.type = type;
        this.locked = true;
    }


    public void addLamp(Player player)
    {

        Lamp lamp1 = new Lamp("Common Lamp", "Lamp", 0, 10, Resources.Load<Sprite>("Images/Lamp/Lamp1"));//4
        Lamp lamp2 = new Lamp("Rare Lamp", "Lamp", 20, 100, Resources.Load<Sprite>("Images/Lamp/Lamp2"));
        Lamp lamp3 = new Lamp("Epic Lamp", "Lamp", 40, 200, Resources.Load<Sprite>("Images/Lamp/Lamp3"));
        Lamp lamp4 = new Lamp("Legend Lamp", "Lamp", 80, 500, Resources.Load<Sprite>("Images/Lamp/Lamp4"));




        Lamps.Add(lamp1);
        Lamps.Add(lamp2);
        Lamps.Add(lamp3);
        Lamps.Add(lamp4);

        Lamps[0].unlocked();
        Lamps[1].unlocked();

        int size = player.LastLampIndex;
        for (int i = 0; i <= size; i++)
        {
            Lamps[i].bought();
            if (i == size && Lamps[i + 1] != null)
            {
                Lamps[i + 1].unlocked();
            }
        }

    }


}
public class Monitor : Items
{

    public static List<Monitor> Monitors = new List<Monitor>();

    public Monitor(string iName, string type, int iPrice, int iEps, Sprite monitor, Sprite cpu)
    {
        this.name = iName;
        this.type = type;
        this.price = iPrice;
        this.eps = iEps;
        this.sprite = monitor;
        this.sprite2 = cpu;
        this.locked = true;
    }


    public void addMonitor(Player player)
    {

        Monitor monitor1 = new Monitor("Monitor1", "monitor", 0, 10, Resources.Load<Sprite>("Images/Monitor/monitorkeyboard1"), Resources.Load<Sprite>("Images/CPU/CPU1"));//4
        Monitor monitor2 = new Monitor("Monitor2", "monitor", 1000, 50, Resources.Load<Sprite>("Images/Monitor/monitorkeyboard2"), Resources.Load<Sprite>("Images/CPU/CPU2"));
        Monitor monitor3 = new Monitor("Monitor3", "monitor", 10000, 100, Resources.Load<Sprite>("Images/Monitor/monitorkeyboard3"), Resources.Load<Sprite>("Images/CPU/CPU3"));
        Monitor monitor4 = new Monitor("Monitor4", "monitor", 50000, 200, Resources.Load<Sprite>("Images/Monitor/monitorkeyboard4"), Resources.Load<Sprite>("Images/CPU/CPU4"));
        Monitor monitor5 = new Monitor("Monitor5", "monitor", 100000, 400, Resources.Load<Sprite>("Images/Monitor/monitorkeyboard5"), Resources.Load<Sprite>("Images/CPU/CPU5"));
        Monitor monitor6 = new Monitor("Monitor6", "monitor", 1000000, 800, Resources.Load<Sprite>("Images/Monitor/monitorkeyboard6"), Resources.Load<Sprite>("Images/CPU/CPU6"));
        Monitor monitor7 = new Monitor("Monitor7", "monitor", 5000000, 1600, Resources.Load<Sprite>("Images/Monitor/monitorkeyboard7"), Resources.Load<Sprite>("Images/CPU/CPU7"));
        Monitor monitor8 = new Monitor("Monitor8", "monitor", 10000000, 3000, Resources.Load<Sprite>("Images/Monitor/monitorkeyboard8"), Resources.Load<Sprite>("Images/CPU/CPU8"));
        Monitor monitor9 = new Monitor("Monitor9", "monitor", 50000000, 7000, Resources.Load<Sprite>("Images/Monitor/monitorkeyboard9"), Resources.Load<Sprite>("Images/CPU/CPU9"));
        Monitor monitor10 = new Monitor("Monitor10", "monitor", 1000000000, 100000, Resources.Load<Sprite>("Images/Monitor/monitorkeyboard10"), Resources.Load<Sprite>("Images/CPU/CPU10"));





        Monitors.Add(monitor1);
        Monitors.Add(monitor2);
        Monitors.Add(monitor3);
        Monitors.Add(monitor4);
        Monitors.Add(monitor5);
        Monitors.Add(monitor6);
        Monitors.Add(monitor7);
        Monitors.Add(monitor8);
        Monitors.Add(monitor9);
        Monitors.Add(monitor10);


        Monitors[0].unlocked();
        Monitors[1].unlocked();

        int size = player.LastMonitorIndex;
        //Debug.Log(size + "---");

        for (int i = 0; i <= size; i++)
        {
            Monitors[i].bought();
            if (i == size && i < Monitors.Count-1)
            {
                Monitors[i + 1].unlocked();
            }
        }

    }

}