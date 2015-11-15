using UnityEngine;
using System.Collections;

public class VehicleControl : MonoBehaviour 
{
	float movementSpeed = 2f;
	float rotationSpeed = 0.5f;
	bool easyMode = true;

	void Start () 
	{
	
	}
	

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

	void HardControl()
	{
		Compiler.Compile ("Hello");
	}

}
