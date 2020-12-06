using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjectiveTracker : MonoBehaviour
{
    public int totalComps;
    public int totalVents;
    public int totalVaccine;
    public Text _text;
    public GameObject winScreen;
    public GameObject uiScreen;

    // Start is called before the first frame update
    void Start()
    {
        _text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int CompsHacked = 0;
        int VentsUnlocked = 0;
        int VaccineGrabbed= 0;
        foreach (KeyValuePair<int , Interactable> entry in GameManager.Interactables) {
            if (GameManager.Interactables[entry.Key].InteractibleType == 1)
            {
                CompsHacked++;
            }
            else if (GameManager.Interactables[entry.Key].InteractibleType == 2) {
                VentsUnlocked++;
            }
            else if (GameManager.Interactables[entry.Key].InteractibleType == 3) {
                VaccineGrabbed++;
            }
        }
        if (CompsHacked < totalComps && VentsUnlocked < totalVents)
        {
            _text.text = ("Objectives\n" + "Computers Hacked " + CompsHacked + "/" + totalComps + "\nVents unlocked " + VentsUnlocked + "/" + totalVents);
        }
        else if (VaccineGrabbed < totalVaccine)
        {
            _text.text = ("Objectives\n" + "Vaccine Grabbed " + VaccineGrabbed + "/ " + totalVaccine);
        }
        else {
            winScreen.SetActive(true);
            uiScreen.SetActive(false);
        }
    }
}
