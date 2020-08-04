using Unity.Entities;
using UnityEngine;

[DisableAutoCreation]
public class CameraFollowingSystem : SystemBase
{
	private bool _initialized = false;
	private Vector3 _offset;
	private Camera _camera;

	protected override void OnCreate()
	{
		base.OnCreate();
		_camera = Camera.main;
	}

	protected override void OnUpdate()
	{
		var dt = Time.DeltaTime;
        Entities.WithoutBurst().ForEach((Entity entity, Transform transform, ref PlayerInputData inputData) => {
            var gObj = transform.gameObject;
            var playerPosition = gObj.transform.position;

            if (!_initialized)
            {
	            _initialized = true;
	            _offset = _camera.transform.position - playerPosition;
            }

            var smoothing = TemplateGameDB.instance.cameraSmoothing;
            var targetCameraPosition = playerPosition + _offset;
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, targetCameraPosition, smoothing * dt);
        }).Run();
    }
}
