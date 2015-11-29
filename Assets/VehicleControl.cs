using UnityEngine;
using System.Collections;

public class VehicleControl : MonoBehaviour 
{
	public float movementSpeed = 2f;
	float rotationSpeed = 0.5f;
	public bool easyMode = false;

	Vector3 targetPoint;
	bool shouldMove;
	Compiler compiler = new Compiler();
	public string code;


	void Update () 
	{
		if (easyMode == true)
		{
			EasyControl ();
		} 
		else 
		{
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
		if (shouldMove == true) 
		{
			transform.Translate ((targetPoint - transform.position) * Time.deltaTime * movementSpeed);
			if((targetPoint - transform.position).magnitude < 1)
			{
				shouldMove = false;
			}
		}
	}


	public void takeInstruction(int movementType,int value)
	{
		if (movementType == 1) 
		{
			targetPoint = transform.position + Vector3.forward * value;
			shouldMove = true;


		}
	}
}
