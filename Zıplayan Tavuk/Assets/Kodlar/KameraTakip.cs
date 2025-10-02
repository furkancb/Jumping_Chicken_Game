using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    // Takip edilecek hedef (genellikle oyuncu karakteri)
    public Transform hedef;

    // Kameran�n hedefi takip etme h�z� (0 ile 1 aras�nda bir de�er �nerilir)
    public float takipHizi;

    void Update()
    {
        // Sadece hedef (karakter) kameran�n �u anki konumundan daha yukar�daysa takip et
        if (hedef.position.y > transform.position.y)
        {
            // Kameran�n hedefin Y konumuna ula�mak i�in gitmesi gereken yeni pozisyonu belirle
            Vector3 yeniPos = new Vector3(transform.position.x, hedef.position.y, transform.position.z);

            // Kameray� yumu�ak bir �ekilde yeni pozisyona do�ru hareket ettir (Lerp: Linear Interpolation)
            transform.position = Vector3.Lerp(transform.position, yeniPos, takipHizi);
        }
    }
}
