using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject newGame;
    IState currentState;
    IState previousState;

    //не реализованы
    public ContinueState continueState = new();
    public ShopState shopState = new();
    public UpgradeState upgradeState = new();
    public OptionsState optionsState = new();
    public ExitState exitState= new();


    private void Start()
    {

        InitialState(new MainMenuState(mainMenu) );
    }

    public void ChangeState(IState newState)
    {
        currentState.OnExit(this);
        previousState = currentState;
        currentState = newState;
        currentState.OnEnter(this);
    }
    public void InitialState(IState newState)
    {
        currentState = newState;
        currentState.OnEnter(this);
    }

    public void NewGameClick()
    {
        ChangeState(new NewGameState(newGame));
    }

    public void BackClick()
    {
        ChangeState(previousState);
    }
}

public interface IState
{
    public void OnEnter(StateController controller);
    public void UpdateState(StateController controller);
    public void OnExit(StateController controller);
}