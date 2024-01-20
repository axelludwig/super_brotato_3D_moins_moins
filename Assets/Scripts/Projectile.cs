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

        // Effectuer le raycast devant le projectile pour détecter les ennemis
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Direction, distanceThisFrame, EnemyLayer);

        if (hit.collider != null)
        {
            // Si le raycast touche un ennemi, détruire le projectile
            // Vous pouvez aussi appeler une fonction de dégât ici si vous voulez
            Destroy(gameObject);
            return; // Sortir de la fonction pour ne pas déplacer le projectile après sa destruction
        }

        // Déplacer le projectile
        transform.Translate(Direction.normalized * distanceThisFrame);
    }
}
