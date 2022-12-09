using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Scene1MovementScript : MonoBehaviour
{
    public GameObject Rig;
    public GameObject Phone;
    public GameObject Shia;
    public GameObject Knife;
    public GameObject BearTrap;
    public float speed = 2.0f;
    public float shiaSpeed = 2.05f;
    public int scene = 1;
    public AudioClip scene1Clip;
    public AudioClip scene2Clip;
    public AudioClip scene3Clip;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().loop = false;
        StartCoroutine(playEngineSound());
        Rig = GameObject.FindWithTag("Player");
        Phone = GameObject.FindWithTag("Phone");
       // Shia = GameObject.FindWithTag("Shia");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if(scene == 1)
        {
            shiaSpeed = shiaSpeed + 0.00013f;
        }
        if(scene == 2)
        {
            if(Shia.transform.position.z > 145.5f)
            {
                shiaSpeed = 0.00f;
            }
        }
        if(scene == 3)
        {
            if(Rig.transform.position.z < 97.0)
            {
                speed = 0.0f;
                BearTrap.SetActive(true);
            }
        }
       
    }

    IEnumerator playEngineSound()
    {
        GetComponent<AudioSource>().clip = scene1Clip;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length-1.06f);
        Rig.transform.position = new Vector3(-24.73f, 1, 90);
        scene = 2;
        GetComponent<AudioSource>().clip = scene2Clip;
        GetComponent<AudioSource>().Play();
        Shia.transform.position = new Vector3(-30.0f, 0.01f, 85);
        Destroy(Phone);
        Knife.SetActive(true);
        speed = 4f;
        shiaSpeed = 4f;
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length - 0.45f);
        scene = 3;
        Shia.SetActive(false);
        GetComponent<AudioSource>().clip = scene3Clip;
        GetComponent<AudioSource>().Play();
        speed = 1.0f;
        Rig.transform.position = new Vector3(35.184f, 1.5f, 115);
        Rig.transform.eulerAngles = new Vector3(Rig.transform.eulerAngles.x, Rig.transform.eulerAngles.y + 180, Rig.transform.eulerAngles.z);

    }
}