using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>左右移動する力</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>ジャンプする力</summary>
    [SerializeField] float m_jumpPower = 15f;
    /// <summary>最初に出現した座標</summary>
    Vector3 m_initialPosition;
    float _player;
    // Start is called before the first frame update
    void Start()
    {

        // 初期位置を覚えておく
        m_initialPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _player = Input.GetAxisRaw("Horizontal");
        {
            Debug.Log("入力");
        }
    }
}
