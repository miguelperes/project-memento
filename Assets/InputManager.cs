using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    public bool testevar;

	public virtual bool cta(int i)
    {
        if(i == 1)
            testevar = true;
        else
            testevar = false;
        return testevar;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            cta(1);
        }
    }
}
