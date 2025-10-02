using TMPro;               // TextMeshPro bile�enini kullanmak i�in gerekli
using UnityEngine;

public class SkorTakip : MonoBehaviour
{
    public TextMeshProUGUI skorText;   // Skoru ekrana yazd�racak TextMeshPro nesnesi
    public Transform karakter;         // Skoru takip edece�imiz karakterin Transform'u
    private float highScore;                     // Kay�tl� en y�ksek skor
    public TextMeshProUGUI highScoreText;       // Ekranda g�sterilecek y�ksek skor yaz�s�

    private float baslangicY;          // Oyunun ba��nda karakterin Y konumu (ba�lang�� y�ksekli�i)
    private float enYuksekY;           // Karakterin ula�t��� en y�ksek Y konumu

    void Start()
    {
        // Oyunun ba�lang�c�nda karakterin Y konumunu ba�lang�� noktas� olarak kaydet
        baslangicY = karakter.position.y;

        // En y�ksek de�er ba�lang��ta karakterin ilk konumudur
        enYuksekY = baslangicY;

        // PlayerPrefs'ten y�ksek skoru al (yoksa 0 olur)
        highScore = PlayerPrefs.GetFloat("HighScore", 0);

        // UI'ya yaz
        highScoreText.text = "Y�ksek Skor: " + Mathf.FloorToInt(highScore).ToString();
    }

    void Update()
    {
        // E�er karakter daha �nce ula�t��� en y�ksek konumun �zerine ��kt�ysa
        if (karakter.position.y > enYuksekY)
        {
            enYuksekY = karakter.position.y;

            float skor = enYuksekY - baslangicY;

            skorText.text = "Skor: " + Mathf.FloorToInt(skor).ToString();

            // E�er skor, highScore'dan b�y�kse yeni skor kaydedilir
            if (skor > highScore)
            {
                highScore = skor;
                PlayerPrefs.SetFloat("HighScore", highScore);              // Kaydet
                highScoreText.text = "Y�ksek Skor: " + Mathf.FloorToInt(highScore).ToString(); // UI g�ncelle
            }
        }
    }
}
