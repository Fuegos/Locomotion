using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
    public Entity entity { get; set; }
    public Dictionary<string, Transform> sceleton { get; set; }

    public Action(Entity entity, Dictionary<string, Transform> sceleton)
    {
        this.entity = entity;
        this.sceleton = sceleton;
    }

    public abstract void TransformHead();

    public abstract void TransformTorso();

    public abstract void TransformPelvis();

    public abstract void TransformShoulder();

    public abstract void TransformForearm();

    public abstract void TransformWrist();

    public abstract void TransformHip();

    public abstract void TransformShin();

    public abstract void TransformFoot();
}
