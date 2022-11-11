using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] Renderer ground;
    // Start is called before the first frame update
    void Start()
    {
        ground = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ground.material.mainTextureOffset -= new Vector2(0.003f, 0);
    }
}

