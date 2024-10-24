using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LightChangeScript : MonoBehaviour
{

    public List<MaterialChanger> Objects;

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
