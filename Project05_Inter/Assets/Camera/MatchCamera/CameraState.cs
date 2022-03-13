using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraState
{
    protected CameraSystem CamSystem;

    public CameraState(CameraSystem system)
    {
        CamSystem = system;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }
}
