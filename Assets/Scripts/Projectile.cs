using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 10f;
    public Vector2 Direction;
    public LayerMask EnemyLayer;

    private void Start()
    {
        Destroy(gameObject, 15f);
    }

    void Update()
    {
        MoveProjectile();
    }

    void MoveProjectile()
    {
        // Distance que le projectile va parcourir
        float distanceThisFrame = Speed * Time.deltaTime;

        // Effectuer le raycast devant le projectile pour d�tecter les ennemis
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Direction, distanceThisFrame, EnemyLayer);

        if (hit.collider != null)
        {
            // Si le raycast touche un ennemi, d�truire le projectile
            // Vous pouvez aussi appeler une fonction de d�g�t ici si vous voulez
            Destroy(gameObject);
            return; // Sortir de la fonction pour ne pas d�placer le projectile apr�s sa destruction
        }

        // D�placer le projectile
        transform.Translate(Direction.normalized * distanceThisFrame);
    }
}
