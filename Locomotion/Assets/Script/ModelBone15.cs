using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModelBone15 : Model
{
    public ModelBone15(Entity entity, Dictionary<string, Transform> sceleton) 
        : base(entity, sceleton)
    {
        sceleton["head"].gameObject.GetComponent<Rigidbody>().mass = 
            entity.FindChromosome("MassHead").Parameter;
        sceleton["torso"].gameObject.GetComponent<Rigidbody>().mass = 
            entity.FindChromosome("MassTorso").Parameter;

        sceleton["shoulderLeft"].gameObject.GetComponent<Rigidbody>().mass = 
            entity.FindChromosome("MassShoulder").Parameter;
        sceleton["forearmLeft"].gameObject.GetComponent<Rigidbody>().mass = 
            entity.FindChromosome("MassForearm").Parameter;
        sceleton["wristLeft"].gameObject.GetComponent<Rigidbody>().mass = 
            entity.FindChromosome("MassWrist").Parameter;

        sceleton["shoulderRight"].gameObject.GetComponent<Rigidbody>().mass = 
            entity.FindChromosome("MassShoulder").Parameter;
        sceleton["forearmRight"].gameObject.GetComponent<Rigidbody>().mass = 
            entity.FindChromosome("MassForearm").Parameter;
        sceleton["wristRight"].gameObject.GetComponent<Rigidbody>().mass = 
            entity.FindChromosome("MassWrist").Parameter;

        sceleton["shinLeft"].gameObject.GetComponent<Rigidbody>().mass = 
            entity.FindChromosome("MassShin").Parameter;
        sceleton["footLeft"].gameObject.GetComponent<Rigidbody>().mass = 
            entity.FindChromosome("MassFoot").Parameter;

        sceleton["shinRight"].gameObject.GetComponent<Rigidbody>().mass = 
            entity.FindChromosome("MassShin").Parameter;
        sceleton["footRight"].gameObject.GetComponent<Rigidbody>().mass = 
            entity.FindChromosome("MassFoot").Parameter;

        InitJoint(sceleton["head"].GetComponent<CharacterJoint>().swing2Limit, "Swing2LimitHead");
        InitJoint(sceleton["head"].GetComponent<CharacterJoint>().swing1Limit, "Swing1LimitHead");
        InitJoint(sceleton["head"].GetComponent<CharacterJoint>().lowTwistLimit, "LowTwistLimitHead");
        InitJoint(sceleton["head"].GetComponent<CharacterJoint>().highTwistLimit, "HighTwistLimitHead");

        InitJoint(sceleton["torso"].GetComponent<CharacterJoint>().swing2Limit, "Swing2LimitTorso");
        InitJoint(sceleton["torso"].GetComponent<CharacterJoint>().swing1Limit, "Swing1LimitTorso");
        InitJoint(sceleton["torso"].GetComponent<CharacterJoint>().lowTwistLimit, "LowTwistLimitTorso");
        InitJoint(sceleton["torso"].GetComponent<CharacterJoint>().highTwistLimit, "HighTwistLimitTorso");

        InitJoint(sceleton["shinLeft"].GetComponent<CharacterJoint>().swing2Limit, "Swing2LimitShin");
        InitJoint(sceleton["shinLeft"].GetComponent<CharacterJoint>().swing1Limit, "Swing1LimitShin");
        InitJoint(sceleton["shinLeft"].GetComponent<CharacterJoint>().lowTwistLimit, "LowTwistLimitShin");
        InitJoint(sceleton["shinLeft"].GetComponent<CharacterJoint>().highTwistLimit, "HighTwistLimitShin");

        InitJoint(sceleton["shinRight"].GetComponent<CharacterJoint>().swing2Limit, "Swing2LimitShin");
        InitJoint(sceleton["shinRight"].GetComponent<CharacterJoint>().swing1Limit, "Swing1LimitShin");
        InitJoint(sceleton["shinRight"].GetComponent<CharacterJoint>().lowTwistLimit, "LowTwistLimitShin");
        InitJoint(sceleton["shinRight"].GetComponent<CharacterJoint>().highTwistLimit, "HighTwistLimitShin");

        InitJoint(sceleton["footLeft"].GetComponent<CharacterJoint>().swing2Limit, "Swing2LimitFoot");
        InitJoint(sceleton["footLeft"].GetComponent<CharacterJoint>().swing1Limit, "Swing1LimitFoot");
        InitJoint(sceleton["footLeft"].GetComponent<CharacterJoint>().lowTwistLimit, "LowTwistLimitFoot");
        InitJoint(sceleton["footLeft"].GetComponent<CharacterJoint>().highTwistLimit, "HighTwistLimitFoot");

        InitJoint(sceleton["footRight"].GetComponent<CharacterJoint>().swing2Limit, "Swing2LimitFoot");
        InitJoint(sceleton["footRight"].GetComponent<CharacterJoint>().swing1Limit, "Swing1LimitFoot");
        InitJoint(sceleton["footRight"].GetComponent<CharacterJoint>().lowTwistLimit, "LowTwistLimitFoot");
        InitJoint(sceleton["footRight"].GetComponent<CharacterJoint>().highTwistLimit, "HighTwistLimitFoot");
    }

    public override void Step()
    {
        action.TransformPelvis();
        action.TransformHip();
        action.TransformShoulder();
    }
}
