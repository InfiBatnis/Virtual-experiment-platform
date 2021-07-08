using HT.Framework;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class RotateAmmeter : HTBehaviour
{
    private Vector3 PLC_eulerAngles;
    private Vector3 POS_eulerAngles;

    private Camera mCamera;
    private GameObject Ele;
    private GameObject Player_S;

    public Vector3 Ori_place;
    public Vector3 Ori_eulerAngles;
    public float Ori_fieldOfView;
    public float time = 15.0f;
    public bool moveable_look = false;
    public bool moveable_back = false;
    public bool Nowin = false;
    //启用自动化
    public float MaxA = 3.0f;
    public float NowA=0.0f;
    private float TarA;
    private bool OnGoing = false;
    public float times = 15.0f;
    public float ii;

    protected override bool IsAutomate => true;

    public void ShowNum(float num)
    {
        transform.Find("Cylinder005").transform.DOLocalRotate(new Vector3(0, 207.5f-82.5f*num /MaxA, 0), 1f).SetEase(Ease.OutExpo);
    }
    private void Look_back()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!Nowin && !moveable_look)
            {

                Player_S.GetComponent<FirstPersonController>().m_MouseLookRotate = false;
                Player_S.GetComponent<FirstPersonController>().m_WalkSpeed = 1;

                moveable_look = true;
                mCamera = GameObject.Find("FirstPersonCharacter").gameObject.GetComponent<Camera>();
                Ori_place = mCamera.transform.position;
                Ori_eulerAngles = mCamera.transform.rotation.eulerAngles;
                Ori_fieldOfView = mCamera.GetComponent<Camera>().fieldOfView;
            }
            else if (Nowin)
            {
                moveable_back = true;
            }

        }
        Look();
        Back();
    }

    private void Look()
    {
        if (moveable_look)
        {
            mCamera.transform.position += (Ele.transform.position - mCamera.transform.position) / time;
            PLC_eulerAngles = mCamera.transform.rotation.eulerAngles;
            POS_eulerAngles = Ele.transform.rotation.eulerAngles;
            PLC_eulerAngles += (POS_eulerAngles - PLC_eulerAngles) / time;
            mCamera.transform.rotation = Quaternion.Euler(PLC_eulerAngles);
            mCamera.fieldOfView -= (mCamera.fieldOfView - Ele.GetComponent<Camera>().fieldOfView) / time;
        }
        if (mCamera.fieldOfView < Ele.GetComponent<Camera>().fieldOfView + 0.01 && moveable_look)
        {
            mCamera.transform.position = Ele.transform.position;
            mCamera.transform.rotation = Ele.transform.rotation;
            mCamera.fieldOfView = Ele.GetComponent<Camera>().fieldOfView;
            moveable_look = false;
            Nowin = true;
        }
    }
    private void Back()
    {
        if (moveable_back)
        {
            mCamera.transform.position += (Ori_place - mCamera.transform.position) / time;
            PLC_eulerAngles = mCamera.transform.rotation.eulerAngles;
            POS_eulerAngles = Ori_eulerAngles;
            PLC_eulerAngles += (POS_eulerAngles - PLC_eulerAngles) / time;
            mCamera.transform.rotation = Quaternion.Euler(PLC_eulerAngles);
            mCamera.fieldOfView += (Ori_fieldOfView - mCamera.fieldOfView) / time;
        }
        if (mCamera.fieldOfView > Ori_fieldOfView - 0.01 && moveable_back)
        {
            mCamera.transform.position = Ori_place;
            mCamera.transform.rotation = Quaternion.Euler(Ori_eulerAngles);
            mCamera.fieldOfView = Ori_fieldOfView;
            moveable_back = false;
            Nowin = false;
            Player_S.GetComponent<FirstPersonController>().m_MouseLookRotate = true;
            Player_S.GetComponent<FirstPersonController>().m_WalkSpeed = 30;

        }
    }


    void Start()
    {

        mCamera = GameObject.Find("FirstPersonCharacter").gameObject.GetComponent<Camera>();
        Ele = this.transform.Find("Camera").gameObject;
        Player_S = GameObject.Find("FPSController").gameObject;
    }

    private void Update()
    {
        Look_back();
    }

}
