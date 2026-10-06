using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Pentru a detecta marginea ecranului, folosesc doi pivoti, pivotLeft si pivotRight si calculez distanta dintre ei si player
    public GameObject pivotLeft, pivotRight,projectile;
    // playerSpeed = viteza jucatorului; timer = la ce interval de timp instantiez un nou proiectil
    public float playerSpeed,timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        // Am vrut sa fac o functie separata pentru proiectile, deoarece as vrea sa implementam mai multe diferite abilitati cu aceste proiectile
        ShootProjectiles();
        this.transform.Translate(Vector3.right * playerSpeed * Input.GetAxis("Horizontal") * Time.deltaTime); // miscarea efectiva a jucatorului
        // daca distanta dintre oricare pivot cu jucatorul este mai mica decat o distanta arbitrara jucatorul nu se mai poate misca
        if (Vector3.Distance(this.transform.position, pivotLeft.transform.position) < 1f || Vector3.Distance(this.transform.position, pivotRight.transform.position) < 1f)
        {
            playerSpeed = 0f;
            // daca jucatorul este la pivotul stang si are intentia de a se misca la dreapta se reia miscarea
            if(Vector3.Distance(this.transform.position, pivotLeft.transform.position) < 1f && Input.GetAxis("Horizontal") > 0f)
                playerSpeed = 10f;
            // la fel ca mai sus, dar pentru pivotul drept
            if (Vector3.Distance(this.transform.position, pivotRight.transform.position) < 1f && Input.GetAxis("Horizontal") < 0f)
                playerSpeed = 10f;
        }

    }

    private void ShootProjectiles()
    { 
        // la un interval de 5 sec se instantieaza un proiectil nou
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(projectile,this.transform.position + Vector3.up,this.transform.rotation);
            timer = 2f;
        }

    }
}
