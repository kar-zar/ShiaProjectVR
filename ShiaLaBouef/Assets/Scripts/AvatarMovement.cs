using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMovement : MonoBehaviour
{
    public float speed = 2.2f;
    // Start is called before the first frame update
    public GameObject XRorigin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = XRorigin.GetComponent<Scene1MovementScript>().shiaSpeed;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
    }
}
