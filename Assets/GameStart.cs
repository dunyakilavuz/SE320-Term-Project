using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour 
{
	public GameObject capsule;
	public GameObject rover;
	public GameObject reentry;
	public GameObject crash;

	float startTime = 0;
	float endTime;
	bool landed = false;
	public bool gameStartFinished = false;

	void Start () 
	{
		capsule.GetComponent<Rigidbody> ().AddForce (new Vector3 (-2050, 0, 0));
		crash.SetActive(false);
		reentry.SetActive (true);

	}

	void Update ()
	{
		if (capsule.transform.position.y <= 10 && landed == false) 
		{
			capsule.GetComponent<Rigidbody> ().isKinematic = true;
			crash.SetActive(true);
			reentry.SetActive(false);
			startTime = Time.time;
			endTime = startTime + 5;
			landed = true;
			rover.transform.parent = null;
			capsule.SetActive(false);
			rover.AddComponent<Rigidbody>();
			rover.GetComponent<Rigidbody>().useGravity = true;

		}

		if (startTime != 0 && Time.time > endTime) 
		{
			crash.SetActive(false);
			startTime = 0;
			gameStartFinished = true;
		}



	}
}
