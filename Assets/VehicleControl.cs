using UnityEngine;
using System.Collections;

public class VehicleControl : MonoBehaviour 
{
	public float movementSpeed;
	float rotationSpeed;
	public bool easyMode = false;


	Vector3 targetPoint;
	Compiler compiler = new Compiler();
	public string code;
	public bool isMoving;
	public int movementType;
	GameObject GUIStuff;
	public GameObject GameManager;


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
		if (GameManager.GetComponent<GameStart> ().gameStartFinished == true)
		{
			if (easyMode == true)
			{
				EasyControl ();
			} else
			{
				HardControl ();
			}
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
		if(GUIStuff.GetComponent<GUIStuff>().execute == true)
		{
			compiler.readText(code,this.gameObject);
			compiler.processLine();
			GUIStuff.GetComponent<GUIStuff>().execute = false;
		}
		
		if(isMoving = false && compiler.code.Length > 0)
		{
			compiler.processLine();
		}
	
		if (isMoving == true) 
		{
			transform.Translate((targetPoint - transform.position).normalized * Time.deltaTime * movementSpeed);
		}

		if (Mathf.Abs(transform.position.x - targetPoint.x) < 0.5f && Mathf.Abs(transform.position.z - targetPoint.z) < 0.5f) 
		{
			isMoving = false;
		}
		
	}

	void moveForward()
	{
		if(GUIStuff.GetComponent<GUIStuff>().electricCharge > 0)
		{
			GUIStuff.GetComponent<GUIStuff>().electricCharge -= GUIStuff.GetComponent<GUIStuff>().electricCharge * 0.0001f;
			transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
			wheelFrontRight.transform.Rotate(movementSpeed,0,0);
			wheelFrontLeft.transform.Rotate(movementSpeed,0,0);
			wheelRearRight.transform.Rotate(movementSpeed,0,0);
			wheelRearLeft.transform.Rotate(movementSpeed,0,0);
		}
	}

	void moveBack()
	{
		if(GUIStuff.GetComponent<GUIStuff>().electricCharge > 0)
		{
			GUIStuff.GetComponent<GUIStuff>().electricCharge -= GUIStuff.GetComponent<GUIStuff>().electricCharge * 0.0001f;
			transform.Translate (Vector3.back * Time.deltaTime * movementSpeed);
			wheelFrontRight.transform.Rotate(-movementSpeed,0,0);
			wheelFrontLeft.transform.Rotate(-movementSpeed,0,0);
			wheelRearRight.transform.Rotate(-movementSpeed,0,0);
			wheelRearLeft.transform.Rotate(-movementSpeed,0,0);
		}
	}

	void rotateLeft()
	{
		if(GUIStuff.GetComponent<GUIStuff>().electricCharge > 0)
		{
			GUIStuff.GetComponent<GUIStuff>().electricCharge -= GUIStuff.GetComponent<GUIStuff>().electricCharge * 0.0001f;
			transform.Rotate(0,-rotationSpeed,0);
		}
		//wheelFrontRight.transform.Rotate(-movementSpeed,0,0);
		//wheelFrontLeft.transform.Rotate(-movementSpeed,0,0);
	}

	void rotateRight()
	{
		if(GUIStuff.GetComponent<GUIStuff>().electricCharge > 0)
		{
			GUIStuff.GetComponent<GUIStuff>().electricCharge -= GUIStuff.GetComponent<GUIStuff>().electricCharge * 0.0001f;
			transform.Rotate(0,rotationSpeed,0);
		}
		//wheelFrontRight.transform.Rotate(-movementSpeed,0,0);
		//wheelFrontLeft.transform.Rotate(-movementSpeed,0,0);
	}
}
