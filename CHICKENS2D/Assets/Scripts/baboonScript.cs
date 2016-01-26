using UnityEngine;
using System.Collections;

public class baboonScript : MonoBehaviour {

	Vector2 startPos;

	float speed;

    public GameObject Goal; //The object it's aiming for on the opposite side of the screen

	public bool runUp;
	float timer;

	public float retreatSpeed;
	
	// Use this for initialization
	void Start () {

		startPos = transform.position;



		speed = Random.Range(0.1f, 0.5f);
		
	}

	
	// Update is called once per frame
	void Update ()
	{
	


		if (GetComponent<Renderer>().isVisible == false)
		{
			Destroy (gameObject);
		}
		
		if (clockScript.day == true)
		{
			transform.Translate (startPos*retreatSpeed*Time.fixedDeltaTime);
			if (GetComponent<Renderer>().isVisible == false)
			{
				Destroy (gameObject);
			}
		}

		if (runUp == false)
		{

			transform.Translate (Goal.transform.position*speed*Time.fixedDeltaTime);
		}

		if (runUp == true)
		{
			timer += Time.deltaTime;
			transform.Translate (startPos *0.1f*Time.deltaTime);
			if (timer > 3)
			{
				runUp = false;
				timer = 0;
			}
		}

		print (runUp + "runup");
	
	
        
		//print ("closest " + closest.transform.position);

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Wall")
		{
			runUp = true;




		}

		if (other.gameObject.tag == "Chicken")
		{
			Destroy (gameObject);
		}

	}
	


}
	
