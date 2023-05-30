using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    
    private float moveHorizontal;
    private float moveVertical;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 100.0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame, which is beneficial when we need to check for input every frame
    void Update() 
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }

    // FixedUpdate is called once per physics frame, good for physics actions like AddForce
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed * Time.fixedDeltaTime);  // fixedDeltaTime is the same as deltaTime, but more aligned to physics
    }
}
