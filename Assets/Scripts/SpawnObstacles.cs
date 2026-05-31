using System.Collections;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour 
{
    public GameObject Obstacle;

    void Start()
    {
        Obstacle = GameObject.Find("Obstacle");
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            CloneAndMoveRandomly();
        }
    }

    void CloneAndMoveRandomly()
    {
        if (Obstacle == null) return; 

        // 1. Pick random Left/Right (X) and Up/Down (Y) coordinates
        float randomX = Random.Range(-7f, 7f);
        float randomY = Random.Range(-4f, 4f); 
        
        // 2. FORCE Z to 0 so it stays perfectly aligned with your 2D camera
        Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

        GameObject clonedObject = Instantiate(Obstacle, randomPosition, Quaternion.identity);
    }
}
