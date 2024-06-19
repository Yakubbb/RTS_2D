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
    private void HandleLeftClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Debug.Log(hit.point);
        if (hit.collider != null && hit.transform.GetComponentInChildren<UnitBody>() != null && !hit.transform.GetComponentInChildren<UnitBody>().IsDead)
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
            if (hit.transform != null)
            {
                Debug.Log(hit.transform.gameObject.name);
            }
            if (selectedUnit != null)
            {
                selectedUnit.IsSelected = false;
                HasSelectedUnit = false;
            }
        }

    }
    private void HandleRightClick()
    {
        if (selectedUnit == null || HasSelectedUnit == false)
        {
            return;
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Debug.Log(Input.mousePosition);
        selectedUnit.GoToPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleLeftClick();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            HandleRightClick();
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleZoom();
        HandleInput();
        if (selectedUnit != null)
        {
            if (selectedUnit.IsDead)
            {
                selectedUnit.IsSelected = false;
                HasSelectedUnit = false;
            }
        }
    }
}
