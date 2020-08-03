using Unity.Entities;
using UnityEngine;

public class FixedUpdatesLoop : MonoBehaviour
{
	private PlayerInputSystem _playerInputSystem;
	private PlayerMovementSystem _playerMovementSystem;

    void Start()
    {
	    var world = World.DefaultGameObjectInjectionWorld;
	    _playerInputSystem = world.GetOrCreateSystem<PlayerInputSystem>();
	    _playerMovementSystem = world.GetOrCreateSystem<PlayerMovementSystem>();
    }

    void FixedUpdate()
    {
	    _playerInputSystem.Update();
	    _playerMovementSystem.Update();
    }
}
