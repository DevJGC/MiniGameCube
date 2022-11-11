using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    // Bool del salto
    [SerializeField] bool jump;
    // Velocidad del salto
    [SerializeField] float jumpForce;
    // Limite de altura
    [SerializeField] float jumpTop;
    // Referencia al enemigo
    [SerializeField] GameObject enemy;
    // Referencia las particulas del player
    [SerializeField] ParticleSystem player;
    // Referencia color del player
    [SerializeField] Renderer colorPlayer;
    // Rotacion player
    float rotatePlayer;

    // Inicia componentes y enemigo(s)
    void Start()
    {
        enemy = GameObject.Find("Enemy");
        player = GetComponent<ParticleSystem>();
        colorPlayer = GetComponent<Renderer>();       
    }

    void Update()
    {
        // Tecla Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {       
          jump = true;             
        }

        // Salto
        if (jump)
        {
            if (transform.position.y < jumpTop)
            {
                transform.position += new Vector3(0, jumpForce, 0);
                rotatePlayer --;
            }
            else
            {
                jump = false;              
            }
        }
        // Caida
        if (!jump)
        { 
            if (transform.position.y >= -1)
            {
                transform.position -= new Vector3(0, jumpForce, 0);
                rotatePlayer = 0;
            } 
        }

        // Colision con enemigo por coordenadas
        if (enemy.transform.position.x <-3 &&  enemy.transform.position.x >-4)
        {
            if (transform.position.y < 1f)
            {        
                player.Play();
                StartCoroutine("DestroyPlayer");
            }       
        } 
        
        // Rotacion player
        transform.rotation = Quaternion.Euler(0, 0, rotatePlayer); 

    }

    // Corrutina Destruye player - Desactiva salto - Cambia color - Activa particulas
    IEnumerator DestroyPlayer()
    {
        jump = true;
        colorPlayer.material.color = new Color(1, 0, 0);   
        yield return new WaitForSeconds(0.3f);
        player.Stop();
        colorPlayer.material.color = new Color(0, 0, 1);
    }
}
