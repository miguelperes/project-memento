using UnityEngine;
using System.Collections;

public class InputReader : MonoBehaviour {

	[SerializeField] PlayerMovement playerMovement = null;

	void Start () {
	
	}

	void Update () {
		playerMovement.move (InputManager.getAxis ("Horizontal"), InputManager.getAxis ("Vertical"));	
	}
}
