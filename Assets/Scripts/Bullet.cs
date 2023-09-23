using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletRb;

    private void Awake()
    {
        if (bulletRb == null)
            bulletRb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveDirection = bulletRb.velocity;
        
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
