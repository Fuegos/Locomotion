using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WalkingLeft : Action
{
    public WalkingLeft(Entity entity, Dictionary<string, Transform> sceleton) 
        : base(entity, sceleton)
    {

    }
    public override void TransformFoot()
    {
        throw new System.NotImplementedException();
    }

    public override void TransformForearm()
    {
        throw new System.NotImplementedException();
    }

    public override void TransformHead()
    {
        throw new System.NotImplementedException();
    }

    public override void TransformHip()
    {
        float df = (Time.deltaTime / entity.FindChromosome("TimeHalfCycle").Parameter);
        sceleton["hipLeft"].localRotation = Quaternion.Euler(sceleton["hipLeft"].localRotation.eulerAngles.x -
                entity.FindChromosome("WalkingRotationHipForwardX").Parameter * df,
                sceleton["hipLeft"].localRotation.eulerAngles.y, 
                sceleton["hipLeft"].localRotation.eulerAngles.z);
    }

    public override void TransformPelvis()
    {
        float df = (Time.deltaTime / entity.FindChromosome("TimeHalfCycle").Parameter);
        sceleton["pelvis"].localRotation = Quaternion.Euler(sceleton["pelvis"].localRotation.eulerAngles.x +
            entity.FindChromosome("WalkingRotationPelvisForwardX").Parameter * df,
                sceleton["pelvis"].localRotation.eulerAngles.y,
                sceleton["pelvis"].localRotation.eulerAngles.z);

        sceleton["pelvis"].localPosition += new Vector3
                (0,
                0,
                entity.FindChromosome("WalkingTransformPelvisForwardZ").Parameter * df);
    }

    public override void TransformShin()
    {
        throw new System.NotImplementedException();
    }

    public override void TransformShoulder()
    {
       float df = (Time.deltaTime / entity.FindChromosome("TimeHalfCycle").Parameter);
        sceleton["shoulderRight"].localRotation = Quaternion.Euler(sceleton["shoulderRight"].localRotation.eulerAngles.x -
                entity.FindChromosome("WalkingRotationShoulderForwardX").Parameter * df,
                sceleton["shoulderRight"].localRotation.eulerAngles.y,
                sceleton["shoulderRight"].localRotation.eulerAngles.z);
    }

    public override void TransformTorso()
    {
        throw new System.NotImplementedException();
    }

    public override void TransformWrist()
    {
        throw new System.NotImplementedException();
    }
}
