using Unity.Entities;
using UnityEngine;

public class FixedUpdatesLoop : MonoBehaviour
{
	private PlayerInputSystem _playerInputSystem;
	private PlayerMovementSystem _playerMovementSystem;
	private PlayerTurningSystem _playerTurningSystem;

    void Start()
    {
	    var world = World.DefaultGameObjectInjectionWorld;
	    _playerInputSystem = world.GetOrCreateSystem<PlayerInputSystem>();
	    _playerMovementSystem = world.GetOrCreateSystem<PlayerMovementSystem>();
	    _playerTurningSystem = world.GetOrCreateSystem<PlayerTurningSystem>();
    }

    void FixedUpdate()
    {
	    _playerInputSystem.Update();
	    _playerMovementSystem.Update();
	    _playerTurningSystem.Update();
    }
}
