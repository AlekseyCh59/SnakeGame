using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    IState currentState;
    public NewGameState newGameState = new();
    public ContinueState continueState = new();
    public ShopState shopState = new();
    public UpgradeState upgradeState = new();
    public OptionsState optionsState = new();
    public ExitState exitState= new();
    public MainMenuState mainMenuState= new();


    private void Start()
    {
        currentState = null;
    }

    public void ChangeState(IState newState)
    {
        currentState.OnExit(this);
        currentState = newState;
        currentState.OnEnter(this);
    }

    public void NewGameClick()
    {
        ChangeState(new NewGameState);
    }

}

public interface IState
{
    public void OnEnter(StateController controller);
    public void UpdateState(StateController controller);
    public void OnExit(StateController controller);
}