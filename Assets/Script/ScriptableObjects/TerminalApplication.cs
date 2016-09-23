using UnityEngine;

public abstract class TerminalApplication : ScriptableObject
{

	public abstract void ParseInput();
	public abstract string Manual();

}
