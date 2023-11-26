using UnityEngine;

public class Juggernaut_Healing : MonoBehaviour
{
    public GameObject healingCirclePrefab;
    public GameObject healingAuraPrefab;
    public float healingRadius = 8f;
    public float healingAmount = 10f;
    public float healingInterval = 10f; // Time between healing events in seconds
    public AudioClip healCircleAudio;
    public AudioClip healingAuraAudio;

    private GameObject healingCircle;
    private float nextHealTime;
    private AudioSource audioSource;

    void Start()
    {
        SpawnHealingCircle();
        nextHealTime = Time.time + healingInterval; // Set initial time for healing

        // Add an AudioSource component to the GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.time >= nextHealTime)
        {
            HealNearbyEnemies();
            nextHealTime = Time.time + healingInterval; // Set next time for healing
        }
    }

    void SpawnHealingCircle()
    {
        healingCircle = Instantiate(healingCirclePrefab, transform.position, Quaternion.identity);
        healingCircle.transform.SetParent(transform);
        healingCircle.transform.localPosition = Vector3.zero;
        healingCircle.SetActive(false);
    }

    void HealNearbyEnemies()
    {
        healingCircle.SetActive(true);

        if (healingCircle.activeSelf)
        {
            audioSource.PlayOneShot(healCircleAudio);
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, healingRadius);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("EnemyGort"))
                {
                    HealEnemy(hitCollider.gameObject);
                }
            }
        }
    }

    void HealEnemy(GameObject enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            if (enemyHealth.enemyHP < enemyHealth.maxHP)
            {
                enemyHealth.enemyHP += healingAmount;
                enemyHealth.enemyHP = Mathf.Min(enemyHealth.enemyHP, enemyHealth.maxHP);

                // Play the healing aura audio when an enemy gets healed
                if (audioSource != null && healingAuraAudio != null)
                {
                    audioSource.PlayOneShot(healingAuraAudio);
                }

                GameObject healingAura = Instantiate(healingAuraPrefab, enemy.transform.position, Quaternion.identity);
                Destroy(healingAura, 3f);
            }
        }
    }
}
