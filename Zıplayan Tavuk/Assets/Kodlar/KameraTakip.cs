using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    // Takip edilecek hedef (genellikle oyuncu karakteri)
    public Transform hedef;

    // Kameranýn hedefi takip etme hýzý (0 ile 1 arasýnda bir deðer önerilir)
    public float takipHizi;

    void Update()
    {
        // Sadece hedef (karakter) kameranýn þu anki konumundan daha yukarýdaysa takip et
        if (hedef.position.y > transform.position.y)
        {
            // Kameranýn hedefin Y konumuna ulaþmak için gitmesi gereken yeni pozisyonu belirle
            Vector3 yeniPos = new Vector3(transform.position.x, hedef.position.y, transform.position.z);

            // Kamerayý yumuþak bir þekilde yeni pozisyona doðru hareket ettir (Lerp: Linear Interpolation)
            transform.position = Vector3.Lerp(transform.position, yeniPos, takipHizi);
        }
    }
}
