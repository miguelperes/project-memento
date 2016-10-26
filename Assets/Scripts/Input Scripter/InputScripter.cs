using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class SimulatedInput
{
    public string name = "";
    public float duration = 0.0f;
    public SimulatedInputOption option;
}

public enum SimulatedInputOption { Wait, Button, ButtonDown };

public class InputScripter: MonoBehaviour
{
    public List<SimulatedInput> simulatedInputs = new List<SimulatedInput>();

    bool waiting = false;

    void Update()
    {
        compute();
    }

    void compute()
    {
        if (waiting) return;

        if(simulatedInputs.Count == 0)
        {
            Debug.Log("Input Scripter: Done!");
            enabled = false;
            return;
        }

        SimulatedInput now = popSimulatedInput();

        if (now.option == SimulatedInputOption.Button)
        {
            StartCoroutine("computeButton", now);
        }

        if (now.option == SimulatedInputOption.ButtonDown)
        {
            computeButtonDown(now.name);
        }

        if (now.option == SimulatedInputOption.Wait)
        {
            waiting = true;
            Invoke("resumeComputation", now.duration);
        }
    }

    void resumeComputation()
    {
        waiting = false;
    }

    void computeButtonDown(string name)
    {
        InputManager.inputs.Add(name, 1);
    }

    IEnumerator computeButton(SimulatedInput btn)
    {
        InputManager.inputs.Add(btn.name, 1);
        yield return new WaitForSeconds(btn.duration);
        InputManager.inputs.Remove(btn.name);
    }

    public void addNewSimulatedInput()
    {
        simulatedInputs.Add(new SimulatedInput());
    }

    public void removeSimulatedInput(int index)
    {
        simulatedInputs.RemoveAt(index);
    }

    public SimulatedInput popSimulatedInput()
    {
        SimulatedInput head = simulatedInputs[0];
        removeSimulatedInput(0);
        return head;
    }

    public void moveSimulatedInputUp(int index)
    {
        if(index > 0)
        {
            SimulatedInput value = simulatedInputs[index];
            simulatedInputs.RemoveAt(index);
            simulatedInputs.Insert(index - 1, value);
        }
    }

    public void moveSimulatedInputDown(int index)
    {
        if (index < simulatedInputs.Count - 1)
        {
            SimulatedInput value = simulatedInputs[index];
            simulatedInputs.RemoveAt(index);
            simulatedInputs.Insert(index + 1, value);
        }
    }
}
