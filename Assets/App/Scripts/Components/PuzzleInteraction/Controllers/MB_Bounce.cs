using PuzzleInteraction.Controllers;
using UnityEngine;

public class MB_Bounce : MB_AbstractController
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float force = 10f;

    // Bobot arah (misalnya kita mau lebih dominan ke atas)
    [SerializeField] private Vector3 directionWeight = new Vector3(1f, 3f, 1f);


    /// <summary>
    /// Melontarkan Rigidbody dengan arah acak berbobot.
    /// </summary>
    public void Launch()
    {
        if (rb == null) return;

        // Buat vektor acak dalam range -1..1
        Vector3 randomDir = new Vector3(
            Random.Range(-1f, 1f) * directionWeight.x,
            Random.Range(0.5f, 1f) * directionWeight.y, // supaya selalu ada ke atas
            Random.Range(-1f, 1f) * directionWeight.z
        );

        // Normalisasi supaya proporsional
        randomDir.Normalize();

        // Terapkan gaya impuls
        rb.AddForce(randomDir * force, ForceMode.Impulse);
    }
}
