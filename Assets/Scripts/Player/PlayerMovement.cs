using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody rigid;

	[SerializeField] float speed = 2.0F;
    
	void Start ()
    {
		rigid = GetComponent<Rigidbody> ();
	}

	public void move(float x, float y)
    {
        Vector3 moveVector = speed * (new Vector3(x, 0f, y)).normalized;
        Vector3 verticalVelocity = new Vector3(0f, rigid.velocity.y, 0f);

        rigid.velocity = verticalVelocity + moveVector;
	}
}
