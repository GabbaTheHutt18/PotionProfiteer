using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //[SerializeField] int defaultMovementIncriment = 1;
    public Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = currentPos;
    }
}
