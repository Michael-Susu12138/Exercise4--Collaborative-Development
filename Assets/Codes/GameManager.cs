using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public int score = 0;
    //public TextMeshProUGUI scoreUI;

    private void Awake() {
        // Don't Destroy on Load
        if(GameObject.FindObjectsOfType<GameManager>().Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //scoreUI.text = "SCORE: " + score;
    }

    public void AddScore(int points) 
    {
        //score += points;
        //GameObject.FindGameObjectWithTag("score").GetComponent<TextMeshProUGUI>().text = "SCORE: " + score;
    }
    // Update is called once per frame
    void Update()
    {
#if !UNITY_WEBGL
        // Esc to Exit
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif
    }
}