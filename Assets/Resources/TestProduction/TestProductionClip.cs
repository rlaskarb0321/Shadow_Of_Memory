using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class TestProductionClip : PlayableAsset, ITimelineClipAsset
{
    public TestProductionBehaviour template = new TestProductionBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<TestProductionBehaviour>.Create (graph, template);
        TestProductionBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
