using UnityEngine;
using System.Collections;

public class wallScript : MonoBehaviour {

	public float life;

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
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Baboon")
		{
			life--;
		}
	}
}
