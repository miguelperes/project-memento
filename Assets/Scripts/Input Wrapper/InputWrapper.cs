using UnityEngine;
using System.Collections;
using System;

public class InputWrapper : ScriptableObject
{
    static Hashtable activeSimulatedKeys = new Hashtable();

    public static Hashtable getActiveSimulatedKeys()
    {
        return activeSimulatedKeys;
    }

    public static void addSimulatedKey(string key)
    {
        activeSimulatedKeys.Add(key, 1);
    }

    public static void clearSimulatedInputs()
    {
        activeSimulatedKeys.Clear();
    }

    public static bool getButton(string key)
    {
        if (Input.GetButton(key) || activeSimulatedKeys.Contains(key))
            return true;
        else
            return false;
    }

    public static bool getButtonDown(string key)
    {
       if(Input.GetButtonDown(key) || activeSimulatedKeys.ContainsKey(key))
       {
            activeSimulatedKeys.Remove(key);
            return true;
       }
       else
       {
            return false;
       }
    }
}
