using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(InputScripter))]
public class CustomInputScripter : Editor {
    InputScripter it;

    void OnEnable()
    {
        it = target as InputScripter;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.Label("" + it.input.Count);

        if(GUILayout.Button("New"))
        {
            it.addNewInput();
        }

        for(int i = 0; i < it.input.Count; i++)
        {
            //GUILayout.Space(5);

            //GUILayout.BeginVertical();
            GUILayout.BeginHorizontal("box");

            it.input[i].name = GUILayout.TextField(it.input[i].name, GUILayout.ExpandWidth(true));

            if(GUILayout.Button("X", GUILayout.Width(Screen.width * 0.1f)))
            {
                it.removeInput(i);
                return;
            }

            GUILayout.EndHorizontal();
            //GUILayout.EndVertical();

        }

        GUILayout.Space(20);
        base.OnInspectorGUI();
    }
}
