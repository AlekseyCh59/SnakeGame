using UnityEngine;


public class MainMenuState : IState
{
    private GameObject _mainMenu;

    public MainMenuState(GameObject mainMenu)
    {
        _mainMenu = mainMenu;

    }
    public void OnEnter(StateController controller)
    {
        _mainMenu.SetActive(true);
    }

    public void OnExit(StateController controller)
    {
        _mainMenu.SetActive(false);
    }

    public void UpdateState(StateController controller)
    {
        throw new System.NotImplementedException();
    }
}