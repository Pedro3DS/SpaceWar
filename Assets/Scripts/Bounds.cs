using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class Bounds : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    //void Start()
    //{
    //    // Get the main camera's screen bounds
    //    screenBounds = UnityEngine.Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Screen.width, UnityEngine.Screen.height, UnityEngine.Camera.main.transform.position.z));

    //    // Get the object's width and height in world units
    //    objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    //    objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    //}

    private void Update()
    {
        // Get the main camera's screen bounds
        screenBounds = UnityEngine.Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Screen.width, UnityEngine.Screen.height, UnityEngine.Camera.main.transform.position.z));

        // Get the object's width and height in world units
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void LateUpdate()
    {
        // Get the current position of the object
        Vector3 viewPos = transform.position;

        // Ensure the object stays within the horizontal bounds
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);

        // Ensure the object stays within the vertical bounds
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);

        // Update the object's position
        transform.position = viewPos;
    }
}
