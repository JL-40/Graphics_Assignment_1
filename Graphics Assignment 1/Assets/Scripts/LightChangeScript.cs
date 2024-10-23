using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LightChangeScript : MonoBehaviour
{

    public List<Renderer> Objects;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            foreach (Renderer obj in Objects)
            {
                obj.material.SetFloat("_UseAmbiant", 0.0f);
                obj.material.SetFloat("_UseSpecular", 0.0f);
            }
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            foreach (Renderer obj in Objects)
            {
                obj.material.SetFloat("_UseAmbiant", 1.0f);
                obj.material.SetFloat("_UseSpecular", 0.0f);
            }
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log("3");
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            foreach (Renderer obj in Objects)
            {
                obj.material.SetFloat("_UseAmbiant", 1.0f);
                obj.material.SetFloat("_UseSpecular", 1.0f);
            }
        }

        if (Input.GetKey(KeyCode.Alpha5))
        {
            foreach (Renderer obj in Objects)
            {
                obj.material.SetFloat("_UseAmbiant", 1.0f);
                obj.material.SetFloat("_UseSpecular", 1.0f);
                obj.material.SetFloat("_Shininess", 0);
            }
        }
    }
}
