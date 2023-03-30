if (enemies.Count == 0)
{
    bool isTimerFinished = false; // Set flag to check if the timer has finished
    timer += Time.deltaTime; // Increment timer based on delta time
    timerText.text = timerrr.ToString(); // Update timer text display

    if (timer >= 3.0) // Check if timer has reached its target
    {
        isTimerFinished = true; // Set flag to indicate timer has finished
    }

    if (isTimerFinished) // Check if timer has finished
    {
        wave++; // Increment wave counter
        amountOfEnemies++; // Increment amount of enemies to spawn
        timer = 0.0f; // Reset timer to start again

        for (int i = 0; i < amountOfEnemies; i++) // Spawn x amount of enemies (x = amountOfEnemies)
        {
            Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); // Generate random spawn position
            GameObject newEnemy = Object.Instantiate(enemy, (Vector3)randomPosition, Quaternion.identity); // Spawn new enemy at random position
            enemies.Add(newEnemy); // Add new enemy to list of enemies
        }
    }
}