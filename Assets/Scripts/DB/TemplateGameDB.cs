using RedDev.Helpers;
using Unity.Entities;
using UnityEngine;

//[CreateAssetMenu(menuName = "Assets/TemplateGameDB")]
public class TemplateGameDB : SingletonScriptableObject<TemplateGameDB>
{
	public int playerHealth = 100;
	public float playerSpeed = 6f;
	public float playerAttackDistance = 30f;
	public float playerRateOfFire = 0.15f;

	public float cameraSmoothing = 6f;

	public int enemyHealth = 3;

	public float bulletSpeed = 10f;
	public float bulletLifeTime = 5f;
}
