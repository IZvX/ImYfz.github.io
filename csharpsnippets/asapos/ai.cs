Transform[] enemies = enemys.ToArray(); // get a copy of the list of enemies
int index = 0;
foreach (Transform stunnedEnemy in stunnedEnemys) // loop through the stunned enemies
{
    if (stunnedEnemy == null)
    {
        enemys.Remove(stunnedEnemy); // if an enemy is null, remove it from the list
    }
    else
    {
        stunnedEnemy.GetComponent<EnemyHealth>().hideCounter(); // hide the stun counter
        if (!stunnedEnemy.GetComponent<EnemyHealth>().stunned)
        {
            stunnedEnemys.Remove(stunnedEnemy); // if the enemy is not stunned, remove it from the stunned enemies list
            enemys.Add(stunnedEnemy); // add the enemy back to the enemies list
        }
    }
}
foreach (Transform enemy in enemys) // loop through the enemies
{
    if (enemy == null)
    {
        enemys.Remove(enemy); // if an enemy is null, remove it from the list
    }
    else if (enemy.GetComponent<EnemyHealth>().stunned)
    {
        stunnedEnemys.Add(enemy); // if the enemy is stunned, add it to the stunned enemies list
        enemys.Remove(enemy); // remove the enemy from the enemies list
    }
}
timer += Time.deltaTime; // increase the timer
if (state == "Selecting") // if the state is Selecting
{
    index = Random.Range(0, enemies.Length); // select a random enemy from the list
    duringAttack = true;
    Attacker = enemies[index]; // set the Attacker to the selected enemy
    if (Attacker.GetComponent<EnemyHealth>().stunned)
        Random.Range(0, enemies.Length); // if the Attacker is stunned, select another random enemy
    // print out debug information
    Debug.Log("selectAttacker(int: " + enemies[index].name + " string: " + index.ToString() + ")");
    if (timer >= 1f / speed + 0.5f)
    {
        timer = 0f;
        state = "Attacking"; // change the state to Attacking
    }
}
if (state == "Attacking") // if the state is Attacking
{
    // print out debug information
    Debug.Log("SendAttacker()");
    enemies[index].GetComponent<EnemyHealth>().showCounter(); // show the attack counter for the Attacker
    enemies[index].DOLocalMove(player.position, 1f / speed); // move the Attacker towards the player
    if (timer >= 1f / speed + 0.1f)
    {
        timer = 0f;
        state = "Retreating"; // change the state to Retreating
        DamagePlayer(Random.Range(1f, 3f)); // damage the player
    }
}