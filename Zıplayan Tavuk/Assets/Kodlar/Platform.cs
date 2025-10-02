using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Karakterin platforma �arpt���nda yukar� f�rlama g�c�
    public float ziplamaGucu;

    // Ana kamera referans�
    private Camera kamera;

    private void Start()
    {
        // Ana kameray� referansa al
        kamera = Camera.main;
    }
    private void Update()
    {
        // Kamera ile platform aras�ndaki dikey mesafeyi hesapla
        float mesafe = kamera.transform.position.y - transform.position.y;

        // E�er platform kameran�n 5.13 birim alt�na d��m��se,
        // platformu yukar� ta�� (sonsuz z�plama oyunu gibi s�rekli yeniden kullan�labilir)
        if (mesafe >= 5.13f)
        {
            // Platformu 11 birim yukar� ta�� (ayn� X konumunda kals�n)
            transform.position = new Vector2(transform.position.x, transform.position.y + 11f);
        }
    }

    private void OnCollisionEnter2D(Collision2D temas)
    {
        Rigidbody2D karakterrb;

        // E�er �arpan nesne "Karakter" tag'ine sahipse VE yukar�dan d���yorsa (a�a��ya do�ru hareket ediyorsa)
        if (temas.gameObject.CompareTag("Karakter") && temas.relativeVelocity.y <= 0)
        {
            // Karakterin Rigidbody2D bile�enini al
            karakterrb = temas.gameObject.GetComponent<Rigidbody2D>();

            // Karakterin d��ey h�z�n� z�plama g�c�yle de�i�tir (yukar� f�rlat)
            karakterrb.linearVelocity = new Vector2(karakterrb.linearVelocity.x, ziplamaGucu);
        }
    }
}
