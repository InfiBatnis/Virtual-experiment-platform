/************************************************************************************
    作者：荆煦添
    描述：存档更新事件
*************************************************************************************/
using HT.Framework;
/// <summary>
/// 存档更新事件
/// </summary>
public class RecordUpdateEventHandler : EventHandlerBase
{
    /// <summary>
    /// 填充数据，所有属性、字段的初始化工作可以在这里完成
    /// </summary>
    public RecordUpdateEventHandler Fill()
    {
        return this;
    }

    /// <summary>
    /// 重置引用，当被引用池回收时调用
    /// </summary>
    public override void Reset()
    {
        
    }
}
