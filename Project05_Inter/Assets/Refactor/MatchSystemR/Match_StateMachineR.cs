using UnityEngine;

public abstract class Match_StateMachineR : MonoBehaviour
{
    protected Match_StateR PreviousState;
    protected Match_StateR State;

    public void SetState(Match_StateR state)
    {
        PreviousState = State == null ? state : State;
        State = state;

        StartCoroutine(State.Start());
    }
}
