using HT.Framework;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObject : HTBehaviour
{
    //启用自动化
    protected override bool IsAutomate => true;

    public ObjectsModel objects = null;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(CreateOrDestory);
    }

    private void CreateOrDestory()
    {

    }
}