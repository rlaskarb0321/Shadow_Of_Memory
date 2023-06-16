using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TestProductionMixerBehaviour : PlayableBehaviour
{
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("입력입력");
        }
    }
}
