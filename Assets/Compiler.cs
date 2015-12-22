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
	int[] movementQueue = new int[20];

	public void readText(string myCode,GameObject myObject)
	{
		code = myCode;
		rover = myObject;
	}

	public void processLine()
	{
		int i = 0;
		int counter = 0;
		commandString = "";
		valueString = "";
		readMode = false;

		while (code.Substring(counter,1) != ";") 
		{
			while (code.Substring(counter,1) != ",") 
			{
				if(code.Substring(counter,1) == " ")
				{
					readMode = !readMode;
				}
				
				if(readMode == false)
				{
					commandString = commandString + code.Substring(counter,1);
				}
				else
				{
					valueString  = valueString  + code.Substring(counter,1);
				}
				
				counter++;
			}
			counter++;
			
			readMode = false;
			int.TryParse (valueString, out value);
			
			if(commandString == "forward")
			{
				movementQueue[i] = 1;
				movementQueue[i+1] = value;
				i = i + 2;
			}
			else if(commandString == "back")
			{
				movementQueue[i] = 2;
				movementQueue[i+1] = value;
				i = i + 2;
			}
		}
		Debug.Log (code);
		for(int a = 0; a < movementQueue.Length; a++)
		{
			Debug.Log(movementQueue[a]);
		}
	}
}
