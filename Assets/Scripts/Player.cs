using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // desde donde chequeamos el suelo
    public Transform groundCheck;
    // permite seleccionar que layer de la lista de layer es el suelo
    public LayerMask groundLayer;
    // para ver que grande es nuestro grounChek
    public float groundCheckRadius;
    
    [SerializeField] private Animator myAnimationController;

    public float speed = 2.0f;
    public float movX;
    public float movY;
    private bool _isGrounded;

    //Referencia
    public Rigidbody2D playerRb2d;

    // Start is called before the first frame update
    void Start()
    {
        playerRb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculamos el movimiento en base al input. Esto es, cuanta distancia debe moverse el gatito en este frame.
        float currentMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        
        movX = transform.position.x + currentMovement;
        movY = transform.position.y;
        
        // Rotación del gatito
        if (currentMovement > 0) // Camina hacia la derecha
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 1);
        }
        else if (currentMovement < 0) // Camina hacia la izquierda
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 1);
        }
        
        // Animación movimiento
        if (currentMovement != 0)
        {
            myAnimationController.SetBool("playRun", true);
        }
        else
        {
            myAnimationController.SetBool("playRun", false);
        }

        // Est� en el piso?
        // suelta peque�as bolas en el pto y radio que le digamos y check contra una layer. Si encuentra + de una layer devuelve un true
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && _isGrounded == true)
        {
            // Aplica fuerza vertical momentanea al objeto 
            playerRb2d.AddForce(Vector2.up * 300);
        }
        transform.position = new Vector2(movX, movY);

        // deshabilitar si cae demasiado
        if (transform.position.y < -5)
        {
            gameObject.SetActive(false);
        }
    }
}
