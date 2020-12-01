using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public int InteractibleID;
    public bool InteractedWith;

    private Vector3 basePosition;

    public void Initialize(int _InteractibleID, bool _InteractedWith) {
        InteractibleID = _InteractibleID;
        InteractedWith = _InteractedWith;
        basePosition = transform.position;

    }

    public void InteractibleTouched() {
        InteractedWith = true;
    }

    public void InteractableUntouched() {
        InteractedWith = false;
    }
}
