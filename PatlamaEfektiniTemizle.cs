using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatlamaEfektiniTemizle : MonoBehaviour {

    //patlama efektleri gerçekleştikten sonra hala oyun ekranında kalıyordu. bu bir süre sonra fps sorunu yaratabilir
    // bu yüzden bu efektleri gerceklestikten bir süre sonra silmemiz gerekir
    void Start () {

        Destroy(gameObject, 3);//3 saniye sonra sil dedik.
 // bu script'i efektin içine atıyoruz bu sayede çağırıldıktan 3 saniye sonra silinecek
	}
	
	
}
