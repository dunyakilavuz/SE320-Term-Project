using UnityEngine;
using System.Collections;

public class RandomPoints : MonoBehaviour 
{
	GameObject rover;
	public GameObject targetPoint;
	Vector3 targetPosition;
	float radius;

	// Use this for initialization
	void Start () 
	{
		radius = 40f;
		rover = GameObject.Find ("Rover");

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.P) == true)
		{
			RandomPointFinder();			
		}
	}

	void RandomPointFinder()
	{
		Vector3 targetPosition = new Vector3(Random.Range(transform.position.x - radius, transform.position.x + radius)
		                                     , 5f, 
		                                     Random.Range(transform.position.z - radius, transform.position.z + radius));

		Instantiate(targetPoint, targetPosition, Quaternion.identity);
	}
}
