using UnityEngine;

public class DeleteSelf : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) {
            Application.Quit();
        }
    }
}
