using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LightChangeScript : MonoBehaviour
{

    public List<MaterialChanger> Objects;

    public Transform TileOwner;

    void Start()
    {
        foreach (Transform child in TileOwner)
        {
            child.Translate(new Vector3(0, Random.Range(0.0f, 0.5f), 0));
            Objects.Add(child.GetComponent<MaterialChanger>());

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            foreach (MaterialChanger obj in Objects)
            {
                obj.Setting1();
            }
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            foreach (MaterialChanger obj in Objects)
            {
                obj.Setting2();
            }
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            foreach (MaterialChanger obj in Objects)
            {
                obj.Setting3();
            }
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            foreach (MaterialChanger obj in Objects)
            {
                obj.Setting4();
            }
        }

        if (Input.GetKey(KeyCode.Alpha5))
        {
            foreach (MaterialChanger obj in Objects)
            {
                obj.Setting5();
            }
        }
    }
}
