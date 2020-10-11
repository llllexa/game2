using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class fonego1 : MonoBehaviour
{
    public GameObject fone1;
    public GameObject fone3;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (fone1.transform.position.x > 10)
        {
            fone1.transform.position = new Vector3(-15.78f, fone1.transform.position.y, fone1.transform.position.z);
        }
        if (fone3.transform.position.x > 10)
        {
            fone3.transform.position = new Vector3(-15.78f, fone3.transform.position.y, fone3.transform.position.z);
        }
        fone1.transform.Translate(0.02f, 0, 0);
        fone3.transform.Translate(0.02f, 0, 0);
    }
}
