using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class SimulatedInput
{
    public string name = "";
    public float duration = 0.0f;
    public float axisValue = 0.0f;
    public float axisDelay = 0.0f;
    public SimulatedInputOption option;
}

public enum SimulatedInputOption { Wait, Button, ButtonDown, Axis , AxisRaw };

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

        if (now.option == SimulatedInputOption.AxisRaw)
        {
            StartCoroutine("computeAxisRaw", now);
        }

        if (now.option == SimulatedInputOption.Axis)
        {
            StartCoroutine("computeAxis", now);
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
        InputManager.inputs[name] = 1f;
    }

    IEnumerator computeButton(SimulatedInput btn)
    {
        InputManager.inputs[btn.name] = 1f;
        yield return new WaitForSeconds(btn.duration);
        InputManager.inputs.Remove(btn.name);
    }

    IEnumerator computeAxisRaw(SimulatedInput btn)
    {
        InputManager.inputs[btn.name] = btn.axisValue;
        yield return new WaitForSeconds(btn.duration);
        InputManager.inputs.Remove(btn.name);
    }

    IEnumerator computeAxis(SimulatedInput btn)
    {
        float waitAfterDelay = Mathf.Abs(btn.duration - btn.axisDelay);
        float velocity = 1f / btn.axisDelay;
        float timer = 0.0f;

        InputManager.inputs[btn.name] = btn.axisValue;

        while (timer < btn.axisDelay)
        {
            timer += Time.deltaTime;
            InputManager.inputs[btn.name] = (timer * velocity) * btn.axisValue;
            yield return null;
        }
        
        yield return new WaitForSeconds(waitAfterDelay);
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
