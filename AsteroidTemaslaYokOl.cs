using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTemaslaYokOl : MonoBehaviour {

    public GameObject patlama;
    public GameObject GemiPatlama;
    AudioSource audio;
    GameObject OyunKontrol;
    OyunKontrol kontrol;
     void Start()
    {
        OyunKontrol = GameObject.FindWithTag("OyunKontrol");
        kontrol = OyunKontrol.GetComponent<OyunKontrol>();
        
    }


    void OnTriggerEnter(Collider col)
    {
        audio = GetComponent<AudioSource>();

        if (col.tag != "sinir")  // eger temas eden obje sinir etiketine sahip değil ise.(oyun alanını sinir olarak adlandırdık. objemiz oyun alanında oldugu için direk silinmesin diye bunu yaptık.)
        {
            audio.Play();
            Destroy(col.gameObject);  //
                                      // bu iki satırdaki kod ile asteroide herhangi bir obje temas ettiğinde temas eden objeyi ve asteroidi yok ediyoruz. Ör: kursun atarız kursun ve asteroid yok olur
            Destroy(gameObject);      // gemi çarpar ise gemi ve asteroid yok olur şeklinde...
            

            Instantiate(patlama, transform.position, transform.rotation); //temas oldugu zaman patlama efektini gerçekleştiriyor.
            kontrol.ScoreArttir(10);

        }
        if (col.tag == "gemi")
        {
            Instantiate(GemiPatlama, col.transform.position, col.transform.rotation); // üstteki kod tek patlama yapıyor yani asteroidin patlama efekti. peki gemiye çarparsa bu asteroid hem gemi

            //hemde asteroid patlamalı. O yüzden gemi patlama efekti ekledik burda.
            kontrol.oyunbitti();
        }


    }



}
