using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FacingCamera : MonoBehaviour
{
    private Transform[] children;
    // Start is called before the first frame update
    void Start()
    {
        children = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i].rotation = Camera.main.transform.rotation;
        }
    }
}
