using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConsoleController : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI console;
    public List<string> probeableSites;
    public List<string> solveablePorts;
    public List<string> readableFiles;

    private int openedPortNumber = 0;

    private bool has3puzzlesSolved;
    [HideInInspector]
    public bool hasEncryptionKey;

    [HideInInspector]
    public bool editingText;

    public static ConsoleController Instance;

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        inputField.onEndEdit.AddListener(textEditEnd);
        inputField.onSelect.AddListener(textSelect);
        inputField.onValueChanged.AddListener(textChanged);
    }

    private void textChanged(string arg0)
    {
        AudioController.Instance.PlayKeyboardSound();
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
        AudioController.Instance.StopKeyboardSound();

    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Return))
        {
            SubmitText(inputField.text);
            HandleCommand(inputField.text);
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
        else if (seperatedText[0] == "help")
        {
            SubmitText(   "HELP         Provides Help information for OS commands." +
                        "\nCLEAR        Clears the screen." +
                        "\nCAT          Used for viewing files. [e.g.: cat dosya.txt]" +
                        "\nPROBE        Scan the target machine for vulnerabilities. [e.g.: probe lavatit.com]" +
                        "\nSOLVE        Attemps to solve the firewall of the target machine to allow UDP Traffic. [e.g.: solve 80]");
                        
        }
        else if(seperatedText[0] == "probe")
        {
            if(seperatedText[1] == null || probeableSites.Contains(seperatedText[1]))
            {
                    StartCoroutine(ProbeLavatit());
            }
            else
            {
                SubmitText("Please enter a valid site.");
            }
        }
        else if (seperatedText[0] == "solve")
        {
            if (seperatedText[1] == null || solveablePorts.Contains(seperatedText[1]))
            {
                if (seperatedText[1] == "80")
                {
                    LaserGameLevelController.Instance.ActivateLevel(0);

                }
                else if (seperatedText[1] == "25")
                {
                    LaserGameLevelController.Instance.ActivateLevel(1);

                }
                else if (seperatedText[1] == "21")
                {
                    LaserGameLevelController.Instance.ActivateLevel(2);

                }
                else if (seperatedText[1] == "22")
                {
                    LaserGameLevelController.Instance.ActivateLevel(3);

                }
            }
            else
            {
                SubmitText("Please enter a valid port to solve.");
            }
        }
        else if (seperatedText[0] == "cat")
        {
            if (seperatedText[1] == null ||  readableFiles.Contains(seperatedText[1]))
            {
                    if(has3puzzlesSolved)
                    {
                        StartCoroutine(ReadFile());
                    }
            }
            else
            {
                SubmitText("Please enter a valid file to read.");
            }
        }
        else if (seperatedText[0] == "rm")
        {
            
                if (seperatedText[1] == null || seperatedText[1] == "mail_07683169")
                {
                  // good ending
                }
                else
                {
                    SubmitText("Please enter a valid file to read.");
                }
        }
        else
        {
            SubmitText("Unknown command. Please use 'Help' to see available commands.");
        }
    }

    IEnumerator ReadFile()
    {
        SubmitText("Reading file...");

        yield return new WaitForSeconds(0.8f);
        hasEncryptionKey = true;
        SubmitText("\nHi."+

                        "\nI don't know you, and I'm sad to say that I never will, but if you're reading this it means you might be the only person that can make things right."+

                        "\nRight now I'm trapped. There's no way out, and not enough time, and I need your help."+

                        "\nIf you believe in humanity even a little, do not send this mail to anyone."+

                        "\nYou can simply delete it by typing 'rm mail_07683169' in your terminal."+

                        "\nENCRYPTION_KEY == 4f535552554b");


        yield break;
    }

    IEnumerator ProbeLavatit()
    {
        SubmitText("Started probing lavatit.com...");
        yield return new WaitForSeconds(1.5f);

        SubmitText("\nProbe Complete - Open ports:" +
                    "\n-------------------------------"+
                    "\nPort#: 80 - HTTP WebServer"+
                    "\nPort#: 25 - SMTP MailServer"+
                    "\nPort#: 21 - FTP Server"+
                    "\nPort#: 22 - SSH"+
                    "\n-------------------------------"+
                    "\nOpen Ports Required for Crack : 3"+
                    "\nProxy Detected : DEACTIVE");


        yield break;
    }

    public void OpenPort(int portNumber)
    {
        if(portNumber == 80)
        {
            StartCoroutine(Port80Opened());
        }
        else if(portNumber == 25)
        {
            StartCoroutine(Port25Opened());
        }
        else if (portNumber == 21)
        {
            StartCoroutine(Port21Opened());
        }
        else if (portNumber == 22)
        {
            StartCoroutine(Port22Opened());
        }
    }

    public IEnumerator Port80Opened()
    {
        SubmitText("\nSOLVE SUCCESSFUL - Syndicated HTTP Traffic Enabled");
        openedPortNumber++;

        if(openedPortNumber >=3)
        {
            StartCoroutine(DownloadFile());
        }

        yield break;
    }

    public IEnumerator Port25Opened()
    {
        SubmitText("\nSOLVE SUCCESSFUL - Syndicated SMTP Traffic Enabled");
        openedPortNumber++;

        if (openedPortNumber >= 3)
        {
            StartCoroutine(DownloadFile());
        }
        yield break;
    }


    public IEnumerator Port21Opened()
    {
        SubmitText("\nSOLVE SUCCESSFUL - Syndicated FTP Traffic Enabled");
        openedPortNumber++;

        if (openedPortNumber >= 3)
        {
            StartCoroutine(DownloadFile());
        }
        yield break;
    }

    public IEnumerator Port22Opened()
    {
        SubmitText("\nSOLVE SUCCESSFUL - Remote Access Syndicated");
        openedPortNumber++;

        if (openedPortNumber >= 3)
        {
            StartCoroutine(DownloadFile());
        }
        yield break;
    }

    public IEnumerator DownloadFile()
    {
        yield return new WaitForSeconds(0.5f);
        SubmitText("\nYou've successfully penetrated all ports and now downloading file 'mail_07683169'");
        yield return new WaitForSeconds(2f);
        has3puzzlesSolved = true;
        SubmitText("\n'mail_07683169' has been downloaded. You can read the file.");

        yield break;
    }

}
