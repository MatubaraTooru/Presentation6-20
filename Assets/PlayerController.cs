using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>���E�ړ������</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>�W�����v�����</summary>
    [SerializeField] float m_jumpPower = 15f;
    /// <summary>�ŏ��ɏo���������W</summary>
    Vector3 m_initialPosition;
    float _player;
    // Start is called before the first frame update
    void Start()
    {

        // �����ʒu���o���Ă���
        m_initialPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _player = Input.GetAxisRaw("Horizontal");
        {
            Debug.Log("����");
        }
    }
}
