using UnityEngine;
using System.Collections;

public class Compiler
{
	public string code;
	string commandString;
	string valueString ;
	bool readMode;
	int value;
	GameObject rover;

	public void readText(string myCode,GameObject myObject)
	{
		code = myCode;
		rover = myObject;
	}

	public void processLine()
	{
		int i = 0;
		commandString = "";
		valueString = "";
		readMode = false;

		while (code.Substring(i,1) != ";") 
		{
			if(code.Substring(i,1) == " ")
			{
				readMode = !readMode;
			}

			if(readMode == false)
			{
				commandString = commandString + code.Substring(i,1);
			}
			else
			{
				valueString  = valueString  + code.Substring(i,1);
			}

			i++;
		}

		readMode = !readMode;
		int.TryParse (valueString, out value);
		
		if(commandString == "forward")
		{
			rover.GetComponent<VehicleControl>().takeInstruction(1,value);
		}
		else if(commandString == "back")
		{
			rover.GetComponent<VehicleControl>().takeInstruction(2,value);
		}
		Debug.Log ("code: " + code);
		code.Remove (0, i);
		Debug.Log ("code: " + code);
		
	}
}
