using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public int InteractibleID;
    public int InteractibleType;
    public bool InteractedWith;

    private Vector3 basePosition;

    public void Initialize(int _InteractibleID, bool _InteractedWith) {
        InteractibleID = _InteractibleID;
        InteractedWith = _InteractedWith;
        basePosition = transform.position;
        InteractibleType = 0;
    }

    public void InteractibleTouched() {
        InteractedWith = true;
    }

    public void InteractibleTouchedOnce(int type) {
        InteractedWith = true;
        InteractibleType = type;
    }

    public void InteractableUntouched() {
        InteractedWith = false;
    }
}
