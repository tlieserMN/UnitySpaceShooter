using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCommand : AndroidJavaProxy
{
    public TestCommand() : base("Command") { }
    void execute(byte[] data)
    {
        Debug.Log("zzzzzzzzzzzzzzzzzzzzzzzz: " + System.Text.Encoding.Default.GetString(data));
    }
}

public class PlayerMovement : MonoBehaviour
{

    public float rotSpeed = 180f;
    public float maxSpeed = 5f;
    public static float shipBoundaryRadius = 0.5f;

    AndroidJavaObject ajc;

    private Vector2 touchOrigin = -Vector2.one;

    // Start is called before the first frame update
    void Start()
    {
        //AndroidJavaClass ajc = new AndroidJavaClass("BluetoothLinker"); //(1)
        ajc = new AndroidJavaObject("BluetoothLinker");
        string x = ajc.Call<string>("startBluetooth", "HC-05", new TestCommand());
        Debug.Log(x);
        for(int i = 0; i < 40; i++)
        {
            Debug.Log("aaaaaaaaaaaaaaaa_______________HHHHHHHHHHHHHHHHHHHHHHH");
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("rrrrrrrrrrrr: " + ajc.CallStatic<string>("connected"));

        // ROTATE the ship
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        // MOVE the ship
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;

        // RESTRICT ship to boundaries
        if(pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }
        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if(pos.x + shipBoundaryRadius > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundaryRadius;
        }
        if(pos.x - shipBoundaryRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundaryRadius;
        }

        transform.position = pos;
        /*
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        float xRatio = Camera.main.orthographicSize / Screen.height;
        float yRatio = widthOrtho / Screen.width;

        if (Input.touchCount > 0)
        {
            //Store the first touch detected.
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = touch.position;
            if(touchPos.x < Screen.width / 2)
            {
                xRatio *= -1;
            }
            if(touchPos.y < Screen.height / 2)
            {
                yRatio *= -1;
            }
            Vector3 newShipPos = new Vector3(touchPos.x * xRatio, touchPos.y * yRatio, 0);

            transform.position = newShipPos;
            Debug.Log("---------------------- begin");
            Debug.Log("touch x: " + touchPos.x * xRatio + ", touch y: " + touchPos.y * yRatio);
        }
        Debug.Log("end--------------------------");*/
    }
}
