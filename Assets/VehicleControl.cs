using UnityEngine;
using System.Collections;

public class VehicleControl : MonoBehaviour 
{
	public float movementSpeed;
	float rotationSpeed;
	public bool easyMode = false;

	float mouseX;
	float mouseY;
	Transform mouseRotation;

	Vector3 targetPoint;
	Compiler compiler = new Compiler();
	public string code;
	public bool isMoving;
	GameObject GUIStuff;
	public GameObject cameraOrbit;

	public GameObject wheelFrontLeft;
	public GameObject wheelFrontRight;
	public GameObject wheelRearLeft;
	public GameObject wheelRearRight;

	void Start()
	{
		GUIStuff = GameObject.Find ("GUI Stuff");
		movementSpeed = 8f;
		rotationSpeed = 1f;
	}


	void Update () 
	{
		if (Input.GetMouseButton (1)) 
		{
			mouseX = mouseX + Input.GetAxis ("Mouse X");
			mouseY = mouseY - Input.GetAxis("Mouse Y");
			cameraOrbit.transform.rotation = Quaternion.Euler (mouseY, mouseX, 0);

		}

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
			moveForward();

		}
		if (Input.GetKey (KeyCode.S) == true)
		{
			moveBack();

		}
		if (Input.GetKey (KeyCode.A) == true)
		{
			rotateLeft();
		}
		if (Input.GetKey (KeyCode.D) == true)
		{
			rotateRight();
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

	void moveForward()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
		wheelFrontRight.transform.Rotate(movementSpeed,0,0);
		wheelFrontLeft.transform.Rotate(movementSpeed,0,0);
		wheelRearRight.transform.Rotate(movementSpeed,0,0);
		wheelRearLeft.transform.Rotate(movementSpeed,0,0);
	}

	void moveBack()
	{
		transform.Translate (Vector3.back * Time.deltaTime * movementSpeed);
		wheelFrontRight.transform.Rotate(-movementSpeed,0,0);
		wheelFrontLeft.transform.Rotate(-movementSpeed,0,0);
		wheelRearRight.transform.Rotate(-movementSpeed,0,0);
		wheelRearLeft.transform.Rotate(-movementSpeed,0,0);
	}

	void rotateLeft()
	{
		transform.Rotate(0,-rotationSpeed,0);
		//wheelFrontRight.transform.Rotate(-movementSpeed,0,0);
		//wheelFrontLeft.transform.Rotate(-movementSpeed,0,0);
	}

	void rotateRight()
	{
		transform.Rotate(0,rotationSpeed,0);
		//wheelFrontRight.transform.Rotate(-movementSpeed,0,0);
		//wheelFrontLeft.transform.Rotate(-movementSpeed,0,0);
	}
}
