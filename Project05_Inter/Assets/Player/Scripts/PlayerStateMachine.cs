using UnityEngine;

public abstract class PlayerStateMachine : MonoBehaviour
{
    protected PlayerState PreviousState;
    protected PlayerState State;

    public void SetState(PlayerState state)
    {
        PreviousState = State != null ? State : state;
        State = state;

        StartCoroutine(State.Start());
    }
}