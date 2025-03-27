using UnityEngine;

public class Movement : MonoBehaviour
{
    // Reference to the Animator
    private Animator animator;

    // Animation states names
    private const string standingState = "Volt-Standing";
    private const string rightState = "Volt-Right";
    private const string leftState = "Volt-Left";
    private const string duckState = "Volt-Ducking";

    public Vector2 standingSize = new Vector2(181.9498f, 499.8263f);
    public Vector2 duckingSize = new Vector2(275.4951f, 301.5103f);

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.transform.localScale = new Vector3(standingSize.x / spriteRenderer.sprite.bounds.size.x, standingSize.y / spriteRenderer.sprite.bounds.size.y, 1);
        }
    }

    void Update()
    {
        // LEFT MOVEMENT

        // Check if the A key or Left Arrow is pressed
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Play the "Volt-Right" animation when the key is pressed
            animator.Play(leftState);
        }



        // RIGHT MOVEMENT


        // Check if the D key or Right Arrow is pressed
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Play the "Volt-Right" animation when the key is pressed
            animator.Play(rightState);
        }


        
        // DUCK MOVEMENT


        // Check if the S key or Down Arrow is pressed
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Play the "Volt-Right" animation when the key is pressed
            animator.Play(duckState);
            ResizePlayer(duckingSize);
        }



        // ALL KEY RELEASE


        // Check if the D key or Right Arrow is released
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            // Play the "Volt-Standing" animation when the key is released
            animator.Play(standingState);
            ResizePlayer(standingSize);
        }
    }


    // Method to resize the player's sprite
    private void ResizePlayer(Vector2 newSize)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.transform.localScale = new Vector3(newSize.x / spriteRenderer.sprite.bounds.size.x, newSize.y / spriteRenderer.sprite.bounds.size.y, 1);
        }
    }
}