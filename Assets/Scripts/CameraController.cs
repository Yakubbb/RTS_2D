using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool HasSelectedUnit = false;
    public UnitBody selectedUnit;
    public float moveSpeed = 5f;
    public float minZoom = 1f;
    public float maxZoom = 10f;
    public float zoomSpeed = 5f;
    private void HandleZoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - scrollInput * zoomSpeed, minZoom, maxZoom);
    }
    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
    private void HandleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.transform.GetComponentInChildren<UnitBody>() != null)
            {
                if (selectedUnit != null)
                {
                    selectedUnit.IsSelected = false;
                }
                Debug.Log(hit.transform.GetComponent<UnitBody>());
                selectedUnit = hit.transform.GetComponent<UnitBody>();
                selectedUnit.IsSelected = true;
                HasSelectedUnit = true;
            }
            else
            {
                if (selectedUnit != null)
                {
                    selectedUnit.IsSelected = false;
                    HasSelectedUnit = false;
                }
            }
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleZoom();
        HandleClick();
    }
}
