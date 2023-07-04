using UnityEngine;

public class ZoneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay " + other.gameObject.name);
    }
}
