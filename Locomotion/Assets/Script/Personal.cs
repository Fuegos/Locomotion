using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personal : MonoBehaviour
{
    public Transform head;
    public Transform torso;
    public Transform pelvis;

    public Transform shoulderLeft;
    public Transform forearmLeft;
    public Transform wristLeft;

    public Transform shoulderRight;
    public Transform forearmRight;
    public Transform wristRight;

    public Transform hipLeft;
    public Transform shinLeft;
    public Transform footLeft;

    public Transform hipRight;
    public Transform shinRight;
    public Transform footRight;
    
    public Transform personal;

    private Model model;

    void Start()
    {
        
    }

    public void CreatPersonal(Entity entity)
    {
        Dictionary<string, Transform> sceleton = new Dictionary<string, Transform>();
        switch (CardBone())
        {
            case "001000000100100":
                sceleton.Add("pelvis", pelvis);
                sceleton.Add("hipLeft", hipLeft);
                sceleton.Add("hipRight", hipRight);
                model = new ModelBone3(entity, sceleton);
                break;
            case "111111111111111":
                sceleton.Add("head", head);
                sceleton.Add("torso", torso);
                sceleton.Add("pelvis", pelvis);
                sceleton.Add("shoulderLeft", shoulderLeft);
                sceleton.Add("forearmLeft", forearmLeft);
                sceleton.Add("wristLeft", wristLeft);
                sceleton.Add("shoulderRight", shoulderRight);
                sceleton.Add("forearmRight", forearmRight);
                sceleton.Add("wristRight", wristRight);
                sceleton.Add("hipLeft", hipLeft);
                sceleton.Add("shinLeft", hipLeft);
                sceleton.Add("footLeft", hipLeft);
                sceleton.Add("hipRight", hipRight);
                sceleton.Add("shinRight", shinRight);
                sceleton.Add("footRight", footRight);
                model = new ModelBone15(entity, sceleton);
                break;
        }
        model.CreatStartPosition();

        
        InvokeRepeating("ActivateStep", 0, entity.FindChromosome("TimeHalfCycle").Parameter);
    }

    private string CardBone()
    {
        return CheckBone(head) + CheckBone(torso) + CheckBone(pelvis) +
            CheckBone(shoulderLeft) + CheckBone(forearmLeft) + CheckBone(wristLeft) +
            CheckBone(shoulderRight) + CheckBone(forearmRight) + CheckBone(wristRight) +
            CheckBone(hipLeft) + CheckBone(shinLeft) + CheckBone(footLeft) +
            CheckBone(hipRight) + CheckBone(shinRight) + CheckBone(footRight);
    }

    private string CheckBone(Transform bone)
    {
        if (bone != null)
            return "1"; 
        else
            return "0";
    }

    private void ActivateStep()
    {
        if (model.action is WalkingLeft)
        {
            model.action = new WalkingRight(model.action.entity, model.action.sceleton);
        }
        else if (model.action is WalkingRight)
        {
            model.action = new WalkingLeft(model.action.entity, model.action.sceleton);
        }
    }

    void Update()
    {
        if(model.action.entity.TimeLife > Parametrs.getInstance().maximumLife)
        {
            Dead();
        }
    }

    public void Dead()
    {
        model.action.entity.Distance = new Vector3(pelvis.position.x - model.StartPosition.x, 
            0, pelvis.position.z - model.StartPosition.z).magnitude;
        personal.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Scene").GetComponent<Scene>().WithdrawalEntity(model.action.entity);
        Destroy(personal.gameObject);
    }

    void FixedUpdate()
    {
        model.Step();
        model.action.entity.TimeLife += Time.deltaTime;
    }
}
