using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1AudioMovement : MonoBehaviour
{
    public GameObject audioSphere;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSphere = GameObject.FindWithTag("Scene1Audio");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
