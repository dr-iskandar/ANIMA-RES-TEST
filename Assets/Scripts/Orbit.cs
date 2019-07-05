using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float xSpread;
    public float zSpread;
    public float yOffset;
    public Transform centerPoint;

    public float rotSpeed;
    public bool rotateClockwise;

    float timer = 0;
    float spead;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * rotSpeed;
        //Rotate();
        spead -= Time.deltaTime * 0.5f;
        if (spead>=0)
        {
            SetAlpha(gameObject.GetComponent<Renderer>().material, spead);
        }

    }

    void Rotate()
    {
        if (rotateClockwise)
        {
            float x = -Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centerPoint.position;

        }
        else
        {
            float x = Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            transform.position = pos + centerPoint.position;
        }
    }

    public void SetAlpha(Material material, float value)
    {
        Color color = material.color;
        color.a = value;
        material.color = color;
    }
}
