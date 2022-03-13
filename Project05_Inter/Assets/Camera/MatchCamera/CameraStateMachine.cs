using UnityEngine;

public abstract class CameraStateMachine : MonoBehaviour
{
    protected CameraState PreviousState;
    protected CameraState State;

    public void SetState(CameraState state)
    {
        PreviousState = State != null ? State : state;
        State = state;

        StartCoroutine(State.Start());
    }
}
