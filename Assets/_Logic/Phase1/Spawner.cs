using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject objToSpawn;
    [SerializeField] private int amountToSpawn = 6;

    private void Start()
    {
        for(int i = 0; i < amountToSpawn; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-25f, 25f), 0f, Random.Range(-25f, 25f));
            Instantiate(objToSpawn, spawnPos, Quaternion.identity);
        }
    }
}
