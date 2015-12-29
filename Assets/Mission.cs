using UnityEngine;
using System.Collections;

public class Mission : MonoBehaviour
{
	public int mission = 0;
	public GameObject mission1;
	public GameObject mission2;
	public GameObject mission3;
	public GameObject rover;

	public bool missionOver = false;
	bool missionStart = false;

	void Start () 
	{

	}

	void Update () 
	{
		if (missionStart == false && GetComponent<GameStart> ().gameStartFinished == true) 
		{
			mission = 1;
			missionStart = true;
		}

		if(Vector3.Distance(rover.transform.position, mission1.transform.position) < 5 && mission == 1)
		{
			mission = 2;
			mission1.SetActive(false);
		}

		if(Vector3.Distance(rover.transform.position, mission2.transform.position) < 5 && mission == 2)
		{
			mission = 3;
			mission2.SetActive(false);
		}

		if(Vector3.Distance(rover.transform.position, mission3.transform.position) < 5 && mission == 3)
		{
			Debug.Log("Mission Over");
			mission3.SetActive(false);
			missionOver = true;
		}
	}
}
