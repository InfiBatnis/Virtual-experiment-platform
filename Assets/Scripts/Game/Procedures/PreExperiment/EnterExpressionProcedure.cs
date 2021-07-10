/************************************************************************************
    作者：张柯
    描述：输入合成量表达式流程
*************************************************************************************/
using HT.Framework;
/// <summary>
/// 进入输入合成量表达式流程
/// </summary>
public class EnterExpressionProcedure : ProcedureBase
{
    /// <summary>
    /// 进入流程
    /// </summary>
    /// <param name="lastProcedure">上一个离开的流程</param>
    public override void OnEnter(ProcedureBase lastProcedure)
    {
        Main.m_UI.OpenResidentUI<EnterExpressionUILogic>();
        base.OnEnter(lastProcedure);
    }

    /// <summary>
    /// 离开流程
    /// </summary>
    /// <param name="nextProcedure">下一个进入的流程</param>
    public override void OnLeave(ProcedureBase nextProcedure)
    {
        Main.m_UI.CloseUI<EnterExpressionUILogic>();
        base.OnLeave(nextProcedure);
    }
}