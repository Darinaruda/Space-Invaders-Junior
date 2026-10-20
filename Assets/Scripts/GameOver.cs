using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Referinta catre panoul de Game Over din UI (setat in Inspector)
    public GameObject gameOverPanel;

    // Daca un inamic coboara sub aceasta pozitie pe Y, jocul se termina
    public float gameOverYThreshold = -4f;

    // Variabila interna ca sa nu verificam in continuu dupa ce jocul s-a terminat
    private bool isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ne asiguram ca panoul de Game Over este ascuns la inceput
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Daca jocul s-a terminat deja, nu mai facem nimic
        if (isGameOver) return;

        // Gasim toti inamicii activi din scena
        EnemyBehaviour[] enemies = FindObjectsOfType<EnemyBehaviour>();

        foreach (EnemyBehaviour enemy in enemies)
        {
            // Daca orice inamic a coborat prea mult, declansam Game Over
            if (enemy.transform.position.y <= gameOverYThreshold)
            {
                TriggerGameOver();
                return;
            }
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true;

        // Afisam panoul de Game Over
        gameOverPanel.SetActive(true);

        // Oprim jocul (viteza timpului = 0)
        Time.timeScale = 0f;
    }

    // Aceasta functie este apelata de butonul de Restart din UI
    public void Restart()
    {
        // Resetam viteza timpului inainte de a reincarca scena
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
