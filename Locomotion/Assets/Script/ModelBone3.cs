using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModelBone3 : Model
{
    public ModelBone3(Entity entity, Dictionary<string, Transform> sceleton) 
        : base(entity, sceleton)
    {
        
    }

    public override void Step()
    {
        action.TransformPelvis();
        action.TransformHip();
    }
}
