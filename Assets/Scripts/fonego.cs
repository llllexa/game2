using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class fonego : MonoBehaviour
{
    public GameObject fone;
    public GameObject fone2;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (fone.transform.position.y > 900)
        {
            fone.transform.position = new Vector3(fone.transform.position.x, -1071, fone.transform.position.z);
        }
        if (fone2.transform.position.y > 900)
        {
            fone2.transform.position = new Vector3(fone2.transform.position.x, -1071, fone2.transform.position.z);
        }
        fone.transform.Translate(0,1.5f,0);
        fone2.transform.Translate(0,1.5f,0);
    }
}
