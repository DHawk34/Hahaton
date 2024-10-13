using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using static UnityEngine.Rendering.DebugUI;

public class DialogueSystem : MonoBehaviour
{
    private TMP_Text textMeshPro;

    [SerializeField]
    [Range(0, 1)]
    private float textSpeed;

    [SerializeField]
    [Range(0, 5)]
    private float timeForNext;

    [SerializeField]
    [Range(0, 10)]
    private float fadeInTime;

    [SerializeField]
    [Range(0, 10)]
    private float fadeOutTime;

    private int currentPhrase = -1;
    private string currentText = "";
    private StringTable currentTable;

    private CanvasGroup canvasGroup;

    private bool fadeIn;
    private bool fadeOut;

    private bool typeTexting = false;

    IEnumerator TypeTextEnumeratorObj;
    IEnumerator LastSignEnumeratorObj;
    IEnumerator NextPhraseEnumeratorObj;

    private List<SharedTableData.SharedTableEntry> entries = new List<SharedTableData.SharedTableEntry>();

    private bool skippable = true;
    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = GetComponentInChildren<CanvasGroup>();
        textMeshPro = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        InputManager.Input.Player.LeftClick.performed += Skip;
    }

    private void OnDisable()
    {
        InputManager.Input.Player.LeftClick.performed -= Skip;
    }

    private void Skip(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!skippable)
            return;

        if (TypeTextEnumeratorObj != null)
        {
            if (typeTexting)
            {
                if (LastSignEnumeratorObj != null)
                    StopCoroutine(LastSignEnumeratorObj);

                StopCoroutine(TypeTextEnumeratorObj);
                textMeshPro.text = currentText + "█";

                LastSignEnumeratorObj = AnimateLastSign();
                NextPhraseEnumeratorObj = NextPhrase();

                StartCoroutine(LastSignEnumeratorObj);
                StartCoroutine(NextPhraseEnumeratorObj);

                typeTexting = false;
            }
            else
            {
                if (LastSignEnumeratorObj != null)
                    StopCoroutine(LastSignEnumeratorObj);

                StopCoroutine(NextPhraseEnumeratorObj);
                GetNextPhrase();
            }
        }
    }

    public void StartDialogue(LocalizedStringTable Dialog, bool skippable = false)
    {
        this.skippable = skippable;
        Show();
        currentPhrase = -1;
        currentTable = Dialog.GetTable();
        entries = currentTable.SharedData.Entries;
        GetNextPhrase();
    }

    private void Show()
    {
        fadeOut = false;
        fadeIn = true;
    }

    private void Hide()
    {
        fadeIn = false;
        fadeOut = true;
    }

    private void Update()
    {
        if (fadeIn)
        {
            canvasGroup.alpha += 1 / fadeInTime * Time.deltaTime;
            if (canvasGroup.alpha >= 1)
            {
                fadeIn = false;
            }

        }

        if (fadeOut)
        {
            canvasGroup.alpha -= 1 / fadeOutTime * Time.deltaTime;
            if (canvasGroup.alpha <= 0)
            {
                fadeOut = false;
            }
        }
    }

    private void TypeText()
    {
        if (TypeTextEnumeratorObj != null)
            StopCoroutine(TypeTextEnumeratorObj);

        if (LastSignEnumeratorObj != null)
            StopCoroutine(LastSignEnumeratorObj);

        TypeTextEnumeratorObj = TypeTextEnum();

        StartCoroutine(TypeTextEnumeratorObj);
    }

    private void GetNextPhrase()
    {
        currentPhrase++;
        if (currentPhrase <= entries.Count - 1)
        {
            var entry = currentTable.GetEntry(entries[currentPhrase].Key);
            currentText = entry.GetLocalizedString();
            TypeText();
        }
        else
        {
            Hide();
        }

    }


    IEnumerator TypeTextEnum()
    {
        typeTexting = true;
        textMeshPro.text = string.Empty;
        textMeshPro.text = "█";

        for (int i = 0; i <= currentText.Length - 1; i++)
        {
            textMeshPro.text = textMeshPro.text.Insert(i, currentText[i].ToString());
            yield return new WaitForSeconds(1 - textSpeed);
        }

        typeTexting = false;

        LastSignEnumeratorObj = AnimateLastSign();
        NextPhraseEnumeratorObj = NextPhrase();

        StartCoroutine(LastSignEnumeratorObj);
        StartCoroutine(NextPhraseEnumeratorObj);
    }

    IEnumerator NextPhrase()
    {
        yield return new WaitForSeconds(timeForNext);
        GetNextPhrase();
        StopCoroutine(NextPhraseEnumeratorObj);
    }

    IEnumerator AnimateLastSign()
    {
        bool remove = true;
        while (true)
        {
            if (remove)
            {
                textMeshPro.text = textMeshPro.text.Remove(textMeshPro.text.Length - 1);
            }
            else
            {
                textMeshPro.text += "█";
            }

            remove = !remove;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
