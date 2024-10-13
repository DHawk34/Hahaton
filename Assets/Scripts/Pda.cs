using System;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class Pda : MonoBehaviour
{
    [SerializeField] private LocalizedStringTable localizedStringTable;
    [SerializeField] private TextMeshProUGUI tmpText;

    public void OpenBlock(int blockIndex)
    {
        var entryId = (blockIndex + 1).ToString();

        tmpText.text = localizedStringTable.GetTable().GetEntry(entryId).GetLocalizedString();
        tmpText.transform.parent.gameObject.SetActive(true);
    }
}
