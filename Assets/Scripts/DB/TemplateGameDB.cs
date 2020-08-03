using UnityEditor;
using UnityEngine;

//[CreateAssetMenu("TemplateGameDB")]
public class TemplateGameDB : ScriptableSingleton<TemplateGameDB>
{
	public GameObject playerPrefab;
	public int playerHealth = 100;
}
