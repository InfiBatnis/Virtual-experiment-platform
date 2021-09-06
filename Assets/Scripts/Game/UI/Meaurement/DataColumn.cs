/************************************************************************************
    作者：荆煦添
    描述：数据记录表格的列
*************************************************************************************/
using HT.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataColumn : HTBehaviour
{
    public DataInput _dataInput;
    public GameObject _Content;
    public Text _Name;
    public QuantityModel Quantity => quantity;

    private QuantityModel quantity;
    private List<DataInput> showedInputs = new List<DataInput>();

    /// <summary>
    /// 一列代表一个物理量，显示这个物理量的值和名称单位
    /// </summary>
    public void ShowQuantity(QuantityModel quantity, bool inputable = false)
    {
        foreach (var item in showedInputs)
            Destroy(item.gameObject);
        showedInputs.Clear();
        this.quantity = quantity;
        if (_Name != null)
            _Name.text = quantity.Name;

        if (quantity.Data.Count != quantity.Groups)
        {
            quantity.Data.Clear();
            for (int i = 0; i < quantity.Groups; i++)
            {
                quantity.Data.Add("0");
                var showed = Instantiate(_dataInput, _Content.transform);
                showed.Inputable = inputable;
                showedInputs.Add(showed);
                showed.Show(quantity, i + 1);
                showed._Value.onEndEdit.AddListener(_ =>
                {
                    quantity.Data[i] = showed.Value;
                });
            }
        }
        else
        {
            for (int i = 0; i < quantity.Data.Count; i++)
            {
                var showed = Instantiate(_dataInput, _Content.transform);
                showedInputs.Add(showed);
                showed.Inputable = inputable;
                showed.Show(quantity, i + 1, quantity.Data[i]);
                int tmp = i;
                showed._Value.onEndEdit.AddListener(_ =>
                {
                    quantity.Data[tmp] = showed.Value;
                });
            }
        }
    }
}
