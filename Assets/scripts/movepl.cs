using UnityEngine;

public class movepl : MonoBehaviour
{
    public AudioClip pew;
    public AudioSource src;
    public Transform plt;
    public float force;
    public Rigidbody2D rb;
    public Camera camera;
    Vector2 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            src.PlayOneShot(pew, 0.5f);
            Shoot();
        }
        checkBounds();
    }
    void FixedUpdate()
    {
        //orient the player with mouse
        Vector2 lookDir = mousePos - rb.position;
        float angle  = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg+180;
        rb.rotation = angle;
    }

    void Shoot()
    {
        rb.AddForce(plt.right * force, ForceMode2D.Impulse);
    }
    //ensure the player stays inside the screen
    void checkBounds()
    {
        if (camera.WorldToScreenPoint(plt.position).x>Screen.width)
        {
            if (rb.linearVelocity.x>0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x*-1, rb.linearVelocity.y);
            }
        }
        if (camera.WorldToScreenPoint(plt.position).x <0)
        {
            if (rb.linearVelocity.x < 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x * -1, rb.linearVelocity.y);
            }
        }

        if (camera.WorldToScreenPoint(plt.position).y > Screen.height)
        {
            if (rb.linearVelocity.y > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * -1);
            }
        }
        if (camera.WorldToScreenPoint(plt.position).y < 0)
        {
            if (rb.linearVelocity.y < 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * -1);
            }
        }
    }
}
