using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConsoleController : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI console;

    [HideInInspector]
    public bool editingText;

    // Start is called before the first frame update
    void Start()
    {
        inputField.onEndEdit.AddListener(textEditEnd);
        inputField.onSelect.AddListener(textSelect);
    }

    private void textSelect(string text)
    {
        Debug.Log("TextSelect");
        editingText = true;
    }

    private void textEditEnd(string text)
    {
        Debug.Log("edit end");
        editingText = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Return))
        {
            HandleCommand(inputField.text);
            SubmitText(inputField.text);
            inputField.text = "";
            inputField.ActivateInputField();
        }
    }

    private void SubmitText(String text)
    {
        console.SetText(console.text + "\n" + text);
    }

    private void HandleCommand(String text)
    {
        text = text.ToLower();

        char[] separators = new char[] { ' ', '.' };

        List<String> seperatedText = new List<string>();

        foreach (var word in text.Split(separators, StringSplitOptions.RemoveEmptyEntries))
        {
            Debug.Log(word);
            seperatedText.Add(word);
        }

        if (seperatedText[0] == "clear")
        {
            console.SetText("");
        }
       /* else if()
        {

        }*/
    }

}
