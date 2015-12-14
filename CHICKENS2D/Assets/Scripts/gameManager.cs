using UnityEngine;
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

		baboonCount = GameObject.FindGameObjectsWithTag("Baboon").Length;

		Debug.Log (GameObject.FindGameObjectsWithTag ("Chicken").Length);

		timer += Time.deltaTime;

	

		feedAmountCheck = feedAmount;

		Debug.Log (baboonCount + "baboon");

		if (baboonCount == 0) 
		{
			nightTime ();
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

			if (GUI.Button(new Rect(10, 70, 50, 30), "Feed"))
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

			if (GUI.Button(new Rect(10, 100, 80, 30), "Buy Feed"))
			{

				feedAmount++;
				money--;
			}
		}


	}

	void nightTime ()
	{
		if (isNight == true)
		{
            int Direction = Random.Range(1,4); //Chooses direction
            //Stick this in a loop that increments depending on amount of baboons wanted?
            BaboonSpawn Spawn = (BaboonSpawn)BaboonSpawnz[Direction].GetComponent("BaboonSpawn"); //Aquires Variable
            Spawn.SummonBaboon();//UNLEASH TEH BBABOOONS!
            Debug.Log("Baboon spawning from location: " + Direction.ToString()); //Confirmation

           
                /*
			int a = 0;
			int b = 0;
			int c = 0;

			int howMany = Random.Range (1,10);

			int direction = Random.Range (1,3);

			if (direction == 1)
			{

				for (int x = 0; x <howMany; x++)
				{

					Instantiate(baboon, new Vector3 (-10, a, 0), Quaternion.identity);
					a++;
				}
			}

			if (direction == 12)
			{
				
				for (int x = 0; x <howMany; x++)
				{
					
					Instantiate(baboon, new Vector3 (10, b, 0), Quaternion.identity);
					b++;
				}
			}

			if (direction == 1)
			{
				
				for (int x = 0; x <howMany; x++)
				{
					
					Instantiate(baboon, new Vector3 (c-3, 10, 0), Quaternion.identity);
					c++;
				}
			}
            */
		}
	}


}
