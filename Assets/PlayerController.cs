using UnityEngine;

public class PlayerController: MonoBehaviour
{
    //左右移動する力
    [SerializeField] float _moveSpeed = 5f;
    Rigidbody2D _rb = default;
    //弾丸のプレハブ
    [SerializeField] GameObject _shellPrefab = default;
    //銃口の位置を設定するオブジェクト
    [SerializeField] Transform _muzzle = default;
    //水平方向の入力値
    float _h;
    float _scaleX;
    float _v;
    //最初に出現した座標
    Vector3 _initialPosition;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        // 初期位置を覚えておく
        _initialPosition = this.transform.position;
    }

    void Update()
    {
        
        // 入力を受け取る
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        // 各種入力を受け取る

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("ここに弾を発射する処理を書く。");
            GameObject go = Instantiate(_shellPrefab);
            go.transform.position = _muzzle.position;
        }
    }

    private void FixedUpdate()
    {
        Vector3 Direction = new Vector3(_h, _v).normalized;
        _rb.velocity = Direction * _moveSpeed;
    }
}
