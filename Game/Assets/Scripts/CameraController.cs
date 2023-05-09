using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float zoomAmount = 4f;

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.F))
        {
            // ��������� ������ ������ ��� ������� �� F
            Camera.main.orthographicSize += zoomAmount;
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            // ���������� ������ ������ ������� � �������� ��������� ��� ���������� F
            Camera.main.orthographicSize -= zoomAmount;
        }
    }
}
