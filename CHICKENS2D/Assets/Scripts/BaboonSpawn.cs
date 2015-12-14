using UnityEngine;
using System.Collections;

public class BaboonSpawn : MonoBehaviour {
    public GameObject EnemyLocator;
    public GameObject Baboons;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SummonBaboon() //Locator is the gameobject it's set to aim for
    {

        baboonScript Bab = Instantiate(Baboons.GetComponent("baboonScript"), this.gameObject.transform.position, Quaternion.identity) as baboonScript; //Instantiates and accesses
        Bab.Goal = EnemyLocator; //Locator set up, it use goal as the aimed locaton
    }
}
