using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    // Velocidad enemigo
    [SerializeField] float enemyVelocity;
    // Color enemigo
    [SerializeField] Renderer color;
    
    void Update()
    {
        // Movimiento enemigo
        transform.position += new Vector3(enemyVelocity, 0, 0);

        // Cuando llega al margen izquierdo, cambio de color enemigo, posición y velocidad
        if (transform.position.x < -10)
        {
            transform.position = new Vector3(Random.Range(15,17), transform.position.y, transform.position.z);
            enemyVelocity = Random.Range(-0.035f,-0.055f);
            color.material.color = new Color(Random.Range(0, 1f), 0, Random.Range(0, 1f));    
        }
    }
}
