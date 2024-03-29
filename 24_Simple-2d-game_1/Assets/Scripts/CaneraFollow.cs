using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaneraFollow : MonoBehaviour
{

    public GameObject followObject;
    public Vector2 followOffset;
    public float spead = 10f;
    private Vector2 threshold;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        threshold = CalculateThreshold();
        rb = followObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 follow = followObject.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;
        if(Mathf.Abs(xDifference) >= threshold.x)
        {
            newPosition.x = follow.x;
        }
        if (Mathf.Abs(yDifference) >= threshold.y)
        {
            newPosition.y = follow.y;
        }
        //Debug.Log("rb.velocity.magnitude =" + rb.velocity.magnitude);
        float moveSpead = (rb.velocity.magnitude > spead) ? rb.velocity.magnitude : spead;
        //transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpead * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, newPosition, moveSpead * Time.deltaTime);
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, 0.1f, moveSpead);
    }

    private Vector3 CalculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = CalculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x *2, border.y *2, 1));
    }
}
