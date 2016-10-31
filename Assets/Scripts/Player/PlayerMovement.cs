using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody rigid;

	[SerializeField] float speed = 2.0F;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void move(float x, float y) {
		rigid.velocity = new Vector3 (x * speed, rigid.velocity.y, y * speed);
	}
}
