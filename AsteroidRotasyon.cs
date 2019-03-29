using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotasyon : MonoBehaviour {

    Rigidbody fizik;
    public float AsteroidDonmeHizi;

    // Bu kodumuzda asteroidimizin kendi etrafında dönmesini sağlıyoruz.

	void Start () {
        fizik = GetComponent<Rigidbody>();

        fizik.angularVelocity = Random.insideUnitSphere * AsteroidDonmeHizi; // angelarveclocity özelliğini kendi etrafında dönmesi için kullanıyoruz (açısal hız) 
        //asteroid dönme hizi ile çarparak istediğimiz hızda dönmesini sağlayabiliyoruz.
	}
	
	
}
