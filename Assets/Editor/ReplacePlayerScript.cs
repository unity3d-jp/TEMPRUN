using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class ReplacePlayerScript : MonoBehaviour
{
	[MenuItem("PlayerScript/Step 1")]
	static void Player1 ()
	{
		Replace ("Player1");
	}

	[MenuItem("PlayerScript/Step 2")]
	static void Player2 ()
	{
		Replace ("Player2");
	}

	[MenuItem("PlayerScript/Step 3")]
	static void Player3 ()
	{
		Replace ("Player3");
	}

	[MenuItem("PlayerScript/Step 4")]
	static void Player4 ()
	{
		Replace ("Player4");
	}

	[MenuItem("PlayerScript/Step 5")]
	static void Player5 ()
	{
		Replace ("Player5");
	}

	static void Replace (string fileNameWithoutExtension)
	{
		string filePath = string.Format ("Assets/Editor/PlayerScripts/{0}.txt", fileNameWithoutExtension);

		MonoScript monoScript = null;
		foreach (var _monoScript in MonoImporter.GetAllRuntimeMonoScripts()) {
			if (_monoScript.name == "Player") {
				monoScript = _monoScript;
				break;
			}
		}

		if (monoScript == null) {
			EditorUtility.DisplayDialog ("Player.csが見つかりません", "ファイル名が間違っていませんか？", "OK");
			return;
		}

		File.WriteAllBytes (AssetDatabase.GetAssetPath (monoScript), File.ReadAllBytes (filePath));

		AssetDatabase.Refresh();
		Debug.Log("スクリプトコードを書き換えました");
	}
}
