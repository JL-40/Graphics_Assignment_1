using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PlayerUnitBehaviour : MonoBehaviour
{
    public NavMeshAgent m_Agent;
    RaycastHit m_HitInfo = new RaycastHit();
    public Animator anim;


    public bool dangerous = false;
    public float dangerousTimer = 0.0f;

    public int score = 0;

    public Renderer mat;

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        
        Debug.Log("Test");
    }


    void Update()
    {
        PickTarget();

        DangerousTick();
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
        GameManager.Instance.EndGame();
    }
}
