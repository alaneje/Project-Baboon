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

	double maxX = 3;
	double minX = -3;
	double maxY = 1;
	double minY = -1;
	
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

	void Start()
	{
		fed = false;

		chickenHealth = 345600;




		//camera = GetComponent<Camera> ();
	}
	
	void Update () {

		//Vector3 screenPosition = camera.WorldToScreenPoint(transform.position);

		//Health.maxValue = 345600;
	//	Health.value = chickenHealth;

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

			if (chickenHealth >345600)
			{
				chickenHealth = 345600;
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

	}



	void OnMouseDown()
	{

			if (chickenAge<=10000)
			{
				gameManager.money += 10;
			}
			else if ((chickenAge>100000)&&(chickenAge<=200000))
			{
				gameManager.money += 20;
			}
			else if ((chickenAge>200000)&&(chickenAge<=300000))
			{
				gameManager.money += 30;
			}
			else
			{
				gameManager.money += 5;
			}


			Destroy (gameObject);


	}


}
