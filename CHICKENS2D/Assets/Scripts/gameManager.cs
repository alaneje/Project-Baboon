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

    private bool NewChick;

    public Text WallUpText;
    public Text WallDownText;
    public Text WallLeftText;
    public Text WallRightText;
    public Text Money;
    public Text Feed;
    public Text DayNight;
    public Text[] Console;
    public Slider DayTimeRemaining;
    public Button FeedButton;
	public Button FeedBuyBut;
    public Button[] WallButtonManager;
    public GameObject[] Walls;
    public int UpKeepCosts;
    public GameObject GameOverUI;
    private bool GameOverA;
    private float CTimer;
    public Camera Cam;
    public double seconds;
    public double minutes;
    public double hours;
    public clockScript Ct;



	public int timerCount;
    // Use this for initialization
    void Start () {

		timer = 0;

		money = 100;

		feedAmount = 0;

		target = transform.position;

		feeding = false;

		isDay = true;
		isNight = false;

		for (int x = 0; x <chickenStartAmount; x++)
		{
			Instantiate (chicken, new Vector3 (0,0,0), Quaternion.identity);
		}

        TerminateConsole();

		ChangeViewSize (5);
	    
	}
	
	// Update is called once per frame
	void Update () {

		if (clockScript.day == true) {
			isDay = true;
			isNight = false;
		}
		else
		{
			isDay = false;
			isNight = true;
		}

		if (money <= 1||isDay == false) {
			FeedBuyBut.interactable = false;
		} else {
			FeedBuyBut.interactable = true;
		}

        WallButtonControll();//Managers wall buttons
        WallText();
       //TimeManager();
       //if(CTimer > 0) { CTimer -= Time.deltaTime; }
       // if(CTimer < 1) { TerminateConsole();CTimer = 0; }
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

	void dayTime ()
	{
		DayTimeRemaining.gameObject.SetActive(true); 
		if(timerCount>=5)
		{
			for (int x = 0; x <6; x++)
			{
				Instantiate (chicken, new Vector3 (0,0,0), Quaternion.identity);
			}
			timerCount = 0;
		}
		else if (isDay == true && chickensOut == false && clockScript.whichDay >0) 
		{
			Instantiate (chicken, new Vector3 (0, 0, 0), Quaternion.identity);
			chickensOut = true;
			money = money - 20;
            money -= UpKeepCosts;
			timerCount++;


		}
		ChangeViewSize (5);

		
			
	}


	void nightTime ()
	{
		DayTimeRemaining.gameObject.SetActive(false);
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

			ChangeViewSize(20);
              
		}
	}
    void GameOver() {
        GameOverUI.SetActive(true);
        GameOverA = true;
    }
    void WallText()//Sets the text on the wall buttons
    {
		if (money > 0) 
		{
			if (Walls [0] == null) {
				WallUpText.text = "Buy Wall (8 Rupees, 10 Health)";
			}
			if (Walls [1] == null) {
				WallDownText.text = "Buy Wall (8 Rupees, 10 Health)";
			}
			if (Walls [2] == null) {
				WallRightText.text = "Buy Wall (8 Rupees, 10 Health)";
			}
			if (Walls [3] == null) {
				WallLeftText.text = "Buy Wall (8 Rupees, 10 Health)";
			}

			if (Walls [0] != null) {
				WallUpText.text = "Upgrade/Repair Wall (8 Rupees, 10 Health)";
			}
			if (Walls [1] != null) {
				WallDownText.text = "Upgrade/Repair Wall (8 Rupees, 10 Health)";
			}
			if (Walls [2] != null) {
				WallRightText.text = "Upgrade/Repair Wall (8 Rupees, 10 Health)";
			}
			if (Walls [3] != null) {
				WallLeftText.text = "Upgrade/Repair Wall (8 Rupees, 10 Health)";
			}
		}


    }
    public void BuyFeed() {
		if (money >= 1) {

			feedAmount++;
			money--;
		}
    }
    public void ResetButton() { Application.LoadLevel(0); }
    public void FeedChickens() {
        feedAmount = feedAmount - (GameObject.FindGameObjectsWithTag("Chicken").Length);//Feed chickens equal to amount of feed
        feeding = true;//Feed check is true
    }
    public void BuyUpgradeWall(int WallNum)//Un finished function for buying and upgrading walls
    {
		if(money > 8)
		{
        if(WallNum == 0)//Top Wall
        {

            if (Walls[0] == null)//Checks if the walls around, if it is then it just needs upgrading
            {
                Walls[0] = Instantiate(Wall, new Vector2(0, 3), Quaternion.identity) as GameObject;//makes the wall
            }
            else
            {
                wallScript Wal = (wallScript)Walls[0].GetComponent("wallScript");///Grabs the wall script
                Wal.life += 10;//Upgrades the life
            }
            money = money - 8;//Revokes money spent
        }
        if(WallNum == 1)//Bottom Wall
        {
            if (Walls[1] == null)
            {
                Walls[1] = Instantiate(Wall, new Vector2(0, -3), Quaternion.identity) as GameObject;
            }
            else
            {
                wallScript Wal = (wallScript)Walls[1].GetComponent("wallScript");
                Wal.life += 10;
            }

            money = money - 8;

        }
        if(WallNum == 2)//Right Wall
        {
            if (Walls[2] == null)
            {
                Walls[2] = Instantiate(Wall, new Vector2(3, 0), Quaternion.Euler(0, 0, 90)) as GameObject;
            }
            else
            {
                wallScript Wal = (wallScript)Walls[2].GetComponent("wallScript");
                Wal.life += 10;
            }
            money = money - 8;

        }
        if (WallNum == 3)//Left Wall
        {
            if (Walls[3] == null)
            {
                Walls[3] = Instantiate(Wall, new Vector2(-3, 0), Quaternion.Euler(0, 0, 90)) as GameObject;

            }
            else
            {
                wallScript Wal = (wallScript)Walls[3].GetComponent("wallScript");
                Wal.life += 10;
            }
            money = money - 8; 
        }
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
		if (money <=8)
		{
			WallButtonManager[0].interactable = false;
			WallButtonManager[1].interactable = false;
			WallButtonManager[2].interactable = false;
			WallButtonManager[3].interactable = false;

		}


    }
    public void UpdateConsole(string Line1, string Line2, string Line3)
    {
        Console[0].text = Line1;
        Console[1].text = Line2;
        Console[2].text = Line3;
        CTimer = 4;
    }
    void TerminateConsole()
    {
        Console[0].text = "";
        Console[1].text = "";
        Console[2].text = "";
    }
    void ChangeViewSize(int Size)
    {
        Cam.orthographicSize = Size;//Changes the camera size for different views
    }
    void TimeManager()
    {
       
        if(Ct.hoursinday > 19) { DayTimeRemaining.gameObject.SetActive(false); 

			ChangeViewSize(20); }
        if(Ct.hoursinday < 19) { DayTimeRemaining.gameObject.SetActive(true); 

			ChangeViewSize(5); }
        DayTimeRemaining.value = (int) Ct.hoursinday;

    }
}
