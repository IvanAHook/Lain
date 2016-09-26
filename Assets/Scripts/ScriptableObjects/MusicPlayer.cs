using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "TerminalMusicPlayer")]
public class MusicPlayer : TerminalApplication {

	private AudioSource _audiosource;
	public AudioClip[] Clips;

	public override string Identifier
	{
		get { return "mPlayer"; }
	}

	public override string ParseInput(string[] args)
	{
		if (args[0] == "play")
		{
			if (args.Length < 2)
			{
				return "";
			}
			return OutputString(PlayClip(args[1]));
		}
		if (args[0] == "stop")
		{
			StopClip();
			return "";
		}
		if (args[0] == "list")
		{
			return OutputString(ListClips());
		}
		if (args[0] == "close")
		{
			return Close();
		}

		return OutputString(args[0]);
	}

	public override string Manual()
	{
		return OutputString("music player manual");
	}

	public override string Init(GameObject go)
	{
		_audiosource = go.gameObject.AddComponent<AudioSource>();
		return OutputString("music player initialized...");
	}

	public override string Close()
	{
		Destroy(_audiosource);
		return "";
	}

	private string OutputString(string s)
	{
		return Identifier + ": " + s;
	}

	private string PlayClip(string s)
	{
		for (int i = 0; i < Clips.Length; i++)
		{
			var clip = Clips[i];
			if (clip.name == s)
			{
				_audiosource.PlayOneShot(clip);
				return "playing: " + clip.name;
			}
		}
		return s + " not found...";
	}

	private void StopClip()
	{
		if (_audiosource.isPlaying)
		{
			_audiosource.Stop();
		}
	}

	private string ListClips()
	{
		if (Clips.Length == 0)
		{
			return "no clips in library";
		}
		
		string list = "";
		for (int i = 0; i < Clips.Length; i++)
		{
			var clip = Clips[i];
			list += clip.name + "\n";
		}
		return list;
	}
}
