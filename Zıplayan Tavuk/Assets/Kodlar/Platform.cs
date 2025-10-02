using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Karakterin platforma çarptýðýnda yukarý fýrlama gücü
    public float ziplamaGucu;

    // Ana kamera referansý
    private Camera kamera;

    private void Start()
    {
        // Ana kamerayý referansa al
        kamera = Camera.main;
    }
    private void Update()
    {
        // Kamera ile platform arasýndaki dikey mesafeyi hesapla
        float mesafe = kamera.transform.position.y - transform.position.y;

        // Eðer platform kameranýn 5.13 birim altýna düþmüþse,
        // platformu yukarý taþý (sonsuz zýplama oyunu gibi sürekli yeniden kullanýlabilir)
        if (mesafe >= 5.13f)
        {
            // Platformu 11 birim yukarý taþý (ayný X konumunda kalsýn)
            transform.position = new Vector2(transform.position.x, transform.position.y + 11f);
        }
    }

    private void OnCollisionEnter2D(Collision2D temas)
    {
        Rigidbody2D karakterrb;

        // Eðer çarpan nesne "Karakter" tag'ine sahipse VE yukarýdan düþüyorsa (aþaðýya doðru hareket ediyorsa)
        if (temas.gameObject.CompareTag("Karakter") && temas.relativeVelocity.y <= 0)
        {
            // Karakterin Rigidbody2D bileþenini al
            karakterrb = temas.gameObject.GetComponent<Rigidbody2D>();

            // Karakterin düþey hýzýný zýplama gücüyle deðiþtir (yukarý fýrlat)
            karakterrb.linearVelocity = new Vector2(karakterrb.linearVelocity.x, ziplamaGucu);
        }
    }
}
