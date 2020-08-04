using RedDev.Game.Inputs;
using RedDev.Helpers;

public class Inputs : Singleton<Inputs>
{
	private InputActions _actions;
	public InputActions actions => _actions;

	protected override void Initialization()
	{
		base.Initialization();
		_actions = new InputActions();
		_actions.Enable();
	}

	protected override void Finalization()
	{
		base.Finalization();
		_actions.Disable();
	}
}
