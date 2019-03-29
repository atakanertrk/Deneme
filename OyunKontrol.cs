using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OyunKontrol : MonoBehaviour {


    

    public GameObject Asteroid;
    public Vector3 randomPos;
    int score;
    public Text text;
    public Text oyunBittiText;
    bool oyunBittiKontrol = false;
    bool yenidenBaslaKontrol = false;
    public Text RyeBasText;

	void Start ()
    {
        score = 0;
        text.text = "score = " + score;
        
        StartCoroutine(olustur());
        
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&&yenidenBaslaKontrol)
        {
            SceneManager.LoadScene("SpaceShooterScene");
        }
    }

    IEnumerator olustur() // burada ienumerator kullandık çünkü waitforsecond kullanıyoruz ve bu waitforsecond IEnumerator cinsinde oldugundan bu şekilde tanımladık
    {

        yield return new WaitForSeconds(2); // oyunun başında 2sn bekliyor
        while (true)
        {
            for(int i = 0; i < 10; i++) //10 adet asteroid olusturuyor
            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z); // asteroidin olusacagı pozisyon
                Instantiate(Asteroid, vec, Quaternion.identity); //asteroidi olusturan kod satiri
                yield return new WaitForSeconds(0.7f); // bir asteroid olustuktan sonra ikincisi olusmadan once 0.7 saniye bekliyoruz bu sayede birbirine çarpmıyorlar

            }
            yield return new WaitForSeconds(2); //her 10'lu asteroit grubu olustuktan sonra 5sn bekliyoruz

            if (oyunBittiKontrol)
            {
                yenidenBaslaKontrol = true;
                break;
            }
        }

    }

    public void ScoreArttir(int gelenScore)
    {
        score += gelenScore;
        text.text = "score = " + score;
        Debug.Log(score);
    }

    public void oyunbitti()
    {
        oyunBittiText.text = "OYUN BİTTİ";
        RyeBasText.text = "Yeniden Oynamak İçin \"R\"";
        oyunBittiKontrol = true;
    }
	
}



