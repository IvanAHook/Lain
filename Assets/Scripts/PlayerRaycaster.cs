using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerRaycaster : MonoBehaviour {

	private FirstPersonController _fpsController;

	void Start()
	{
		_fpsController = GameObject.Find("FPSCharacter").GetComponent<FirstPersonController>();
	}

	void Update () {
		if (Input.GetMouseButtonDown(0) && !_fpsController.Locked)
		{
			// method for this
			RaycastHit hit;

			if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
			{
				Transform objectHit = hit.transform;
				if (objectHit.tag == "Terminal")
				{
					_fpsController.SetLocked(true);
					Messenger<bool>.Broadcast("focused", true);
				}

				// Do something with the object that was hit by the raycast.
			}
			// method for this
		}
		if (Input.GetMouseButtonDown(1) && _fpsController.Locked)
		{
			Messenger<bool>.Broadcast("focused", false);
			_fpsController.SetLocked(false);
		}
	}

}
