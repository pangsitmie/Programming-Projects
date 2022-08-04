using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using UnityEngine;

public class House
{
	protected String name;
	protected int price;
	protected Sprite sprite;
	protected bool locked;

	public static List<House> Houses = new List<House>();

	public House(String name, int price, Sprite sprite)
	{
		this.name = name;
		this.price = price;
		this.sprite = sprite;
		this.locked = true;
	}
	public string getItemName()
	{
		return name;
	}
	public int getItemPrice()
	{
		return price;
	}
	public Sprite getItemSprite()
	{
		return sprite;
	}

	public void bought()
	{
		this.price = 0;
	}
	public float getReducedPrice()
	{
		float tempMoney;
	   
		if (price > 1000 && price < 1000000)
		{
			tempMoney = price / 1000;
			return tempMoney;
		}
		else if (price > 1000000)
		{
			tempMoney = price / 1000000;
			return tempMoney;
		}
		else
		{
			return price;
		}
	}
	public string getUnits()
	{
		string units;
		if (price > 1000 && price < 1000000)
		{
			units = "K";
			return units;
		}
		else if (price > 1000000)
		{
			units = "M";
			return units;
		}
		else
		{
			return "";
		}
	}

	public void unlocked()
	{
		this.locked = false;
	}
	public bool Checklocked()
	{
		return locked;
	}


	public void addHouse(Player player)
	{

		
		House house1 = new House("Garage", 0, Resources.Load<Sprite>("Images/House/house1"));
		House house2 = new House("Flat", 1000000, Resources.Load<Sprite>("Images/House/house2"));//1m
		House house3 = new House("Studio", 3000000, Resources.Load<Sprite>("Images/House/house3"));//3m
		House house4 = new House("Apartment", 10000000, Resources.Load<Sprite>("Images/House/house4"));//10m
		House house5 = new House("Loft", 250000000, Resources.Load<Sprite>("Images/House/house5"));//250m
		House house6 = new House("Condominium", 800000000, Resources.Load<Sprite>("Images/House/house6"));//800m
		House house7 = new House("Mansion", 1000000000, Resources.Load<Sprite>("Images/House/house7"));//1b

		Houses.Add(house1);
		Houses.Add(house2);
		Houses.Add(house3);
		Houses.Add(house4);
		Houses.Add(house5);
		Houses.Add(house6);
		Houses.Add(house7);



		Houses[0].unlocked();
		Houses[1].unlocked();
		Houses[2].unlocked();
		Houses[3].unlocked();
		Houses[4].unlocked();
		Houses[5].unlocked();
		Houses[6].unlocked();
 

		int size = player.LastChairIndex;
		for (int i = 0; i <= size; i++)
		{
			Houses[i].bought();
			if(i == size && i < Houses.Count)
			{
				Houses[i + 1].unlocked();
			}
		}

	}


}
