using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(InputScripter))]
public class CustomInputScripter : Editor {
    InputScripter it;

    string[] inputOptions = new string[]
    {
        "Wait", "Button", "ButtonDown",
    };

    void OnEnable()
    {
        it = target as InputScripter;
    }

    public override void OnInspectorGUI()
    {
        plotHeader();

        for(int i = 0; i < it.simulatedInputs.Count; i++)
        {
            plotSimulatedInput(i);
        }
    }

    void plotHeader()
    {
        GUILayout.BeginHorizontal("box");

        GUILayout.Label("Total Inputs: " + it.simulatedInputs.Count);

        if (GUILayout.Button("New"))
        {
            it.addNewSimulatedInput();
        }

        GUILayout.EndHorizontal();
    }

    void plotSimulatedInput(int i)
    {
        GUILayout.BeginVertical("box");

        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Simulated Input:", GUILayout.ExpandWidth(true));
        it.simulatedInputs[i].option = (SimulatedInputOption) EditorGUILayout.Popup((int) it.simulatedInputs[i].option, inputOptions, GUILayout.Width(Screen.width * 0.35f));
        if (GUILayout.Button("X", GUILayout.Width(Screen.width * 0.1f)))
        {
            it.removeSimulatedInput(i);
            return;
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        if (it.simulatedInputs[i].option != SimulatedInputOption.Wait)
        {
            plotInputName(i);
        }

        if(it.simulatedInputs[i].option != SimulatedInputOption.ButtonDown)
        {
            plotInputDuration(i);
        }

        GUILayout.EndVertical();
    }

    void plotInputName(int i)
    {
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Name:", GUILayout.ExpandWidth(true));
        it.simulatedInputs[i].name = GUILayout.TextField(it.simulatedInputs[i].name, GUILayout.Width(Screen.width * 0.5f));
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }

    void plotInputDuration(int i)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Duration:", GUILayout.ExpandWidth(true));
        it.simulatedInputs[i].duration = EditorGUILayout.FloatField(it.simulatedInputs[i].duration, GUILayout.Width(Screen.width * 0.5f));
        GUILayout.EndHorizontal();
    }
}
