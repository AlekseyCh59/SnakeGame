using UnityEngine;

public class NewGameState : IState
{
    private GameObject _chooseWorld;
    public NewGameState()
    {
    }

    public NewGameState(GameObject chooseWorld)
    {
        _chooseWorld = chooseWorld;

    }

    public void OnEnter(StateController sc)
    {
        _chooseWorld.SetActive(true);
    }

    public void OnExit(StateController sc)
    {
        _chooseWorld.SetActive(false);
    }

    public void UpdateState(StateController sc)
    {
        throw new System.NotImplementedException();
    }

}
