using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Renderer m_Renderer;
    private Matrix4x4 m_LocalMatrix;
    private float moveForward = 0;
    private float moveLeft = 0;
    private float rotate = 0;
    private float time = 0.6f;

    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            moveForward = 1;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            moveForward = -1;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            rotate = -1;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            rotate = 1;
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            moveForward = 0;
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            rotate = 0;
        
        this.transform.RotateAround(Vector3.up, 1f * Time.deltaTime * rotate);
        
        this.transform.Translate(new Vector3(0, 0, Time.deltaTime * 50.0f * moveForward));
        if (moveForward != 0 || rotate != 0)
        {
            time += Time.deltaTime;
        }

        if (time > 0.2f)
        {
            time = 0;
            OceanVisulizer.Instance.SphereTest(this.gameObject);
        }
    }
}
