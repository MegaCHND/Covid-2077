using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMyself : MonoBehaviour
{
    public GameObject killswitch;

    private void Update()
    {
        if (killswitch.GetComponent<gameObjectCheckTest>().dewit) {
            Destroy(gameObject);
        }
    }
}
