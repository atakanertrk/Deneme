using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KursunKontrol : MonoBehaviour {

    Rigidbody fizik;
    public float KursunHizi;
	void Start () {

        fizik = GetComponent<Rigidbody>();
        fizik.velocity = transform.forward*KursunHizi; // fizigin velocitysini(süratini) transform.forward yani ileriye doğru devam ettir diyoruz bu sayede kursun durmadan devam edecek.


	}
	
	
}
