using UnityEngine;

public abstract class MatchStateMachine : MonoBehaviour
{
    protected Match_State PreviousState;
    protected Match_State State;

    public void SetState(Match_State state)
    {
        PreviousState = State != null ? State : state;
        State = state;

        StartCoroutine(State.Start());
    }
}