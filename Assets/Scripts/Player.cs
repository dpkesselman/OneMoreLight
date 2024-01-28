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
        movX = transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        movY = transform.position.y;

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
