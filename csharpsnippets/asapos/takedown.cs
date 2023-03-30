if (fearTakedownBool) {
    // If fear takedown is active, set the slow motion post-processing effect and disable the normal one
    slowMoPostP.gameObject.SetActive(true);
    normalPostP.gameObject.SetActive(false);
    // Set the time scale to 0.2f to create a slow motion effect
    Time.timeScale = 0.2f;

    // If left mouse button is clicked and fear takedown list count is less than or equal to 5, and the mouse click hits an enemy object
    if (Input.GetMouseButtonDown(0) && fearTakedownList.Count <= 5 && 
        (Object) raycastHit2D.collider != (Object) null && 
        raycastHit2D.transform.CompareTag("Enemy")) {
        // Add the enemy object to the fear takedown list
        fearTakedownList.Add(raycastHit2D.transform);
        // Print a message indicating that the enemy object is added to the list
        MonoBehaviour.print((object)("added " + raycastHit2D.collider.name));
    }

    // If the fear takedown key is not pressed, return and do nothing
    if (!Input.GetKeyDown(FearTakedownKey)) {
        return;
    }

    // Reset the special attack counter and enable the line renderer
    SpecialAttackCounter = 0;
    line.enabled = true;

    // Loop through the fear takedown list, starting from the second item, and perform the fear takedown on each enemy object
    for (int index = 1; index < fearTakedownList.Count; ++index) {
        // Move the player character to the enemy object's position using the DOTween library
        transform.DOLocalMove(fearTakedownList.ToArray()[index].position, 0.5f);
        // Trigger the explosion animation of the enemy object
        fearTakedownList.ToArray()[index].GetComponent().boom();
        // Print a message indicating that the enemy object is hit by the fear takedown
        MonoBehaviour.print((object)("Hit this guy :" + fearTakedownList.ToArray()[index].name));
    }

    // Set the fear takedown flag to false to indicate that the fear takedown is completed
    fearTakedownBool = false;

} else {
    // If fear takedown is not active, set the normal post-processing effect and disable the slow motion one
    slowMoPostP.gameObject.SetActive(false);
    normalPostP.gameObject.SetActive(true);

    // If the fear takedown key is pressed and the special attack counter is greater than or equal to 12
    if (Input.GetKeyDown(FearTakedownKey) && SpecialAttackCounter >= 12) {
        // Set the fear takedown flag to true to start the fear takedown
        fearTakedownBool = true;
        // Print a message indicating that the fear takedown is started
        MonoBehaviour.print((object)"started fear takedown");
    }

    // Set the time scale to 1f to return to normal speed
    Time.timeScale = 1f;
    // Clear the fear takedown list
    fearTakedownList.Clear();
}