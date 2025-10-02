using TMPro;               // TextMeshPro bileþenini kullanmak için gerekli
using UnityEngine;

public class SkorTakip : MonoBehaviour
{
    public TextMeshProUGUI skorText;   // Skoru ekrana yazdýracak TextMeshPro nesnesi
    public Transform karakter;         // Skoru takip edeceðimiz karakterin Transform'u
    private float highScore;                     // Kayýtlý en yüksek skor
    public TextMeshProUGUI highScoreText;       // Ekranda gösterilecek yüksek skor yazýsý

    private float baslangicY;          // Oyunun baþýnda karakterin Y konumu (baþlangýç yüksekliði)
    private float enYuksekY;           // Karakterin ulaþtýðý en yüksek Y konumu

    void Start()
    {
        // Oyunun baþlangýcýnda karakterin Y konumunu baþlangýç noktasý olarak kaydet
        baslangicY = karakter.position.y;

        // En yüksek deðer baþlangýçta karakterin ilk konumudur
        enYuksekY = baslangicY;

        // PlayerPrefs'ten yüksek skoru al (yoksa 0 olur)
        highScore = PlayerPrefs.GetFloat("HighScore", 0);

        // UI'ya yaz
        highScoreText.text = "Yüksek Skor: " + Mathf.FloorToInt(highScore).ToString();
    }

    void Update()
    {
        // Eðer karakter daha önce ulaþtýðý en yüksek konumun üzerine çýktýysa
        if (karakter.position.y > enYuksekY)
        {
            enYuksekY = karakter.position.y;

            float skor = enYuksekY - baslangicY;

            skorText.text = "Skor: " + Mathf.FloorToInt(skor).ToString();

            // Eðer skor, highScore'dan büyükse yeni skor kaydedilir
            if (skor > highScore)
            {
                highScore = skor;
                PlayerPrefs.SetFloat("HighScore", highScore);              // Kaydet
                highScoreText.text = "Yüksek Skor: " + Mathf.FloorToInt(highScore).ToString(); // UI güncelle
            }
        }
    }
}
