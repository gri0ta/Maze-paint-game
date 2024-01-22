using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;


public class GameManager : MonoBehaviour
{
    public List<string> levels;

    public static GameManager instance;

    public int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        
            Application.targetFrameRate = 60;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }


    public void LoadNextLevel()
    {
        ++currentLevel;
        SceneManager.LoadScene(levels[currentLevel]);
    }
}
