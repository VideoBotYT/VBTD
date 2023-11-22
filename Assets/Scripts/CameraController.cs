using UnityEngine;

public class CameraController : MonoBehaviour{

    private bool DoMovement = true;

    public float panSpeed = 30f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 90f;    

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoMovement = !DoMovement;
        }
        
        if (!DoMovement)
        {
            return;
        }

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

    }
}
