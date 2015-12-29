using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIStuff : MonoBehaviour
{
	public string stringToEdit;
	GameObject rover;
	public bool execute = false;
	public GameObject GameManager;
	public GameObject infoScreen;
	public GameObject statusScreen;
	public GameObject arrow;
	public float electricCharge;

	float startTime = 0;
	float endTime;
	bool GUIstarted = false;
	
	void Start()
	{
		stringToEdit = "";
		rover = GameObject.Find ("Rover");
		infoScreen.SetActive (false);
		statusScreen.SetActive (false);
		arrow.SetActive(false);
		electricCharge = 1500;
	}

	void OnGUI() 
	{
		if (rover.GetComponent<VehicleControl> ().easyMode == false)
		{
			stringToEdit = GUI.TextArea(new Rect(10, 10, 200, 100), stringToEdit, 200);

			if (GUI.Button (new Rect (10, 110, 100, 20), "Execute") == true) 
			{
				if(stringToEdit != "")
				{
					rover.GetComponent<VehicleControl>().code = stringToEdit;
					execute = true;
				}
			}
		}
	}

	void Update()
	{
		if (GUIstarted == false && GameManager.GetComponent<GameStart> ().gameStartFinished == true) 
		{
			infoScreen.SetActive (true);
			statusScreen.SetActive (true);
			statusScreen.GetComponent<TextMesh>().text = "Your solar panels are broken!";
			startTime = Time.time;
			endTime = startTime + 5;
			GUIstarted = true;
		}

		if (startTime != 0 && Time.time > endTime)
		{
			arrow.SetActive(true);
			statusScreen.SetActive(false);
			startTime = 0;
		}
		infoScreen.GetComponent<TextMesh>().text = "Electric Charge: " + electricCharge;

		if (GameManager.GetComponent<Mission> ().missionOver == true) 
		{
			arrow.SetActive(false);
			statusScreen.SetActive(true);
			statusScreen.GetComponent<TextMesh>().text = "You have done it!";
		}

		if (GameManager.GetComponent<Mission> ().mission == 1) 
		{
			arrow.transform.LookAt (GameManager.GetComponent<Mission> ().mission1.transform.position);
		}
		else if (GameManager.GetComponent<Mission> ().mission == 2) 
		{
			arrow.transform.LookAt (GameManager.GetComponent<Mission> ().mission2.transform.position);
		}
		else if (GameManager.GetComponent<Mission> ().mission == 3) 
		{
			arrow.transform.LookAt (GameManager.GetComponent<Mission> ().mission3.transform.position);
		}

	}
}
