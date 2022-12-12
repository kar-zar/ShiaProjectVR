using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Scene1MovementScript : MonoBehaviour
{
    public GameObject Rig;
    public GameObject Phone;
    public GameObject Shia;
    public GameObject Shia2;
    public GameObject ShiaHead;
    public GameObject Knife;
    public GameObject Knife2;
    public GameObject BearTrap;
    public GameObject firstBlood;
    public GameObject secondBlood;
    public GameObject thirdBlood;
    public GameObject axe;
    public GameObject gun;
    public GameObject gameOverScreen;
    public float speed = 2.0f;
    public float shiaSpeed = 2.05f;
    public int scene = 1;
    public int flag = 0;
    public AudioClip scene1Clip;
    public AudioClip scene2Clip;
    public AudioClip scene3Clip;
    public AudioClip scene4Clip;
    public AudioClip scene5Clip;
    public AudioClip scene6Clip;
    public AudioClip scene7Clip;

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
        if (scene == 1)
        {
            shiaSpeed = shiaSpeed + 0.00013f;
        }
        if (scene == 2)
        {
            if (Shia.transform.position.z > 145.5f)
            {
                shiaSpeed = 0.00f;
            }
        }
        if (scene == 3)
        {
            if (Rig.transform.position.z < 97.0)
            {
                speed = 0.0f;
                BearTrap.SetActive(true);
            }
        }
        if (scene == 4)
        {
            if (Rig.transform.position.z < 51)
            {
                firstBlood.SetActive(true);
            }
            if (Rig.transform.position.z < 45)
            {
                secondBlood.SetActive(true);
            }
            if (Rig.transform.position.z < 42)
            {
                thirdBlood.SetActive(true);
                Rig.transform.position = new Vector3(28.5f, 1.1f, 37);
            }
        }
        if (scene == 5)
        {
            if (Rig.transform.position.z < 32.4f)
            {
                speed = 0.0f;
                if (flag == 0)
                {
                    Shia.transform.position = new Vector3(29.9f, .6f, 31.9f);
                    Rig.transform.position = new Vector3(31.2f, .75f, 31.9f);
                    Knife.SetActive(false);
                    Knife2.SetActive(true);
                   // Rig.transform.eulerAngles = new Vector3(Rig.transform.eulerAngles.x, Rig.transform.eulerAngles.y + (90 - 18.5f), Rig.transform.eulerAngles.z);
                    Shia.transform.eulerAngles = new Vector3(Shia.transform.eulerAngles.x, Shia.transform.eulerAngles.y - 210, Shia.transform.eulerAngles.z);
                    flag = 1;
                }
            }
        }
        if(scene == 6)
        {
            if (flag == 0)
            {
                if (Rig.transform.position.z < 11.25f)
                {
                    gun.SetActive(true);
                    speed = 0.0f;
                    Shia.transform.position = new Vector3(31.11f, 0.01f, 9.4f);
                    Shia.transform.eulerAngles = new Vector3(Shia.transform.eulerAngles.x, Shia.transform.eulerAngles.y - 62, Shia.transform.eulerAngles.z);
                    Shia.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    flag = 1;
                }
            }
            else if(flag == 1)
            {

                speed = -0.70f;
                shiaSpeed = 0.70f;
                if (Rig.transform.position.z > 16)
                {
                    gun.SetActive(false);
                    axe.SetActive(true);
                }
                if (Rig.transform.position.z > 29)
                {
                    flag = 2;
                    speed = 0;
                    shiaSpeed = 0;
                    Shia.SetActive(false);
                    Shia2.transform.position = new Vector3(31.11f, 0.01f, 27.15f);
                   // Shia.transform.eulerAngles = new Vector3(Shia.transform.eulerAngles.x, Shia.transform.eulerAngles.y - 62, Shia.transform.eulerAngles.z);
                    Shia2.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    ShiaHead.transform.position = new Vector3(31.11f, 0.01f, 27.15f);
                    // Shia.transform.eulerAngles = new Vector3(Shia.transform.eulerAngles.x, Shia.transform.eulerAngles.y - 62, Shia.transform.eulerAngles.z);
                    ShiaHead.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

                }
            }
        }

    }

    IEnumerator playEngineSound()
    {
        GetComponent<AudioSource>().clip = scene1Clip;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length - 1.06f);
        Rig.transform.position = new Vector3(-24.73f, 1, 90);

        scene = 2;
        GetComponent<AudioSource>().clip = scene2Clip;
        GetComponent<AudioSource>().Play();
        Shia.transform.position = new Vector3(-24.73f, 0.01f, 85);
        Destroy(Phone);
        Knife.SetActive(true);
        speed = 4f;
        shiaSpeed = 4f;
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length - 0.45f);

        scene = 3;
        //Shia.SetActive(false);
        GetComponent<AudioSource>().clip = scene3Clip;
        GetComponent<AudioSource>().Play();
        speed = 1.0f;
        Rig.transform.position = new Vector3(35.184f, 0.5f, 115);
        Rig.transform.eulerAngles = new Vector3(Rig.transform.eulerAngles.x, Rig.transform.eulerAngles.y + 180, Rig.transform.eulerAngles.z);
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length - 0.10f);

        scene = 4;
        //Shia.SetActive(true);
        GetComponent<AudioSource>().clip = scene4Clip;
        GetComponent<AudioSource>().Play();
        Rig.transform.position = new Vector3(30, 1, 48);
        speed = 1.5f;
        Shia.transform.position = new Vector3(30.08f, .5f, 32.64f);
        Shia.transform.eulerAngles = new Vector3(Shia.transform.eulerAngles.x, Shia.transform.eulerAngles.y - 90, Shia.transform.eulerAngles.z);
        Shia.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length - 0.24f);
        GetComponent<AudioSource>().clip = scene5Clip;
        GetComponent<AudioSource>().Play();

        scene = 5;
        speed = .36f;
        Rig.transform.position = new Vector3(31.84f, 1, 35.197f);
        Rig.transform.eulerAngles = new Vector3(Rig.transform.eulerAngles.x, Rig.transform.eulerAngles.y + 18.5f, Rig.transform.eulerAngles.z);

        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length - 0.22f);
        GetComponent<AudioSource>().clip = scene6Clip;
        GetComponent<AudioSource>().Play();
        
        scene = 6;
        speed = .25f;
        Rig.transform.position = new Vector3(30.71f, 1, 13.85f);
        Rig.transform.eulerAngles = new Vector3(Rig.transform.eulerAngles.x, Rig.transform.eulerAngles.y - 18.5f, Rig.transform.eulerAngles.z);
        flag = 0;


        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length - 0.18f);
        GetComponent<AudioSource>().clip = scene7Clip;
        GetComponent<AudioSource>().Play();
        Rig.transform.position = new Vector3(30.71f, -0.1f, 28.5f);
        ShiaHead.transform.position = new Vector3(32.71f, .25f, 27.5f);

        yield return new WaitForSeconds(15);
        gameOverScreen.SetActive(true);


    }
}