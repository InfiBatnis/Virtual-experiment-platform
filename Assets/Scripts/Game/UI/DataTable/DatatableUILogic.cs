/************************************************************************************
    作者：荆煦添
    描述：数据表格UI逻辑类
*************************************************************************************/
using HT.Framework;
using System;
/// <summary>
/// 数据表格UI逻辑类
/// </summary>
[UIResource(null, null, "UI/Measurment/DataTable/DataTable")]
public class DatatableUILogic : UILogicResident
{
    /// <summary>
    /// 打开UI
    /// </summary>
    public override void OnOpen(params object[] args)
    {
        var tmp = UIEntity.transform.position;
        tmp.x = -800;
        UIEntity.transform.position = tmp;
        base.OnOpen(args);
    }

    public void Show()
    {
        var dt = UIEntity.GetComponentInChildren<DataTable>();
        dt.Show();
        UIShowHideHelper.ShowFromLeft(UIEntity);
    }

    public void Hide()
    {
        UIShowHideHelper.HideToLeft(UIEntity);
    }
}
