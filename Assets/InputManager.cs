using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : ScriptableObject {

    public static Dictionary<string, int> inputs = new Dictionary<string, int>();

    public static bool getButton(string name)
    {
        if(Input.GetButton(name) || inputs.ContainsKey(name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool getButtonDown(string name)
    {
        if (Input.GetButtonDown(name) || inputs.ContainsKey(name))
        {
            inputs.Remove(name);
            return true;
        }
        else
        {
            return false;
        }
    }
}
