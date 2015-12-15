using UnityEngine;
using System.Collections;

public class GUIStuff : MonoBehaviour
{
	public string stringToEdit;
	GameObject rover;
	public bool execute = false;
	
	void Start()
	{
		stringToEdit = "";
		rover = GameObject.Find ("Rover");
	}

	void OnGUI() 
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
