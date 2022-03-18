using UnityEngine;

public abstract class Card_StateMachineR : MonoBehaviour
{
    protected Card_StateR PreviousState;
    protected Card_StateR State;

    public void SetState(Card_StateR state)
    {
        PreviousState = State == null ? state : State;
        State = state;

        StartCoroutine(State.Start());
    }
}
