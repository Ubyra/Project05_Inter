using UnityEngine;

public abstract class MatchSystem_StateMachine : MonoBehaviour
{
    protected MatchState PreviousState;
    protected MatchState State;

    public void SetState(MatchState state)
    {
        PreviousState = State == null ? state : State;
        State = state;

        StartCoroutine(State.Start());
    }
}
