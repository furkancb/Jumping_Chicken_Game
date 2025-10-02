using UnityEngine;
using UnityEngine.SceneManagement; // Sahne (scene) iþlemleri için gerekli kütüphane

public class KarakterKontrol : MonoBehaviour
{
    private Rigidbody2D rb;          // Karakterin fiziksel hareketlerini kontrol etmek için Rigidbody2D referansý
    public float yatayHiz;           // Karakterin yatay eksende hareket hýzý

    private float olmeYuksekligi;    // Karakter bu yüksekliðin altýna düþerse oyun yeniden baþlatýlacak

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileþenini al

        // Ölüm sýnýrýný kameranýn altýna göre ayarla (ekrandan epey aþaðýda bir sýnýr)
        olmeYuksekligi = Camera.main.transform.position.y - 6f;
    }

    void Update()
    {
        // Kullanýcýnýn yatay giriþini al (sol/sað ok tuþlarý veya A/D tuþlarý)
        float hiz = Input.GetAxis("Horizontal") * yatayHiz;

        // Rigidbody'nin yatay hýzýný belirle, dikey hýza dokunma (düþüþ/zýplama korunur)
        rb.linearVelocity = new Vector2(hiz, rb.linearVelocity.y);

        // Karakter ölüm sýnýrýnýn altýna düþtüyse sahneyi yeniden yükle (oyun baþa döner)
        if (transform.position.y < olmeYuksekligi)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Aktif sahneyi tekrar yükle
        }
    }
}
