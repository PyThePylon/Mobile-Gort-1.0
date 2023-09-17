using UnityEngine;


public class ReplaceSpace : MonoBehaviour
{

    PlayerMovement pM;


    void Start()
    {
        GameObject grabPM = GameObject.FindWithTag("Player");
        if(grabPM == null)
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
        string name = gameObject.name;

        createTower(name);
    }

    void createTower(string name)
    {
        switch(name)
        {
            case "Tower_1":
                GameObject t_1 = Resources.Load("Prefabs/Towers/Basic_Tower") as GameObject;
                t_1 = Instantiate(t_1, pM.grabObj.transform.position, Quaternion.identity);

                break;
            case "Tower_2":
                GameObject t_2 = Resources.Load("Prefabs/Towers/Ice_Tower") as GameObject;
                t_2 = Instantiate(t_2, pM.grabObj.transform.position, Quaternion.identity);

                break;
            case "Tower_3":
                GameObject t_3 = Resources.Load("Prefabs/Towers/Plant_Tower") as GameObject;
                t_3 = Instantiate(t_3, pM.grabObj.transform.position, Quaternion.identity);

                break;
        }
    }
}
