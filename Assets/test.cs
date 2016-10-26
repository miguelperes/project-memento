using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
    
	void Update () {
	    if(InputManager.getButtonDown("Fire1"))
        {
            Debug.Log("Fire1");
        }
        if (InputManager.getButtonDown("Fire2"))
        {
            Debug.Log("Fire2");
        }
        if (InputManager.getButton("Fire3"))
        {
            Debug.Log("Fire3");
        }

        Debug.Log("Vertical : " + InputManager.getAxisRaw("Vertical"));
        Debug.Log("Horizontal : " + InputManager.getAxis("Horizontal"));
    }
}
