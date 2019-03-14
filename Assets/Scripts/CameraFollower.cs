using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public Transform myTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myTarget != null)
        {
            Vector3 targPosition = myTarget.position;
            targPosition.z = transform.position.z;
            transform.position = targPosition;
        }
    }
}
