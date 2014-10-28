using UnityEngine;
using UnityEditor;
using System.Collections;

public class SetupWindow : EditorWindow {

	public TextMesh gameObj;
	public string s;

	[MenuItem("Window/Text Mesh")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(SetupWindow));
	}

	void OnGUI()
	{
		TextMesh newGameObject = (TextMesh)EditorGUILayout.ObjectField(gameObj, typeof(TextMesh), true);

		if(newGameObject != gameObj)
		{
			ReadText(newGameObject);
		}

		if(gameObj != null && gameObj.GetComponent<TextMesh>() != null)
		{
			s = GUILayout.TextArea(s, GUILayout.Height(position.height - 50));
		}

		if(GUILayout.Button("Change Text"))
		{
			gameObj.text = s;
		}
	}

	void ReadText(TextMesh go)
	{
		s = go.text;
		gameObj = go;
	}
}
