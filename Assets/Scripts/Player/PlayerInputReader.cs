using UnityEngine;
using System.Collections;

public class PlayerInputReader : MonoBehaviour {

	[SerializeField] PlayerMovement playerMovement = null;

	void Start () {
	
	}

	void Update () {
		playerMovement.moveHorizontal( InputManager.getAxis ("Horizontal"), InputManager.getAxis ("Vertical") );	
	}
}
