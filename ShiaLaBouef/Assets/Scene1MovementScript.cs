using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1MovementScript : MonoBehaviour
{
    public GameObject Rig;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Rig = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
