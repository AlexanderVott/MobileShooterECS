using UnityEditor;
using UnityEngine;

//[CreateAssetMenu("TemplateGameDB")]
public class TemplateGameDB : ScriptableSingleton<TemplateGameDB>
{
	public GameObject playerPrefab;
	public int playerHealth = 100;
	public float playerSpeed = 6f;

	public float cameraSmoothing = 6f;

	public int enemyHealth = 3;
}
