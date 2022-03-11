using UnityEngine;

public abstract class NPC_StateMachine : MonoBehaviour
{
    protected NPC_State PreviousState;
    protected NPC_State State;

    public void SetState(NPC_State state)
    {
        PreviousState = State != null ? State : state;
        State = state;

        StartCoroutine(State.Start());
    }

}
