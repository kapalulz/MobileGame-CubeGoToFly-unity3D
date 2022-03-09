using UnityEngine;

public class Friendly : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player timeWatch))
        {
            Destroy(gameObject);
        }
    }
}
