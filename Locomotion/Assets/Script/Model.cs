using UnityEngine;
using System.Collections.Generic;

public abstract class Model
{
    public Action action { get; set; }

    public Vector3 StartPosition { get; set; }

    public Model(Entity entity, Dictionary<string, Transform> sceleton)
    {
        action = new WalkingLeft(entity, sceleton);
        sceleton["pelvis"].gameObject.GetComponent<Rigidbody>().mass = 
            entity.FindChromosome("MassPelvis").Parameter;
        sceleton["hipLeft"].gameObject.GetComponent<Rigidbody>().mass = 
            entity.FindChromosome("MassHip").Parameter;
        sceleton["hipRight"].gameObject.GetComponent<Rigidbody>().mass = 
            entity.FindChromosome("MassHip").Parameter;

        InitJoint(sceleton["hipLeft"].GetComponent<CharacterJoint>().swing2Limit, "Swing2LimitHip");
        InitJoint(sceleton["hipLeft"].GetComponent<CharacterJoint>().swing1Limit, "Swing1LimitHip");
        InitJoint(sceleton["hipLeft"].GetComponent<CharacterJoint>().lowTwistLimit, "LowTwistLimitHip");
        InitJoint(sceleton["hipLeft"].GetComponent<CharacterJoint>().highTwistLimit, "HighTwistLimitHip");

        InitJoint(sceleton["hipRight"].GetComponent<CharacterJoint>().swing2Limit, "Swing2LimitHip");
        InitJoint(sceleton["hipRight"].GetComponent<CharacterJoint>().swing1Limit, "Swing1LimitHip");
        InitJoint(sceleton["hipRight"].GetComponent<CharacterJoint>().lowTwistLimit, "LowTwistLimitHip");
        InitJoint(sceleton["hipRight"].GetComponent<CharacterJoint>().highTwistLimit, "HighTwistLimitHip");
    }

    public void CreatStartPosition()
    {
        StartPosition = action.sceleton["pelvis"].position;
    }

    public void InitJoint(SoftJointLimit Joint, string parameter)
    {
        SoftJointLimit temp = Joint;
        temp.limit = action.entity.FindChromosome(parameter).Parameter;
        Joint = temp;
    }

    public abstract void Step();

}
