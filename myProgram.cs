// Cast a ray from the player's position towards the mouse position to detect any colliders in range.
// If a collider is found and has a "Enemy" tag, check for player inputs.
RaycastHit2D hit = Physics2D.Raycast(transform.position, (cam.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized, maxDistance);
if (hit.collider != null && hit.transform.CompareTag("Enemy"))
{
    // If the left mouse button is pressed, check that the player isn't performing a fear takedown and the hitTimer has elapsed.
    if (Input.GetMouseButtonDown(0) && !fearTakedownBool && hitTimer >= hitDelay)
    {
        // Reset the hitTimer and choose a random number for the attack variant.
        hitTimer = 0.0f;
        int attackVariant = Random.Range(1, 5);

        // Trigger the "Hit" animation and play a sound effect.
        animator.SetTrigger("Hit");
        animator.SetInteger("Variant", attackVariant);
        source.PlayOneShot(hit1);

        // Increase the combo counter and update the score based on the current combo.
        Combo++;
        SpecialAttackCounter++;
        score += Combo * 10;

        // Update the combo meter text and animation.
        comboText.text = "x" + Combo.ToString();
        comboMeterAnimator.SetTrigger("ComboUp");

        // Deal damage to the enemy and move the player towards the enemy using DOTween.
        hit.collider.transform.GetComponent<EnemyHealth>().takeDamage(1f, false, 3f, transform.position);
        float moveDuration = 1f / FreeflowSpeed;
        transform.DOLocalMove(hit.transform.position + (hit.transform.position - transform.position).normalized * 1.2f, moveDuration);

        // Print the name of the collider for debugging purposes.
        MonoBehaviour.print(hit.collider.name);
    }

    // If the middle mouse button is pressed, check that the player isn't performing a fear takedown and the stunTimer has elapsed.
    if (Input.GetMouseButtonDown(2) && !fearTakedownBool && stunTimer >= stunDelay)
    {
        // Reset the stunTimer and choose a random number for the attack variant.
        stunTimer = 0.0f;
        int attackVariant = Random.Range(1, 5);

        // Trigger the "Hit" animation and play a sound effect.
        animator.SetTrigger("Hit");
        animator.SetInteger("Variant", attackVariant);
        source.PlayOneShot(hit1);

        // Update the combo meter text and animation.
        comboText.text = "x" + Combo.ToString();
        comboMeterAnimator.SetTrigger("ComboUp");

        // Stun the enemy and move the player towards the enemy using DOTween.
        hit.collider.transform.GetComponent<EnemyHealth>().stunEnemy();
        float moveDuration = 1f / FreeflowSpeed;
        transform.DOLocalMove(hit.transform.position + (hit.transform.position - transform.position).normalized * 1.2f, moveDuration);

        // Print the name of the collider for debugging purposes.
        MonoBehaviour.print(hit.collider.name);
    }
}
