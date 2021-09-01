/************************************************************************************
    作者：荆煦添
    描述：添加物理量UI逻辑类
*************************************************************************************/
using HT.Framework;
/// <summary>
/// 添加物理量UI逻辑类
/// </summary>
[UIResource(null, null, "UI/PreExperiment/AddQuantityPanel")]
public class AddValueUILogic : UILogicResident
{
    public override void OnOpen(params object[] args)
    {
        base.OnOpen(args);
        UIEntity.GetComponentInChildren<QuantityManage>(true).LoadQuantities();
    }
}
