using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class chickenScript : MonoBehaviour {


	public Slider Health;
	public Slider age;

	public float timeSinceFeed;

	public float moveSpeed;

	public float chickenHealth;

	public int chickenHealthInt;

	public bool fed;

	double maxX = 2;
	double minX = -2;
	double maxY = 2;
	double minY = -2;
	
	private float tChange = 0; // force new direction in the first Update
	private float randomX;
	private float randomY;

	public float chickenAgeFloat;
	public int chickenAge;

	public Transform target; // drag the target object here
	Rect rect = new Rect (0,0,20,50); 
	Rect rect2 = new Rect (0,0,20,50); 
	Vector2 offset =  new Vector2(0.4f, 0f); // height above the target position

	Vector2 offset2 = new Vector2(-0.4f, 0f); // height above the target position


	public float chickenLifeMulti;

	public float totalGameSeconds;

	public float seconds;
	public float minutes;
	public float hours;
	public float days;

	public float secondsPerSecond;

	void Start()
	{
		fed = false;

		chickenHealth = 100000;


		chickenAge = 0;

		//camera = GetComponent<Camera> ();
	}
	
	void Update () {

		//Vector3 screenPosition = camera.WorldToScreenPoint(transform.position);

		Health.maxValue = 100000;
		Health.value = chickenHealth;

	//	age.maxValue = 345600;
		//age.value = chickenAge;
	

		timeSinceFeed += Time.fixedDeltaTime*clockScript.secondsPerSecond;

		chickenAgeFloat += Time.fixedDeltaTime*clockScript.secondsPerSecond;

		chickenAge = (int)chickenAgeFloat;

		if (gameManager.feeding == true) {
			fed = true;
		}


		if (fed == true) 
		{
			timeSinceFeed = 0;

			chickenHealth += chickenHealth/2;

			if (chickenHealth > 100000)
			{
				chickenHealth = 100000;
			}

			fed = false;


		}

		chickenHealthInt = (int)chickenHealth;

		if (chickenHealth < 1)
		{
			Destroy (gameObject);
		}

		if (timeSinceFeed > 0)
		{

			chickenHealth = chickenHealth - (clockScript.secondsPerSecond * Time.fixedDeltaTime);
		}

		// change to random direction at random intervals
		if (Time.time >= tChange){
			randomX = Random.Range(-2.0f,2.0f); // with float parameters, a random float
			randomY = Random.Range(-2.0f,2.0f); //  between -2.0 and 2.0 is returned
			// set a random interval between 0.5 and 1.5
			tChange = Time.time + Random.Range(0.5f,1.5f);
		}
		transform.Translate(new Vector2(randomX,randomY) * moveSpeed * Time.deltaTime);

		// if object reached any border, revert the appropriate direction
		if (transform.position.x >= maxX || transform.position.x <= minX) {
			randomX = -randomX;
		}
		if (transform.position.y >= maxY || transform.position.y <= minY) {
			randomY = -randomY;
		}
		// make sure the position is inside the borders

		
		if( Input.GetKeyDown(KeyCode.Alpha1))
		{
			secondsPerSecond = 1;
			
			
		}

		else if( Input.GetKeyDown(KeyCode.Alpha2))
		{
			secondsPerSecond = 60;
			
			
		}

		else if( Input.GetKeyDown(KeyCode.Alpha3))
		{
			secondsPerSecond = 3600;
		}
		
		totalGameSeconds += secondsPerSecond * Time.deltaTime;
		
		seconds = totalGameSeconds;
		minutes = totalGameSeconds / 60;
		hours = minutes / 60;
		days = hours / 24;

		chickenAge = (int)days;

		print (chickenAge);

		if (chickenAge == 4)
		{
			Destroy (gameObject);
		}

	}



	void OnMouseDown()
	{

			if (chickenAge == 0)
			{
				gameManager.money += 10;
			}
			else if (chickenAge == 1)
			{
				gameManager.money += 20;
			}
			else if (chickenAge == 2)
			{
				gameManager.money += 30;
			}
			else if (chickenAge == 3)
			{
				gameManager.money += 5;
			}


			Destroy (gameObject);


	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Baboon")
		{
			Destroy (gameObject);
		}
	}


}
