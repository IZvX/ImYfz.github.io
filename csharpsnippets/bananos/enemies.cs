// Check if the distance between enemy and player is greater than the retreat distance
if ((double) Vector2.Distance((Vector2) this.transform.position, (Vector2) this.player.transform.position) >= (double) this.retreatDistance)
    return; // If distance is greater, return and do nothing

// Get the direction vector from enemy to player
Vector2 direction = (player.transform.position - transform.position).normalized;

// Calculate new position to move towards
Vector2 newPosition = (Vector2)transform.position + (direction * -speed * Time.deltaTime);

// Move enemy to new position
transform.position = newPosition;