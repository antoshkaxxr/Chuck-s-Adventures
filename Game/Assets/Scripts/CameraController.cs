using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int zoomAmount = 4;

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.F))
        {
            // ”меньшаем размер камеры при нажатии на F
            Camera.main.orthographicSize += zoomAmount;
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            // ¬озвращаем размер камеры обратно в исходное положение при отпускании F
            Camera.main.orthographicSize -= zoomAmount;
        }
    }
}
