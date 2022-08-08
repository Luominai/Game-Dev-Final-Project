using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    public GameObject player;
    private float cameraX;
    private float cameraY;
    private float halfHeight;
    private float halfWidth;
    void Start()
    {
        halfHeight = camera.orthographicSize;
        halfWidth = halfHeight * camera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        cameraX = player.GetComponent<Transform>().position.x;
        cameraY = player.GetComponent<Transform>().position.y;

        cameraX = Mathf.Clamp(cameraX, minX + halfWidth, maxX - halfWidth);
        cameraY = Mathf.Clamp(cameraY, minY + halfHeight, maxY - halfHeight);

        camera.GetComponent<Transform>().position = new Vector3(cameraX, cameraY, -10);
    }
}
