using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{

    public Renderer render;

    public Material mat1;
    public Material matToon;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Setting1()
    {
        render.material.SetFloat("_UseAmbiant", 0.0f);

        render.material.SetFloat("_UseSpecular", 0.0f);

        render.material = mat1;
    }

    public void Setting2()
    {
        render.material.SetFloat("_UseAmbiant", 1.0f);

        render.material.SetFloat("_UseSpecular", 0.0f);
    }

    public void Setting3()
    {
        render.material.SetFloat("_UseAmbiant", 0.0f);

        render.material.SetFloat("_UseSpecular", 1.0f);
    }


    public void Setting4()
    {
        render.material.SetFloat("_UseAmbiant", 1.0f);

        render.material.SetFloat("_UseSpecular", 1.0f);
    }


    public void Setting5()
    {
        render.material.SetFloat("_UseAmbiant", 0.0f);

        render.material.SetFloat("_UseSpecular", 0.0f);

        render.material = matToon;
    }

}
