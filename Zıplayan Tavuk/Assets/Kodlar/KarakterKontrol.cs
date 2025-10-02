using UnityEngine;
using UnityEngine.SceneManagement; // Sahne (scene) i�lemleri i�in gerekli k�t�phane

public class KarakterKontrol : MonoBehaviour
{
    private Rigidbody2D rb;          // Karakterin fiziksel hareketlerini kontrol etmek i�in Rigidbody2D referans�
    public float yatayHiz;           // Karakterin yatay eksende hareket h�z�

    private float olmeYuksekligi;    // Karakter bu y�ksekli�in alt�na d��erse oyun yeniden ba�lat�lacak

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bile�enini al

        // �l�m s�n�r�n� kameran�n alt�na g�re ayarla (ekrandan epey a�a��da bir s�n�r)
        olmeYuksekligi = Camera.main.transform.position.y - 6f;
    }

    void Update()
    {
        // Kullan�c�n�n yatay giri�ini al (sol/sa� ok tu�lar� veya A/D tu�lar�)
        float hiz = Input.GetAxis("Horizontal") * yatayHiz;

        // Rigidbody'nin yatay h�z�n� belirle, dikey h�za dokunma (d����/z�plama korunur)
        rb.linearVelocity = new Vector2(hiz, rb.linearVelocity.y);

        // Karakter �l�m s�n�r�n�n alt�na d��t�yse sahneyi yeniden y�kle (oyun ba�a d�ner)
        if (transform.position.y < olmeYuksekligi)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Aktif sahneyi tekrar y�kle
        }
    }
}
