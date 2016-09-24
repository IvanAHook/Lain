using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using System.Collections;

public class Terminal : MonoBehaviour {

	public Text TerminalText;
	public InputField TerminalInputField;

	private static readonly char[] DelimiterChars = { ' ' };

	public TerminalApplication[] Apps;
	private int? _selectedAppIndex;
	private TerminalApplication _selectedApp
	{
		get
		{
			if (_selectedAppIndex == null)
			{
				return null;
			}
			return Apps[(int)_selectedAppIndex];
		}
	}

	public void InputText(string s)
	{
		ParseString(s);
		ResetTerminalInputField();
	}

	public void ParseString(string s)
	{
		var args = s.Split(DelimiterChars).ToArray();

		if (_selectedApp == null)
		{
			Print(SelectApp(args[0]));
		}
		else
		{
			if (args.Length == 1 && args[0] == "close") 
			{
				Print("application " + _selectedApp.Identifier + " closed.");
				CloseApp();
				return;
			}
			Print(_selectedApp.ParseInput(args));
		}

	}

	private string SelectApp(string s)
	{
		for (int i = 0; i < Apps.Length; i++)
		{
			if (Apps[i].Identifier == s)
			{
				_selectedAppIndex = i;
				return _selectedApp.Init(this.gameObject);
			}
		}
		return "invalid command " + s + ".";
	}

	private void CloseApp()
	{
		_selectedAppIndex = null;
	}

	private void Print(string s)
	{
		TerminalText.text += Environment.NewLine + string.Format(s);
	}

	private void ResetTerminalInputField()
	{
		TerminalInputField.Select();
		TerminalInputField.ActivateInputField();
		TerminalInputField.text = "";
	}

}
