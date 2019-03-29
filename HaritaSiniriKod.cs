using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaritaSiniriKod : MonoBehaviour {



    // GEMİMİZİN ATTIGI KURSUNLAR UNİTY'DE BELİRLEDİĞİMİZ ALANIN YANİ HARİTA DISINA CIKTIGI ZAMAN YOK OLMASINI KODLUYORUZ.
    // EGER BUNU YAPMAZSAK OYUNUMUZ BİR SÜRE SONRA KASMAYA BASLAR...



 /* Buradaki ontriggerexit metodumuz dışarıdan col isminde bir collider alıyor. metodumuzun içinde yazdığımız destroy komutu sayesinde eğer herhangi bir temas olursa harita sınırına
    ol.gameobject yani kursunumuzu siliyor... */

    void OnTriggerExit(Collider col)//temas olduktan sonra çık
    {
        Destroy(col.gameObject);
    }



}
