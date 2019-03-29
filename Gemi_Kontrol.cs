using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemi_Kontrol : MonoBehaviour {

    Rigidbody fizik;
    float horizontal = 0;//yatay
    float vertical = 0;//dikey
    Vector3 vec;
    public float GemiHiz;
    public float maxX, maxZ, minX, minZ;
    public float egim;
    float AtesEtmeSuresi;
    public float AtesGecenSure;
    public GameObject Kursun;
    public Transform KursunNeredenCiksin;
    AudioSource audio; // ates edildiği zaman ses efekti eklemek için

	void Start () {
        fizik = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>(); // ates edildigi zaman ses efekti eklemek için
	}




    // Ateş etmeyi ve süresini tanımlıyoruz
     void Update()
    {
        if( (Input.GetButton("Fire1")) && Time.time > AtesEtmeSuresi ) // mouse'nin sol tıkına basıldıgında ve oyundaki süre ates etme süresinden büyük oldugunda 
        {
            AtesEtmeSuresi = Time.time + AtesGecenSure; // en hızlı atesgecensüre kadar ates edebilir. bu atesgecensüreye unityden deger atıyacaz. 1 der isek saniyede bir ates edebiliriz
            Instantiate(Kursun, KursunNeredenCiksin.position, Quaternion.identity); //instantiate metoduyla kursun objemizi olusturuyoruz. kursun objemiz olustugu gibi kendisi düz gidiyordu zaten bu şekilde kodlanmıstı
            audio.Play(); // ates edildiği zaman ses efektini oynat.                                                               
        }
    }




    void FixedUpdate () {      // FixedUpdate kullandık çünkü fizik olaylarını gerçekleştireceğiz. fixedupdate update gibi sürekli çalışır fakat düzgün zaman aralıklarında.

        horizontal = Input.GetAxis("Horizontal");//gemimizin yatay konumunu aldık
        vertical = Input.GetAxis("Vertical");//gemimizin dikey konumunu aldık
        vec = new Vector3(horizontal,0,vertical); //(x,y,z) gemimizi x ve z ekseninde hareket ettireceğiz 

        fizik.velocity = vec*GemiHiz;/*fizik olarak tanımladığımız rigidbody'e dolayısıyla gemiye velocity yani sürat ekledik. bu sayede 
                              artık gemimizi, tanımladığımız x ve z ekseninde w,a,s,d tuslarıyla hareket ettirebileceğiz.
                              bu wasd tusları unity tarafından otomatik atanıyor. Hız ile çarpıyoruz bu sayede hızını degistirebileceğiz gemimizin*/


        //************************************************************************************************************************************************
        fizik.position = new Vector3
            (                                                  // haritanın sınırlarını belirliyoruz. bunun için fizik rigidbodysinin pozisyonlarına clamp yapıyoruz yani türkçesi 
                Mathf.Clamp(fizik.position.x,minX,maxX),   // kelepçeliyoruz. Unity içerisinden bu max ve min değerlerini harita sınırlarına göre giriyoruz.
                0.0f,// y ekseninde çalışmıyoruz o yüzden y=0                  
                Mathf.Clamp(fizik.position.z,minZ,maxZ)

            );
        //*************************************************************************************************************************************************

        // şimdi gemimizin sağa giderken sağa sola giderken sola eğilmesini kodlayacağız
        fizik.rotation = Quaternion.Euler(0, 0, fizik.velocity.x * (-egim)); //quatrenion euler metodu sayesinde döndürme işlemi yapabiliyoruz ve bu eğilmeyi x ekseninde istediğimiz için -0, 0, fizik.velocity.x- bu şekilde kullandık

    }
}
