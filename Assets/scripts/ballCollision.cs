using UnityEngine;

public class ballCollision : MonoBehaviour
{
    public gameGod gg;
    public AudioClip pop;
    public AudioSource src;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Makes sure that the balls have to be hit in numerical order
        if (other.gameObject.CompareTag("b1"))
        {
            if(gg.ballQ == 0)
            {
                Destroy(other.gameObject);
                gg.ballQ += 1;
                src.PlayOneShot(pop, 0.8f);
            }
        }
        if (other.gameObject.CompareTag("b2"))
        {
            if (gg.ballQ == 1)
            {
                Destroy(other.gameObject);
                gg.ballQ += 1;
                src.PlayOneShot(pop, 0.8f);
            }
        }
        if (other.gameObject.CompareTag("b3"))
        {
            if (gg.ballQ == 2)
            {
                Destroy(other.gameObject);
                gg.ballQ += 1;
                src.PlayOneShot(pop, 0.8f);
            }
        }
    }
}
