using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Scene1MovementScript : MonoBehaviour
{
    public GameObject Rig;
    public GameObject Phone;
    public float speed = 2.0f;
    public AudioClip scene1Clip;
    public AudioClip scene2Clip;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().loop = false;
        StartCoroutine(playEngineSound());
        Rig = GameObject.FindWithTag("Player");
        Phone = GameObject.FindWithTag("Phone");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    IEnumerator playEngineSound()
    {
        GetComponent<AudioSource>().clip = scene1Clip;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length-1.15f);
        Rig.transform.position = new Vector3(-24.73f, 1, 80);
        GetComponent<AudioSource>().clip = scene2Clip;
        GetComponent<AudioSource>().Play();
        Destroy(Phone);
        speed = 1.25f;
    }
}