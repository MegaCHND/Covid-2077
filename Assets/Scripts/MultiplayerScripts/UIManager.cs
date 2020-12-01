using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startMenu;
    public InputField usernameField;
    public InputField ServerIPField;
    public GameObject ServerIPFieldTxt;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    /// <summary>Attempts to connect to the server.</summary>
    public void ConnectToServer()
    {
        Client.instance.changeIP(ServerIPFieldTxt.GetComponent<Text>().text);
        startMenu.SetActive(false);
        usernameField.interactable = false;
        ServerIPField.interactable = false;
        Client.instance.ConnectToServer();
    }
}
