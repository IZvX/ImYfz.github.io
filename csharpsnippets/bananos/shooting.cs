// Calculate direction vector from object's position to mouse position
Vector3 mousePos = Input.mousePosition;
Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
Vector3 direction = mouseWorldPos - transform.position;

// Set object's right vector to face the mouse direction
Vector2 rightVector = new Vector2(direction.x, direction.y);
transform.right = rightVector;