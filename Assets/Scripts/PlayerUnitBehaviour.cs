using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerUnitBehaviour : MonoBehaviour
{
    public NavMeshAgent m_Agent;
    RaycastHit m_HitInfo = new RaycastHit();
    public Animator anim;


    public bool dangerous = false;
    public float dangerousTimer = 0.0f;

    public int score = 0;

    public Renderer mat;

    [SerializeField] Text pauseText;

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        
        Debug.Log("Test");

        pauseText.gameObject.SetActive(false);
    }




    void Update()
    {
        Quit();

        PickTarget();

        DangerousTick();

        if (score == 4)
            Win();

        Unpause();
    }

    void PickTarget()
    {
        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                m_Agent.destination = m_HitInfo.point;
        }
    }

    void DangerousTick()
    {
        if (dangerous)
        {
            dangerousTimer -= Time.deltaTime;
            if (dangerousTimer < 0.0f)
            {
                dangerous = false;
                anim.SetTrigger("EndDanger");
                mat.material.SetFloat("_RimPower", 8.0f);
            }
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
        EndGame();
    }

    public void Win()
    {
        if (pauseText.gameObject.activeSelf == false)
        {
            pauseText.gameObject.SetActive(true);
        }

        EndGame();
    }

    void EndGame()
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
        }
    }
}
