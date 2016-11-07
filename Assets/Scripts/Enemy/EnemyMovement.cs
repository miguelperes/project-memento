using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public EnemyMovementController movementController;

	Rigidbody rigid;

	void Start () {
		rigid = GetComponent<Rigidbody> ();	
	}

	void Update () {
	
	}

	public void moveHorizontal(float dirX, float dirZ) {
		rigid.velocity = movementController.getHorizontalVelocity(dirX, dirZ, rigid.velocity.y);
	}
}
