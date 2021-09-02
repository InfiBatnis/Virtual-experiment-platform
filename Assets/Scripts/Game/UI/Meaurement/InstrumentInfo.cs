/************************************************************************************
    作者：荆煦添
    描述：右键仪器信息的数据模型
*************************************************************************************/
using HT.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using System.Reflection;
using System.Collections;

public class InstrumentInfo : HTBehaviour
{
    [SerializeField]
    private Button _Mask;
    [SerializeField]
    private Text _Name;
    [SerializeField]
    private Text _LRV;
    [SerializeField]
    private Text _URV;
    [SerializeField]
    private Text _UnitSymbol;
    [SerializeField]
    private Text _Unit;
    [SerializeField]
    private InputField _MainValue;
    [SerializeField]
    private InputField _RandomError;
    [SerializeField]
    private Button _ConfirmButton;
    [SerializeField]
    private GameObject _RootPanel;
    [SerializeField]
    private Button _SwitchRange;

    private Dictionary<string, IntrumentInfoItem> infoItem = new Dictionary<string, IntrumentInfoItem>();
    private InstrumentBase _instrument;
    private bool initialized = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!initialized)
            Initialize();
    }

    public void ShowInstrument(Type instrument)
    {
        if (!initialized)
            Initialize();
        foreach (var item in infoItem)
            item.Value.onValueChanged.Clear();
        _instrument = GameManager.Instance.GetInstrument(instrument);
        _instrument.ShowInfoPanel(infoItem);
        StartCoroutine(CommonTools.DelayGet(_RootPanel.rectTransform().SetFloat));
    }

    

    private void Initialize()
    {
        infoItem.Clear();
        foreach (var item in typeof(InstrumentInfo).GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
        {
            UIBehaviour gameobj = null;
            try { gameobj = item.GetValue(this) as UIBehaviour; }
            catch { }
            if (gameobj != null)
            {
                infoItem.Add(item.Name, new IntrumentInfoItem()
                {
                    GameObject = gameobj.gameObject
                });
            }
        }
        _Mask.onClick.AddListener(() =>
        {
            foreach (var item in infoItem)
                item.Value.onValueChanged.Clear();
            Main.m_UI.CloseUI<InstrmentInfoUILogic>();
        });
        _MainValue.onValueChanged.AddListener(x =>
        {
            infoItem[nameof(_MainValue)].onValueChanged.ForEach(y => y.Invoke());
        });
        _RandomError.onValueChanged.AddListener(x =>
        {
            infoItem[nameof(_RandomError)].onValueChanged.ForEach(y => y.Invoke());
        });
        _ConfirmButton.onClick.AddListener(() =>
        {
            infoItem[nameof(_ConfirmButton)].onValueChanged.ForEach(y => y.Invoke());
            Main.m_UI.CloseUI<InstrmentInfoUILogic>();
        });
        _SwitchRange.onClick.AddListener(() =>
        {
            infoItem[nameof(_SwitchRange)].onValueChanged.ForEach(y => y.Invoke());
        });
        initialized = true;
    }
}


public class IntrumentInfoItem
{
    public GameObject GameObject { get; set; }
    public List<Action> onValueChanged { get; set; } = new List<Action>();
}