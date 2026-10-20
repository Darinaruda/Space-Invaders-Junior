using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Viteza de deplasare stanga-dreapta
    public float speed = 2f;

    // Cat de mult coboara inamicul cand ajunge la marginea ecranului
    public float moveDownDistance = 0.5f;

    // Marginile ecranului (pot fi ajustate din Inspector)
    public float leftEdge = -8f;
    public float rightEdge = 8f;

    // Directia curenta de miscare
    private bool movingRight = true;

    // Numarul de lovituri pe care inamicul le poate primi inainte sa fie distrus
    public int hitPoints = 3;

    // Distanta minima dintre proiectil si inamic pentru a considera o lovitura
    public float hitDistance = 0.5f;

    // Update este apelat o data pe frame
    void Update()
    {
        Move();
        CheckForHits();
    }

    // Gestioneaza miscarea inamicului (stanga-dreapta, coboara la margine)
    void Move()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            // Daca a ajuns la marginea dreapta, coboara si schimba directia
            if (transform.position.x >= rightEdge)
                MoveDownAndReverse();
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            // Daca a ajuns la marginea stanga, coboara si schimba directia
            if (transform.position.x <= leftEdge)
                MoveDownAndReverse();
        }
    }

    // Coboara inamicul si inverseaza directia de miscare
    void MoveDownAndReverse()
    {
        movingRight = !movingRight;

        Vector3 newPos = transform.position;
        newPos.y -= moveDownDistance;
        transform.position = newPos;
    }

    // Verifica daca vreun proiectil este suficient de aproape pentru a fi considerat o lovitura
    void CheckForHits()
    {
        // Gasim toate proiectilele active din scena
        ProjectileBehaviour[] projectiles = FindObjectsOfType<ProjectileBehaviour>();

        foreach (ProjectileBehaviour projectile in projectiles)
        {
            float distance = Vector3.Distance(this.transform.position, projectile.transform.position);

            // Daca proiectilul este mai aproape decat hitDistance, este o lovitura
            if (distance < hitDistance)
            {
                hitPoints--;

                // Distrugem proiectilul care a lovit
                Destroy(projectile.gameObject);

                // Daca inamicul nu mai are HP, il distrugem si pe el
                if (hitPoints <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
