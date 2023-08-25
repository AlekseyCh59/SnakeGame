using UnityEngine;

public class NewGameState : IState
{
    public GameObject gameobj;
    public void OnEnter(StateController sc)
    {
        gameobj = GameObject.Find("StealTree");
        gameobj.SetActive(true);
    }

    public void OnExit(StateController sc)
    {
        gameobj.SetActive(false);
    }

    public void UpdateState(StateController sc)
    {
        throw new System.NotImplementedException();
    }

}
