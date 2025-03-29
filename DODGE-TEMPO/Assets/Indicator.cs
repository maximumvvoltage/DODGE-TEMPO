using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public GameObject ballPrefab;

    public void Throw()
    {
        var b = Instantiate(ballPrefab);
        b.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }
}
