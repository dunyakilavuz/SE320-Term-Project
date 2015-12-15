using UnityEngine;
using System.Collections;

public class VehicleControl : MonoBehaviour 
{
	public float movementSpeed = 2f;
	float rotationSpeed = 0.5f;
	public bool easyMode = false;

	Vector3 targetPoint;
	Compiler compiler = new Compiler();
	public string code;
	public bool isMoving;
	GameObject GUIStuff;

	void Start()
	{
		GUIStuff = GameObject.Find ("GUI Stuff");
	}


	void Update () 
	{
		if (easyMode == true)
		{
			EasyControl ();
		} 
		else
		{
			if(GUIStuff.GetComponent<GUIStuff>().execute == true)
			{
				compiler.readText(code,this.gameObject);
				compiler.processLine();
				GUIStuff.GetComponent<GUIStuff>().execute = false;
			}
			/*
			if(isMoving = false && compiler.code.Length != 0)
			{
				compiler.processLine();
			}
			*/

			HardControl ();
		}
	}

	void EasyControl()
	{
		if (Input.GetKey (KeyCode.W) == true)
		{
			transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
		}
		if (Input.GetKey (KeyCode.S) == true)
		{
			transform.Translate (Vector3.back * Time.deltaTime * movementSpeed);
		}
		if (Input.GetKey (KeyCode.A) == true)
		{
			transform.Rotate(0,-rotationSpeed,0);
		}
		if (Input.GetKey (KeyCode.D) == true)
		{
			transform.Rotate(0,rotationSpeed,0);
		}
	}

	public void HardControl()
	{
		if (isMoving == true) 
		{
			transform.Translate((targetPoint - transform.position).normalized * Time.deltaTime * movementSpeed);
		}

		if (Vector3.Distance (transform.position, targetPoint) < 1f) 
		{
			isMoving = false;
		}
		
	}


	public void takeInstruction(int movementType,int value)
	{
		if (movementType == 1) 
		{
			targetPoint = transform.position + Vector3.forward * value;
			Debug.Log("Target Point: " + targetPoint);
			isMoving = true;
		}
		if (movementType == 2) 
		{
			targetPoint = transform.position + Vector3.back * value;
			isMoving = true;
		}
	}
}
