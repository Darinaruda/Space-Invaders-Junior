using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float projectileSpeed;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectileSpeed = 5f;   
    }

    // Update is called once per frame
    void Update()
    {
        //miscarea efectiva a proiectilului, momentan se misca doar pe verticala
        this.transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);
        // momentan distrug proiectoilul daca se indeparteaza prea mult de jucator, posibil sa il schimb ulterior
        // daca nu distrug proiectilul, am scurgeri de memorie
        if (Vector3.Distance(player.transform.position, this.transform.position) > 10f)
        {
            Destroy(this.gameObject);
        
        }
    }
}
