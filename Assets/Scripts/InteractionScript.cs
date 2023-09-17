using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionScript : MonoBehaviour
{
    [Header("Towers")]
    public GameObject pressE;
    public GameObject towers;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("EUGH");
            pressE.SetActive(true);
            towers.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("E");
            pressE.SetActive(false);
            towers.SetActive(false);
        }
    }

}
