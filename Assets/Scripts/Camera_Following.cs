using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Following : MonoBehaviour
{
    public float speed;
    private float _initialPosition;
    private float _maxPosition;

    public GameObject playerObject;
    public GameObject endObject;
    public Vector2 vecOffset;
    private Vector2 _threshold;
    private Rigidbody2D _rb;

    void Start()
    {
        _threshold = CalculateThreshold();

        _rb = playerObject.GetComponent<Rigidbody2D>();

        _initialPosition = playerObject.transform.position.x;
        _maxPosition = endObject.transform.position.x;

    }

    void FixedUpdate()
    {
        Vector2 follow = playerObject.transform.position;

        float xDiference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDiference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;

        if (Mathf.Abs(xDiference) >= _threshold.x){
            newPosition.x = follow.x;

        }

        if (Mathf.Abs(yDiference) >= _threshold.y){
            newPosition.y = follow.y;

        }

        float moveSpeed = _rb.velocity.magnitude > speed ? _rb.velocity.magnitude : speed;

        if(follow.x > _initialPosition && follow.x < _maxPosition) {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);

        }

    }

    private Vector3 CalculateThreshold(){
        Rect aspect = Camera.main.pixelRect;
        
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        
        t.x -= vecOffset.x;
        t.y -= vecOffset.y;

        return t;
    }

    // private void OnDrawGizmos() {
    //     Vector2 border = CalculateThreshold();
        
    //     Gizmos.color = Color.blue;
    //     Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));

    // }
}
