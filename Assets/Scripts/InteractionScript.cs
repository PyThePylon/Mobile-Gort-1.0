using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    [Header("Towers")]
    public GameObject towers;
    public GameObject visualCube;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //pressE.SetActive(true);
            towers.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //pressE.SetActive(false);
            towers.SetActive(false);
        }
    }

}
