﻿using UnityEngine;
using System.Collections;

public class baboonScript : MonoBehaviour {

	public GameObject[] gos; 

	public GameObject closest;

	float speed;


	
	// Use this for initialization
	void Start () {
		

		speed = 2;
		
	}
	
	// Update is called once per frame
	void Update () {
		findClosestChicken ();
		transform.Translate (closest.transform.position*speed*Time.fixedDeltaTime);

		print ("closest " + closest.transform.position);

	}
	
	void findClosestChicken ()
	{
		

		gos = GameObject.FindGameObjectsWithTag ("Chicken");
		
		float distance = Mathf.Infinity;
		
		Vector3 position = transform.position;

		foreach (GameObject go in gos)
		{
			Vector3 difference = (go.transform.position - position);
			float curDistance = difference.sqrMagnitude;
			if (curDistance <= distance)
			{
				closest = go;
				distance = curDistance;
			}
		}


	}

}
