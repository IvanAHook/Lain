using UnityEngine;

public abstract class TerminalApplication : ScriptableObject
{
	public abstract string Identifier{ get; }

	public abstract string ParseInput(string[] args);

	public abstract string Manual();

	public abstract string Init(GameObject go);

	public abstract string Close();

}
