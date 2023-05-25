using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int zoomAmount = 4;
    public TextMeshProUGUI zoomText;

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.F))
        {
            // ��������� ������ ������ ��� ������� �� F
            Camera.main.orthographicSize += zoomAmount;
            zoomText.enabled = false;
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            // ���������� ������ ������ ������� � �������� ��������� ��� ���������� F
            Camera.main.orthographicSize -= zoomAmount;
        }
    }
}
