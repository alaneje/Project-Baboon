using UnityEngine;
using System.Collections;
using UnityEngine.UI;
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
    private bool NewChick;
    public Text WallUpText;
    public Text WallDownText;
    public Text WallLeftText;
    public Text WallRightText;
    public Text Money;
    public Text Feed;
    public Text DayNight;
    public Slider DayTimeRemaining;
    public Button FeedButton;
    public Button[] WallButtonManager;
    public int UpKeepCosts;
    public GameObject GameOverUI;
    private bool GameOverA;
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

        WallButtonControll();//Managers wall buttons

    	

		timer += Time.deltaTime;

        Money.text = money + " Rupee";//Shows money on the ui
        Feed.text = feedAmount + " Feed";//Shows the feed on the ui
	

		feedAmountCheck = feedAmount;
        if ((((feedAmountCheck - (GameObject.FindGameObjectsWithTag("Chicken").Length)) >= 0) && (feedAmount > 0)) && isNight == false)
            //Checks if the amount of feed is equal to chiccken amount and if it's daytime
        {
            FeedButton.interactable = true;//In this scenario makes the feed chicken button interactable
        }
        else { FeedButton.interactable = false; }//else it's not


            if (isNight == true) 
		{
			chickensOut = false;
			nightTime ();
            DayNight.text = "Nightime";//Changes text in right hand top corner

		}
		if (isDay == true)
		{
			baboonsOut = false;
			dayTime();
            DayNight.text = "Daytime";//Changes text in right hand top corner
        }

        if(money < 1)//If money is less than 1 then it's game over
        {
            Debug.Log("GameOver");
            GameOver();
        }
        DayTimeRemaining.value = (int) clockScript.whichHour; //Attempt at the day time remaining on the ui. 
	}

	void OnGUI()
	{
//		GUI.TextArea (new Rect (10, 0, 50, 30), money.ToString());
//		GUI.TextArea (new Rect (10, 30, 50, 30), feedAmount.ToString());

		if ( clockScript.day == true)
		{
			isDay = true;
			isNight = false;
            
		}
		else 
		{

			isNight = true;
			isDay = false;
		}

        /*
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
        */
		if ((money > 0)&& isNight == false)
		{
            /*
			if (GUI.Button(new Rect(10, 70, 80, 30), "Buy Feed"))
			{

				feedAmount++;
				money--;
			}*/
		}



	}
	void dayTime ()
	{
		if (isDay == true && chickensOut == false && clockScript.whichDay >0) 
		{
			Instantiate (chicken, new Vector3 (0, 0, 0), Quaternion.identity);
			chickensOut = true;
			money = money - 20;
            money -= UpKeepCosts;

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
    void GameOver() {
        GameOverUI.SetActive(true);
        GameOverA = true;
    }
    void WallText() { }
    public void BuyFeed() {
        feedAmount++;
        money--;
    }
    public void ResetButton() { Application.LoadLevel(0); }
    public void FeedChickens() {
        feedAmount = feedAmount - (GameObject.FindGameObjectsWithTag("Chicken").Length);//Feed chickens equal to amount of feed
        feeding = true;//Feed check is true
    }
    public void BuyUpgradeWall(int WallNum)//Un finished function for buying and upgrading walls
    {
        if(WallNum == 0)//Top Wall
        {

            if (wallTopUpgrade == true)
            {
                return;
            }
            else if (wallTopBool == true)
            {
                GameObject wallUpgradeTop = Instantiate(wallUpgrade, new Vector2(0, 3), Quaternion.identity) as GameObject;

                wallUpgradeTop.gameObject.tag = "WallUpgradeTop";
                wallTopUpgrade = true;
                wallTopBool = false;

            }

            else
            {
                GameObject wallTop = Instantiate(Wall, new Vector2(0, 3), Quaternion.identity) as GameObject;
                wallTop.gameObject.tag = "WallTop";
            }

            if (wallTopUpgrade == false)
            {
                wallTopBool = true;
            }

            money = money - 10;
        }
        if(WallNum == 1)//Bottom Wall
        {
            if (wallBottomUpgrade == true)
            {
                return;
            }
            else if (wallBottomBool == true)
            {
                GameObject wallUpgradeBottom = Instantiate(wallUpgrade, new Vector2(0, -3), Quaternion.identity) as GameObject;

                wallUpgradeBottom.gameObject.tag = "WallUpgradeBottom";
                wallBottomUpgrade = true;
                wallBottomBool = false;

            }

            else
            {
                GameObject wallBottom = Instantiate(Wall, new Vector2(0, -3), Quaternion.identity) as GameObject;
                wallBottom.gameObject.tag = "WallBottom";
            }

            if (wallBottomUpgrade == false)
            {
                wallBottomBool = true;
            }

            money = money - 10;
        }
        if(WallNum == 2)//Right Wall
        {
            Instantiate(Wall, new Vector2(3, 0), Quaternion.Euler(0, 0, 90));
        }
        if (WallNum == 3)//Left Wall
        {
            Instantiate(Wall, new Vector2(-3, 0), Quaternion.Euler(0, 0, 90));
        }
    }
    void WallButtonControll()
    {
        if(isNight == false)//Sets buttons to be active during day
        {
            WallButtonManager[0].interactable = true;
            WallButtonManager[1].interactable = true;
            WallButtonManager[2].interactable = true;
            WallButtonManager[3].interactable = true;

        }
        if (isNight == true)//Disables during night
        {
            WallButtonManager[0].interactable = false;
            WallButtonManager[1].interactable = false;
            WallButtonManager[2].interactable = false;
            WallButtonManager[3].interactable = false;

        }

    }
}
