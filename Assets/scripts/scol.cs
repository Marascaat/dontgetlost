using UnityEngine;
using UnityEngine.SceneManagement;

public class scol : MonoBehaviour
{
    public gameGod gg;
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
        if (other.gameObject.CompareTag("spike"))
        {
            if (gg.diff > PlayerPrefs.GetInt("Highscore", 0))
            {
                PlayerPrefs.SetInt("Highscore",gg.diff);
            }
            SceneManager.LoadScene(sceneName: "overgame");
        }
    }
}
