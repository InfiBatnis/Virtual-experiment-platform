/************************************************************************************
    作者：荆煦添
    描述：选择存档并保存
*************************************************************************************/
using HT.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChooseRecord : HTBehaviour
{
    public GameObject RecordObj;
    public SaveRecordCell AddNewObj;
    public InputField NameInput;
    public Button Confirm;

    private List<SaveRecordCell> showedRecords = new List<SaveRecordCell>();

    private Button choosed
    {
        get => _choosed; set
        {
            if (_choosed != null)
                _choosed.interactable = true;
            _choosed = value;
            _choosed.interactable = false;
            NameInput.text = _choosed.gameObject.GetComponent<SaveRecordCell>().title;
        }
    }
    private Button _choosed;
    void Start()
    {
        Main.m_Event.Subscribe<RecordUpdateEventHandler>(RefreshRecord);
        RefreshRecord();
        Confirm.onClick.AddListener(() =>
        {
            if(RecordManager.GetFirstNone()== choosed.gameObject.GetComponent<SaveRecordCell>().recordId)
            {
                Record record = RecordManager.tempRecord.DeepCopy<Record>();
                record.info = new RecordInfo()
                {
                    id = choosed.gameObject.GetComponent<SaveRecordCell>().recordId,
                    time = DateTime.Now,
                    title = NameInput.text
                };
                record.Save();
                Main.m_UI.NavigateBackTemporaryUI();
            }
            else
            {
                UIAPI.Instance.ShowModel(new ModelDialogModel()
                {
                    Message = new BindableString("确认要覆盖该存档吗？"),
                    ConfirmAction = () =>
                    {
                        Record record = RecordManager.tempRecord.DeepCopy<Record>();
                        record.info = new RecordInfo()
                        {
                            id = choosed.gameObject.GetComponent<SaveRecordCell>().recordId,
                            time = DateTime.Now,
                            title = NameInput.text
                        };
                        record.Save();
                        Main.m_UI.NavigateBackTemporaryUI();
                    }
                });
            }
        });
    }

    private void RefreshRecord()
    {
        AddNewObj.chooseRecord = this;
        AddNewObj.SetRecordInfo(new RecordInfo()
        {
            id = RecordManager.GetFirstNone(),
            time = DateTime.Now,
            title = $"新建存档{RecordManager.GetFirstNone()}"
        });
        choosed = AddNewObj.gameObject.GetComponent<Button>();

        foreach (var item in showedRecords)
            Destroy(item.gameObject);
        showedRecords.Clear();

        var list = RecordManager.recordInfos;
        foreach (var item in list)
        {
            var RecordCell = Instantiate<GameObject>(RecordObj, gameObject.transform).GetComponent<SaveRecordCell>();
            RecordCell.SetRecordInfo(item);
            RecordCell.chooseRecord = this;
            showedRecords.Add(RecordCell);
        }

        AddNewObj.gameObject.transform.SetAsLastSibling();
    }

    public void Choose(SaveRecordCell id)
    {
        choosed = id.gameObject.GetComponent<Button>();
    }

    void OnDestroy()
    {
        Main.m_Event.Unsubscribe<RecordUpdateEventHandler>(RefreshRecord);
    }
}
