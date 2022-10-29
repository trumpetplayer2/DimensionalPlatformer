using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerBasedText : MonoBehaviour
{
    public TextMeshProUGUI PowerText;
    public TextMeshPro PowerBased;
    public string None;
    public string Portal;
    private void Update()
    {
        string powerString = PowerText.text.Substring(9).Trim().ToUpper();
        switch (powerString)
        {
            case "NONE":
                PowerBased.text = None;
                return;
            case "PORTAL":
                PowerBased.text = Portal;
                return;
            default: return;
        }
    }
}
