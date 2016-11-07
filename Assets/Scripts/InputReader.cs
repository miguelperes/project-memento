using UnityEngine;
using System.Collections;

public class InputReader : MonoBehaviour {

	[SerializeField] PlayerMovement playerMovement = null;

	void Start () {
	
	}

	void Update () {
		playerMovement.moveHorizontal( InputManager.getAxis ("Horizontal"), InputManager.getAxis ("Vertical") );	
	}
}
