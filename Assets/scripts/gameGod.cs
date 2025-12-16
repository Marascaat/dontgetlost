using UnityEngine;
using System;
using System.Collections.Generic;

public class gameGod : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tt;
    public Camera camera;

    public GameObject b1;
    public GameObject b2;
    public GameObject b3;

    public GameObject spike;

    public int ballQ;

    public int initialDiff = 0;
    public int diff;
    [SerializeField] float diffMultiplier;

    List<Vector2> takenPos = new List<Vector2>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diff = initialDiff;
        ballQ = 0;
        set();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballQ == 3) {
            diff+=1;
            set();
        }
    }
    //reset and generate ball/spike positions
    void set()
    {
        ballQ = 0;
        rb.linearVelocity = new Vector2(0, 0);
        tt.position = new Vector3(0, 0, 0);
        takenPos.Clear();
        takenPos.Add(new Vector2(0f,0f));

        Instantiate(b1, genPos(), Quaternion.identity);

        Instantiate(b2, genPos(), Quaternion.identity);

        Instantiate(b3, genPos(), Quaternion.identity);

        for (int i = 0; i < diffMultiplier*diff; i++) {
            Instantiate(spike, genPos(), Quaternion.identity);
        }
    }

    Vector2 genPos()
    {
        Vector2 pos = camera.ScreenToWorldPoint(new Vector2(UnityEngine.Random.Range(15, Screen.width - 15), UnityEngine.Random.Range(10, Screen.height - 15)));
        while (!verify(pos))
        {
            pos = camera.ScreenToWorldPoint(new Vector2(UnityEngine.Random.Range(15, Screen.width - 15), UnityEngine.Random.Range(10, Screen.height - 15)));
        }
        takenPos.Add(pos);
        return pos;
    }

    bool verify(Vector2 pos)
    {
        for (int i = 0; i < takenPos.Count; i++)
        {
            float dist = Vector2.Distance(pos, takenPos[i]);
            if (dist<2)
            {
                return false;
            }
        }
        return true;
    }
}
