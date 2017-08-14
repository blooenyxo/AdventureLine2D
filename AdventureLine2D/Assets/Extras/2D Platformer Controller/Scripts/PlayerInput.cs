using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    public Vector2 directionalInput;
    private Player player;
    public bool selectedUnit;

    public GameObject Projectile;
    public GameObject projectileEmmiter;
    public float projectileSpeed;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (selectedUnit)
        {
            directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            player.SetDirectionalInput(directionalInput);

            if (Input.GetButtonDown("Jump") && gameObject.name == ("wizzard_normal"))
            {
                player.OnJumpInputDown();
            }

            if (Input.GetButtonUp("Jump") && gameObject.name == ("wizzard_normal"))
            {
                player.OnJumpInputUp();
            }

            if (Input.GetButtonDown("Fire1") && gameObject.name == ("wizzard_fire"))
            {
                Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 projectileEmmiterPosition = new Vector2(transform.position.x, transform.position.y);
                Vector2 direction = target - projectileEmmiterPosition;
                direction.Normalize();

                GameObject temp_bullet;
                temp_bullet = Instantiate(Projectile, projectileEmmiter.transform.position, Quaternion.identity) as GameObject;
                Rigidbody2D temp_rb;
                temp_rb = temp_bullet.GetComponent<Rigidbody2D>();
                temp_rb.velocity = direction * projectileSpeed;
                Destroy(temp_bullet, 5.0f);
            }
        }
    }
}
