using UnityEngine;
using System.Collections;

public class Compiler
{
	string code;
	string commandString;
	string valueString ;
	bool readMode;
	int value;

	void Start()
	{

	}

	void Update()
	{
	}

	public void readText(string myCode)
	{
		code = myCode;
	}

	public void readLine()
	{
		int i = 0;
		commandString = "";
		valueString = "";
		readMode = false;

		while (code.Substring(i,1) != ";") 
		{
			if(code.Substring(i,1) == " ")
			{
				readMode = true;
			}

			if(readMode == false)
			{
				commandString = commandString + code.Substring(i,1);
			}

			if(readMode == true) 
			{
				valueString  = valueString  + code.Substring(i,1);
			}

			i++;

			if(i == code.Length)
			{
				break;
			}
		}
		int.TryParse (valueString, out value);
	}
}
