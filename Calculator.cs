using System;
using System.Data;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class Calculator : MonoBehaviour
{
    [SerializeField] private TMP_Text textField;
    [SerializeField] private TMP_Text historyField;
    [SerializeField] private GameObject history;
    private string result;
    private string field;

    //Numbers
    public void OnClick()
    {
        textField.text += gameObject.name;
    }

    public void OnClickDots()
    {
        if (textField.text != null)
        {
            textField.text += gameObject.name;
        }
    }

    //Any operations
    public void NullField() 
    {
        textField.text = null;
    }

    public void BackField()
    {
        textField.text = textField.text.Remove(textField.text.Length-1); ;
    }

    //SetResult + Add in history
    public void OnClickRov()
    {
        DataTable dtField = new DataTable();
        field = textField.text;
        result = (dtField.Compute(textField.text, "")).ToString();
        result = Regex.Replace(result, ",", ".");
        textField.text = result;
        historyField.text = field + "=" + result;
    }

    //History
    public void OnHistory()
    {
        history.SetActive(true);
    }

    public void BackToCalc()
    {
        history.SetActive(false);
    }
}
