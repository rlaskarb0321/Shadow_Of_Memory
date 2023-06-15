using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TestProductionMixerBehaviour : PlayableBehaviour
{
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        //int inputCount = playable.GetInputCount();

        //for (int i = 0; i < inputCount; i++)
        //{
        //    float inputWeight = playable.GetInputWeight(i);
        //    ScriptPlayable<TestProductionBehaviour> inputPlayable = (ScriptPlayable<TestProductionBehaviour>)playable.GetInput(i);
        //    TestProductionBehaviour input = inputPlayable.GetBehaviour ();
        //}

        if (Input.GetMouseButton(0))
        {
            Debug.Log("입력입력");
        }
    }
}
