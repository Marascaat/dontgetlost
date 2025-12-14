using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class hiscore : MonoBehaviour
{
    public Text txt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "High Score: "+PlayerPrefs.GetInt("Highscore",0).ToString();


        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(sceneName: "SampleScene");
        }
    }
}
