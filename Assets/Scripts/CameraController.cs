using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float zoomSpeed = 1.0f; // Adjust this to control the speed of zooming
    public float minZoom = 1f; // Minimum orthographic size
    public float maxZoom = 10f; // Maximum orthographic size

    [SerializeField]
    private Camera cam;

    private Vector3 dragOrigin;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position += difference;
        }

        // Zoom in with the scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        ZoomCamera(scroll * zoomSpeed);
    }

    void ZoomCamera(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, minZoom, maxZoom);
    }
}
