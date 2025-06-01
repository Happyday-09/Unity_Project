using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Vector3 spawnPos = new Vector3(10f, Random.Range(-3f, 3f), 0f);
            Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
            timer = 0f;
        }
    }
}