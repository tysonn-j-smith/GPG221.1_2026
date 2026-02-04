using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject objToSpawn;
    [SerializeField] private int amountToSpawn = 6;
    [SerializeField] private float xBounds = 10f;
    [SerializeField] private float zBounds = 10f;

    private void Start()
    {
        for(int i = 0; i < amountToSpawn; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-xBounds, xBounds), 0f, Random.Range(-zBounds, zBounds));
            Instantiate(objToSpawn, spawnPos, Quaternion.identity);
        }
    }
}
