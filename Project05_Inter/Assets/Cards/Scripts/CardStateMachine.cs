using UnityEngine;

public abstract class CardStateMachine : MonoBehaviour
{
    protected CardState PreviousState;
    protected CardState State;

    public void SetState(CardState state)
    {
        PreviousState = State != null ? State : state;
        State = state;

        StartCoroutine(State.Start());
    }
}
