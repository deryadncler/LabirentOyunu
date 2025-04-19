using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hareket : MonoBehaviour
{
    public Button buton;
    private Rigidbody rb;
    public float hiz = 1.8f;
    public Text zaman, can,tamaladýnýz;
    float zamansayaci = 500f;
    float cansayaci = 30f;
    bool oyundevam = true;
    bool oyuntamam=false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (oyundevam && !oyuntamam)
        {
            zamansayaci -= Time.deltaTime;
            zaman.text = (int)zamansayaci + "";
        }
        else if(!oyuntamam)
        {
            tamaladýnýz.text = "Oyun Tamamlanamadý";
            buton.gameObject.SetActive(true);
        }
       
        if (zamansayaci <= 0)
        {
            oyundevam = false;
        }
    }


    private void FixedUpdate()
    {
        if (oyundevam && !oyuntamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
            rb.AddForce(kuvvet * hiz);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        string objismi = other.gameObject.name;
        if (objismi.Equals("Finish")){
            //print("Oyunu Kazandýnýz");
            oyuntamam = true;
            tamaladýnýz.text = " Tebrikler Oyunu Tamamladýnýz";
            buton.gameObject.SetActive(true);
        }
        else if (!objismi.Equals("AnaZemin")&& !objismi.Equals("labzemin")&& !objismi.Equals("start"))
        {
            cansayaci -= 1;
            can.text = cansayaci + "";
            if (cansayaci == 0)
            {
                oyundevam = false;
            }
        }
    }
}
