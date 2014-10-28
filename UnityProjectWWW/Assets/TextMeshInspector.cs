using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(TextMesh))]
public class TextMeshInspector : Editor {

	Vector2 scroll;

	public override void OnInspectorGUI()
	{
		TextMesh t = (TextMesh)target;

		//DrawDefaultInspector();

		string text = t.text;

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Text");
		scroll = EditorGUILayout.BeginScrollView(scroll);
		GUILayoutOption[] options = new GUILayoutOption[2];
		options[0] = GUILayout.Height(100);
		options[1] = GUILayout.Width(200);
		text = EditorGUILayout.TextArea(text, options);
		EditorGUILayout.EndScrollView();
		EditorGUILayout.EndHorizontal();

		//Save everything
		t.text = text;
	}
}
