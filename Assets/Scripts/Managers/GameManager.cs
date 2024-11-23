using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] Text pauseText;
    [SerializeField] int score = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Quit();

        Unpause();

        if (score == 4)
            Win();
    }

    public void Score()
    {
        score++;
    }

    public void Win()
    {
        if (pauseText.gameObject.activeSelf == false)
        {
            pauseText.gameObject.SetActive(true);
        }

        EndGame();
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        Debug.Log($"Press 'Escape' to Quit.");
    }

    // Exit play
    public void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }

    public void Unpause()
    {
        if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            score *= -1; // inverse score to unpause.

            if (pauseText.gameObject.activeSelf == false)
            {
                pauseText.gameObject.SetActive(true);
            }
        }
    }
}
