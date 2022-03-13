using UnityEngine;

public abstract class MatchStateMachine : MonoBehaviour
{
    protected MatchState PreviousState;
    protected MatchState State;

    public void SetState(MatchState state)
    {
        PreviousState = State != null ? State : state;
        State = state;

        StartCoroutine(State.Start());
    }
}