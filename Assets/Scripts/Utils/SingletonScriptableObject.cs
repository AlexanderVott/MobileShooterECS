using UnityEngine;

namespace RedDev.Helpers
{
	public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
	{
		private static T _instance = null;

		public static T instance
		{
			get
			{
				if (_instance == null)
				{
					var path = $"DB/{typeof(T).Name}";
					_instance = Resources.Load(path) as T;
				}
				return _instance;
			}
		}
	}
}