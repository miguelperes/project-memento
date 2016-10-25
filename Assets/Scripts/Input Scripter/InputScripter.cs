using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class InputType
{
    public string name = string.Empty;
    public Color bg = Color.green;
}

public class InputScripter : MonoBehaviour {

    public List<InputType> input = new List<InputType>();
	
    public void addNewInput()
    {
        input.Add(new InputType());
    }

    public void removeInput(int index)
    {
        input.RemoveAt(index);
    }
}
