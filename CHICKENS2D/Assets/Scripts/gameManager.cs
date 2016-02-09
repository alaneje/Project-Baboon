﻿using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public float timer;

	public static float money;

	public float feedAmount;

	public GameObject chicken;

	public Vector3 target;

	public GameObject baboon;

    public GameObject[] BaboonSpawnz;

	public static bool feeding;

	public bool isDay;
	public bool isNight;

	float feedAmountCheck;

	public int chickenStartAmount;

	public int baboonCount;

	public bool baboonsOut;

	public GameObject Wall;


	public GameObject wallUpgrade;

	private bool chickensOut;

	public bool wallTopBool;
	public bool wallBottomBool;
	public bool wallTopUpgrade;
	public bool wallBottomUpgrade;

	// Use this for initialization
	void Start () {

		timer = 0;

		money = 100;

		feedAmount = 0;

		target = transform.position;

		feeding = false;

		isDay = false;
		isNight = false;

		for (int x = 0; x <chickenStartAmount; x++)
		{
			Instantiate (chicken, new Vector3 (0,0,0), Quaternion.identity);
		}

	
	}
	
	// Update is called once per frame
	void Update () {



    	

		timer += Time.deltaTime;
	

	

		feedAmountCheck = feedAmount;

	

		if (isNight == true) 
		{
			chickensOut = false;
			nightTime ();

		}
		if (isDay == true)
		{
			baboonsOut = false;
			dayTime();
		}
	
	}

	void OnGUI()
	{
		GUI.TextArea (new Rect (10, 0, 50, 30), money.ToString());
		GUI.TextArea (new Rect (10, 30, 50, 30), feedAmount.ToString());

		if ( clockScript.day == true)
		{
			GUI.TextArea (new Rect (100, 30, 50, 30), "Day");
			isDay = true;
			isNight = false;
		}
		else 
		{
			GUI.TextArea (new Rect (100,30, 50,30), "Night");

			isNight = true;
			isDay = false;
		}


		if ((((feedAmountCheck - (GameObject.FindGameObjectsWithTag("Chicken").Length )) >= 0)&& (feedAmount >0))&& isNight == false )
		{

			if (GUI.Button(new Rect(100,70, 50, 30), "Feed"))
			{
			
				feedAmount = feedAmount - (GameObject.FindGameObjectsWithTag("Chicken").Length);

				feeding = true;
			}
			else
			{
				feeding = false;
			}




		}
		else
		{
			feeding = false;
		}

		if ((money > 0)&& isNight == false)
		{

			if (GUI.Button(new Rect(10, 70, 80, 30), "Buy Feed"))
			{

				feedAmount++;
				money--;
			}
		}
		if (isNight == false) 
		{
			if ((GUI.Button(new Rect(10, 100, 80, 30), "wall top"))&&money>10)
			{

				if(wallTopUpgrade == true)
				{
					return;
				}
				else if (wallTopBool == true)
				{
					GameObject wallUpgradeTop = Instantiate (wallUpgrade, new Vector2 (0, 3), Quaternion.identity) as GameObject;

					wallUpgradeTop.gameObject.tag = "WallUpgradeTop";
					wallTopUpgrade = true;
					wallTopBool = false;

				}
			
				else
				{
					GameObject wallTop = Instantiate (Wall, new Vector2 (0, 3), Quaternion.identity) as GameObject;
					wallTop.gameObject.tag = "WallTop";
				}

				if(wallTopUpgrade == false)
				{
					wallTopBool = true;
				}

				money = money - 10;

			}
			if ((GUI.Button(new Rect(10, 130, 80, 30), "wall bottom"))&&money>10)
			{	
				if(wallBottomUpgrade == true)
				{
					return;
				}
				else if (wallBottomBool == true)
				{
					GameObject wallUpgradeBottom = Instantiate (wallUpgrade, new Vector2 (0, -3), Quaternion.identity) as GameObject;
					
					wallUpgradeBottom.gameObject.tag = "WallUpgradeBottom";
					wallBottomUpgrade = true;
					wallBottomBool = false;
					
				}
				
				else
				{
					GameObject wallBottom = Instantiate (Wall, new Vector2 (0, -3), Quaternion.identity) as GameObject;
					wallBottom.gameObject.tag = "WallBottom";
				}
				
				if(wallBottomUpgrade == false)
				{
					wallBottomBool = true;
				}
				
				money = money - 10;
			}
			if (GUI.Button(new Rect(10, 160, 80, 30), "wall right"))
			{

				Instantiate (Wall, new Vector2 (3, 0), Quaternion.Euler (0,0,90));
			}
			if (GUI.Button(new Rect(10, 190, 80, 30), "wall left"))
			{
				
				Instantiate (Wall, new Vector2 (-3, 0), Quaternion.Euler (0,0,90));
			}
		}



	}
	void dayTime ()
	{
		if (isDay == true && chickensOut == false && clockScript.whichDay >0) 
		{
			Instantiate (chicken, new Vector3 (0, 0, 0), Quaternion.identity);
			chickensOut = true;
			money = money - 20;
		}
		
			
	}


	void nightTime ()
	{
		if (isNight == true && baboonsOut == false)
		{
            int Direction = Random.Range(1,4); //Chooses direction
            //Stick this in a loop that increments depending on amount of baboons wanted?
            BaboonSpawn Spawn = (BaboonSpawn)BaboonSpawnz[Direction].GetComponent("BaboonSpawn"); //Aquires Variable
            Spawn.SummonBaboon();//UNLEASH TEH BBABOOONS!
            Debug.Log("Baboon spawning from location: " + Direction.ToString()); //Confirmation

			baboonCount = Random.Range (1,5);

			for (int x = 0 ; x <baboonCount ; x++)
			{
				Spawn.SummonBaboon();//UNLEASH TEH BBABOOONS!
			}

			baboonsOut = true;

           
              
		}
	}


}
