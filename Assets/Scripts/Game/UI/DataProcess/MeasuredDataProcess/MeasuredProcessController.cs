using HT.Framework;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeasuredProcessController : HTBehaviour
{
    public Text _title;
    public GameObject _navigationBar;
    public Text _navigationTitle;
    public Button _backButton;
    public Button _continueButton;

    public Button _tableButton;
    public Button _differenceButton;
    public Button _regressionButton;
    public Button _graphicButton;

    public GameObject _chooserPanel;
    public DataColumn dataColumn1;
    public DataColumn dataColumn2;
    public MeasuredUncertainty measuredUncertainty;
    public MeasuredDifference1 measuredDifference1;
    public MeasuredDifference2 measuredDifference2;
    public MeasuredRegression1 measuredRegression1;
    public MeasuredRegression2 measuredRegression2;
    public MeasuredGraphic1 measuredGraphic1;
    public MeasuredGraphic2 measuredGraphic2;

    private QuantityModel quantity;

    private void Start()
    {
        _backButton.onClick.AddListener(BackButton);
        _continueButton.onClick.AddListener(ContinueButton);
        _tableButton.onClick.AddListener(ShowUncertainty);
        _differenceButton.onClick.AddListener(ShowDifference1);
        _regressionButton.onClick.AddListener(ShowRegression1);
        _graphicButton.onClick.AddListener(ShowGraphic1);
    }

    public void Show(QuantityModel quantity)
    {
        HideAllPanel();
        this.quantity = quantity;
        var instance = quantity.InstrumentType.CreateInstrumentInstance();
        _title.text = "????" + quantity.Name + ":" + quantity.Symbol + "/" + instance.UnitSymbol;
        try { measuredUncertainty.Show(quantity); } catch { }
        try { measuredDifference1.Show(quantity); } catch { }
        try { measuredDifference2.Show(quantity); } catch { }
        try { measuredRegression1.Show(quantity); } catch { }
        try { measuredRegression2.Show(quantity); } catch { }
        try { measuredGraphic1.Show(quantity); } catch { }
        try { measuredGraphic2.Show(quantity); } catch { }
        if (quantity.processMethod == 1) ShowUncertainty();
        else if (quantity.processMethod == 2)
        {
            if (measuredDifference1.CheckAll(true)) ShowDifference2();
            else ShowDifference1();
        }
        else if (quantity.processMethod == 3)
        {
            if (measuredRegression1.CheckAll(true)) ShowRegression2();
            else ShowRegression1();
        }
        else if (quantity.processMethod == 4)
        {
            if (measuredGraphic1.CheckAll(true)) ShowGraphic2();
            else ShowGraphic1();
        }
        else
        {
            ShowChooser();
        }
    }

    public bool CheckAll(bool silent = false)
    {
        if (measuredUncertainty.gameObject.activeSelf)
            return measuredUncertainty.CheckAll(silent);
        else if (measuredDifference2.gameObject.activeSelf)
            return measuredDifference2.CheckAll(silent);
        else if (measuredRegression2.gameObject.activeSelf)
            return measuredRegression2.CheckAll(silent);
        else if (measuredGraphic2.gameObject.activeSelf)
            return measuredGraphic2.CheckAll(silent);
        else if (quantity.processMethod == 1)
            return measuredUncertainty.CheckAll(silent);
        else if (quantity.processMethod == 2)
            return measuredDifference1.CheckAll(silent) && measuredDifference2.CheckAll(silent);
        else if (quantity.processMethod == 3)
            return measuredRegression1.CheckAll(silent) && measuredRegression2.CheckAll(silent);
        else if (quantity.processMethod == 4)
            return measuredGraphic1.CheckAll(silent) && measuredGraphic2.CheckAll(silent);
        if (!silent)
            UIAPI.Instance.ShowModel(new SimpleModel()
            {
                ShowCancel = false,
                Title = "??ʾ",
                Message = "????û?д?????????????"
            });
        return false;
    }

    private void ShowChooser()
    {
        HideAllPanel();
        ShowDatatable(dataColumn1, DataColumnType.Mesured, quantity.MesuredData);
        _chooserPanel.gameObject.SetActive(true);
    }

    private void BackButton()
    {
        //if (measuredUncertainty.gameObject.activeSelf || measuredDifference1.gameObject.activeSelf 
        //    || measuredRegression1.gameObject.activeSelf || measuredGraphic1.gameObject.activeSelf)
        //    ShowChooser();
        //else
        if (measuredDifference2.gameObject.activeSelf)
            ShowDifference1();
        else if (measuredRegression2.gameObject.activeSelf)
            ShowRegression1();
        else if (measuredGraphic2.gameObject.activeSelf)
            ShowGraphic1();
    }

    private void ContinueButton()
    {
        if (measuredDifference1.gameObject.activeSelf)
        {
            if (measuredDifference1.CheckAll())
                ShowDifference2();
        }
        else if (measuredRegression1.gameObject.activeSelf)
        {
            if (measuredRegression1.CheckAll())
                ShowRegression2();
        }
        else if (measuredGraphic1.gameObject.activeSelf)
        {
            if (measuredGraphic1.CheckAll())
                ShowGraphic2();
        }
    }

    private void ShowDatatable(DataColumn dataColumn, DataColumnType type, DataColumnModel data, bool readOnly = true)
    {
        dataColumn.gameObject.SetActive(true);
        dataColumn.SetClass(type);
        dataColumn.Show(data, true);
        dataColumn.ReadOnly = readOnly;
        dataColumn.Changable = false;
        dataColumn.Deletable = false;
    }

    private void HideAllPanel()
    {
        _navigationBar.SetActive(false);
        dataColumn1.gameObject.SetActive(false);
        dataColumn2.gameObject.SetActive(false);
        measuredUncertainty.gameObject.SetActive(false);
        measuredDifference1.gameObject.SetActive(false);
        measuredDifference2.gameObject.SetActive(false);
        measuredRegression1.gameObject.SetActive(false);
        measuredRegression2.gameObject.SetActive(false);
        measuredGraphic1.gameObject.SetActive(false);
        measuredGraphic2.gameObject.SetActive(false);
        _chooserPanel.gameObject.SetActive(false);
        _backButton.interactable = false;
        _continueButton.interactable = false;
    }

    private void ShowNavigationBar(string title, int size)
    {
        _navigationBar.SetActive(true);
        _navigationTitle.text = title;
        var sized = _navigationBar.rectTransform().sizeDelta;
        if (size == 1) sized.x = 750;
        else if (size == 2) sized.x = 550;
        else if (size == 3) sized.x = 350;
        _navigationBar.rectTransform().sizeDelta = sized;
        var position = _navigationBar.transform.localPosition;
        if (size == 1) position.x = 0;
        else if (size == 2) position.x = 100;
        else if (size == 3) position.x = 200;
        _navigationBar.transform.localPosition = position;
    }

    private void ShowUncertainty()
    {
        HideAllPanel();
        quantity.processMethod = 1;
        ShowDatatable(dataColumn1, DataColumnType.Mesured, quantity.MesuredData);
        ShowNavigationBar("ֱ?Ӽ??㲻ȷ????", 2);
        measuredUncertainty.gameObject.SetActive(true);
        measuredUncertainty.Show(quantity);
    }

    private void ShowDifference1()
    {
        HideAllPanel();
        quantity.processMethod = 2;
        ShowDatatable(dataColumn1, DataColumnType.Mesured, quantity.MesuredData);
        ShowDatatable(dataColumn2, DataColumnType.Differenced, quantity.DifferencedData, false);
        ShowNavigationBar("?????һ??", 3);
        measuredDifference1.gameObject.SetActive(true);
        measuredDifference1.Show(quantity);
        _continueButton.interactable = true;
    }

    private void ShowDifference2()
    {
        HideAllPanel();
        quantity.processMethod = 2;
        ShowDatatable(dataColumn1, DataColumnType.Differenced, quantity.DifferencedData);
        ShowNavigationBar("????ڶ???", 2);
        measuredDifference2.gameObject.SetActive(true);
        measuredDifference2.Show(quantity);
        _backButton.interactable = true;
    }

    private void ShowRegression1()
    {
        HideAllPanel();
        quantity.processMethod = 3;
        ShowDatatable(dataColumn1, DataColumnType.Mesured, quantity.MesuredData);
        ShowDatatable(dataColumn2, DataColumnType.Independent, quantity.IndependentData, false);
        ShowNavigationBar("һԪ???Իع?", 3);
        measuredRegression1.gameObject.SetActive(true);
        measuredRegression1.Show(quantity);
        _continueButton.interactable = true;
    }

    private void ShowRegression2()
    {
        HideAllPanel();
        quantity.processMethod = 3;
        ShowNavigationBar("һԪ???Իع鷨?ڶ???", 1);
        measuredRegression2.gameObject.SetActive(true);
        measuredRegression2.Show(quantity);
        _backButton.interactable = true;
    }

    private void ShowGraphic1()
    {
        HideAllPanel();
        quantity.processMethod = 4;
        ShowDatatable(dataColumn1, DataColumnType.Mesured, quantity.MesuredData);
        ShowDatatable(dataColumn2, DataColumnType.Graphic, quantity.IndependentData, false);
        ShowNavigationBar("ͼʾ??", 3);
        measuredGraphic1.gameObject.SetActive(true);
        measuredGraphic1.Show(quantity);
        _continueButton.interactable = true;
    }

    private void ShowGraphic2()
    {
        HideAllPanel();
        quantity.processMethod = 4;
        ShowNavigationBar("ͼʾ???ڶ???", 1);
        measuredGraphic2.gameObject.SetActive(true);
        measuredGraphic2.Show(quantity);
        _backButton.interactable = true;
    }
}
