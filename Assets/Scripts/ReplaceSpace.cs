using UnityEngine;


public class ReplaceSpace : MonoBehaviour
{
    PlayerMovement pM;

    void Start()
    {
        GameObject grabPM = GameObject.FindWithTag("Player");
        if (grabPM == null)
        {
            Debug.Log("Cannot grab the script!");
        }
        else
        {
            pM = grabPM.GetComponent<PlayerMovement>();
        }
    }

    public void Name()
    {
        if (pM != null && pM.grabObj != null)
        {
            string name = gameObject.name;
            createTower(name);
        }
    }

    void createTower(string name)
    {
        Vector3 upVec = new Vector3(pM.grabObj.transform.position.x, 2.3f, pM.grabObj.transform.position.z);

        // Check if there's already a tower at the specified position
        Collider[] colliders = Physics.OverlapSphere(upVec, 0.1f); // Adjust the radius as needed

        if (colliders.Length > 0)
        {
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Tower"))
                {
                    // Tower already exists at this position, destroy it
                    Destroy(collider.gameObject);
                }
            }
        }

        // Continue with tower creation
        switch (name)
        {
            case "Tower_1":
                Instantiate(Resources.Load("Prefabs/Towers/Colored Towers/Basic_Tower") as GameObject, upVec, Quaternion.identity);
                break;
            case "Tower_2":
                Instantiate(Resources.Load("Prefabs/Towers/Colored Towers/Ice_Tower") as GameObject, upVec, Quaternion.identity);
                break;
            case "Tower_3":
                Instantiate(Resources.Load("Prefabs/Towers/Colored Towers/Plant_Tower") as GameObject, upVec, Quaternion.identity);
                break;
        }
    }
}
