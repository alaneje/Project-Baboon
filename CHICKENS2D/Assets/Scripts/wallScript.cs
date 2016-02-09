using UnityEngine;
using System.Collections;

public class wallScript : MonoBehaviour {

	public int life;

	public GameObject upgradedWallTop;
	public GameObject upgradedWallBottom;

	// Use this for initialization
	void Start () {

		life = 10;



	
	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject.tag == "WallTop") {
			upgradedWallTop = GameObject.FindGameObjectWithTag ("WallUpgradeTop");
			if (transform.position == upgradedWallTop.transform.position)
			{
				Destroy(gameObject);
			}
		} else {

	
		}

		if (gameObject.tag == "WallBottom") {

			upgradedWallBottom = GameObject.FindGameObjectWithTag ("WallUpgradeBottom");

			if (transform.position == upgradedWallBottom.transform.position)
			{
				Destroy(gameObject);
			}
		} else {
		}


		



		if (life <=0)
		{
			Destroy (gameObject);
		}

		print (upgradedWallBottom.transform.position);
		print (transform.position);
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Baboon")
		{
			life--;
		}



	}
}
