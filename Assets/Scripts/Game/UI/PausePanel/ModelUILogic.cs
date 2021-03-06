/************************************************************************************
    作者：荆煦添
    描述：模态提示框UI逻辑类
*************************************************************************************/
using HT.Framework;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 模态提示框UI逻辑类
/// </summary>
[UIResource(null, null, "UI/ModelPanel")]
public class ModelUILogic : WithSingleModeUILogic, IDataDriver<ModelDialogModel>
{
    public ModelDialogModel Data { get; set; } = new ModelDialogModel();

    [DataBinding("Title")] private Text Title;
    [DataBinding("Message")] private Text Message;
    [DataBinding("CancelText")] private Text CancelText;
    [DataBinding("ConfirmText")] private Text ConfirmText;

    private Button CancelButton;
    private Button ConfirmButton;

    /// <summary>
    /// 初始化
    /// </summary>
    public override void OnInit()
    {
        Data = new ModelDialogModel();

        foreach (var item in UIEntity.GetComponentsInChildren<Text>(true))
        {
            if (item.gameObject.name.Equals("Title"))
            {
                Title = item;
            }
            else if (item.gameObject.name.Equals("Message"))
            {
                Message = item;
            }
            else if (item.gameObject.transform.parent.gameObject.name.Equals("ConfirmButton"))
            {
                ConfirmText = item;
                ConfirmButton = item.gameObject.transform.parent.gameObject.GetComponent<Button>();
            }
            else if (item.gameObject.transform.parent.gameObject.name.Equals("CancelButton"))
            {
                CancelText = item;
                CancelButton = item.gameObject.transform.parent.gameObject.GetComponent<Button>();
            }
        }

        base.OnInit();

        CancelButton.onClick.AddListener(() =>
        {
            UIShowHideHelper.HideToUp(UIEntity);
            Data.CancelAction?.Invoke();
            NavigateBack();
        });
        ConfirmButton.onClick.AddListener(() =>
        {
            UIShowHideHelper.HideToUp(UIEntity);
            Data.ConfirmAction?.Invoke();
            NavigateBack();
        });
    }

    public void ShowModel(ModelDialogModel model)
    {
        this.Data.CancelText.Value = model.CancelText.Value;
        this.Data.ConfirmText.Value = model.ConfirmText.Value;
        this.Data.Title.Value = model.Title.Value;
        this.Data.Message.Value = model.Message.Value;
        this.Data.ConfirmAction = model.ConfirmAction;
        this.Data.CancelAction = model.CancelAction;

        if (model.ShowCancel)
        {
            var position = ConfirmButton.rectTransform().localPosition;
            position.y = -100;
            ConfirmButton.rectTransform().localPosition = position;
            CancelButton.gameObject.SetActive(true);
        }
        else
        {
            var position = ConfirmButton.rectTransform().localPosition;
            position.y = -150;
            ConfirmButton.rectTransform().localPosition = position;
            CancelButton.gameObject.SetActive(false);
        }

        Main.m_UI.OpenTemporaryUI<ModelUILogic>();
    }

    /// <summary>
    /// 打开UI
    /// </summary>
    public override void OnOpen(params object[] args)
    {
        base.OnOpen(args);
        UIShowHideHelper.ShowFromUp(UIEntity);
    }
}
