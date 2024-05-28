using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform target; // Refer�ncia para o transform do jogador
    public float smoothSpeed = 0.125f; // Velocidade de suaviza��o do movimento da c�mera
    public Vector3 offset; // Dist�ncia entre a c�mera e o jogador

    void FixedUpdate()
    {
        if (target != null)
        {

            Vector3 desiredPosition = target.position + offset;
            desiredPosition.z = transform.position.z; // Manter a posi��o Z da c�mera fixa
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

        }
    }
}
