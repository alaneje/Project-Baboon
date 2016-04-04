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

	
		if (life <=0)
		{
			Destroy (gameObject);
		}

		Debug.Log(this.transform.position);
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Baboon")
		{
			life--;
		}



	}
}
