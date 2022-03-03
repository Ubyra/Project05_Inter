using UnityEngine;

public abstract class GameStateMachine : MonoBehaviour
{
    protected GameState State;

    public void SetState(GameState newState)
    {
        State = newState;
        StartCoroutine(State.Start());
    }
}
