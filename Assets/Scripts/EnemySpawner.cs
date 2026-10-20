using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Prefab-ul inamicului care va fi instantiat (setat in Inspector)
    public GameObject enemyPrefab;

    // Numarul de randuri si coloane ale grilei de inamici
    public int rows = 3;
    public int columns = 8;

    // Distanta dintre inamici pe orizontala si verticala
    public float horizontalSpacing = 1.5f;
    public float verticalSpacing = 1.2f;

    // Pozitia de start a grilei (coltul din stanga-sus)
    public Vector3 startPosition = new Vector3(-5f, 3f, 0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Calculam pozitia fiecarui inamic in grila
                Vector3 spawnPosition = new Vector3(
                    startPosition.x + col * horizontalSpacing,
                    startPosition.y - row * verticalSpacing,
                    0f
                );

                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
