using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // DESTROY if outside camera
        Vector3 pos = transform.position;

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.y > Camera.main.orthographicSize || pos.y < -Camera.main.orthographicSize || pos.x > widthOrtho || pos.x < -widthOrtho)
        {
            Destroy(gameObject);
        }
    }
}
