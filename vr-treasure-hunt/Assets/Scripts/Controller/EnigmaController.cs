using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmaController : MonoBehaviour
{
    private int[] puzzleOrder;
    private int currentDisplayIndex = 0;
    private int currentSolveIndex = 0;
    private bool puzzleSolved = false;
    public GameObject[] puzzleSpheres;
    public float puzzleSpeed = 1f;
    public GameObject failAudioHolder;
    public Door doorKey;
    public WaypointController waypointController;

    private void Start()
    {
        puzzleOrder = new int[puzzleSpheres.Length];
        GeneratePuzzleSequence();
    }

    // Create a random puzzle sequence.
    public void GeneratePuzzleSequence()
    {
        // Variable for storing a random number.
        int randomInt;

        // Loop as many times as the puzzle length.
        for (int i = 0; i < puzzleSpheres.Length; i++)
        {
            // Generate a random number.
            randomInt = Random.Range(0, puzzleSpheres.Length);

            // Set the current index to the randomly generated number.
            puzzleOrder[i] = randomInt;
        }
    }

    // Begin the puzzle sequence.
    public void StartPuzzle()
    {
        if (!puzzleSolved)
        {
            // Call the DisplayPattern() function repeatedly.
            CancelInvoke("DisplayPattern");
            InvokeRepeating("DisplayPattern", 3, puzzleSpeed);

            // Reset the index the player is trying to solving.
            currentSolveIndex = 0;
        }
    }

    // Reset the puzzle sequence.
    public void ResetPuzzle()
    {
        GeneratePuzzleSequence();
    }

    // Disaplay the
    // Called from StartPuzzle() and invoked repeatingly.
    void DisplayPattern()
    {
        // If we haven't reached the end of the display pattern.
        if (currentDisplayIndex < puzzleOrder.Length)
        {
            // Light up the orb at the current index.
            puzzleSpheres[puzzleOrder[currentDisplayIndex]].GetComponent<LightUp>().PatternLightUp(puzzleSpeed);

            // Move one to the next orb.
            currentDisplayIndex++;
        }
        // If we have reached the end of the display pattern.
        else
        {
            // Reset the index tracking the orb being lit up.
            currentDisplayIndex = 0;

            // Stop the pattern display.
            CancelInvoke();
        }
    }

    // Identify the index of the sphere the player selected.
    // Called from LightUp.PlayerSelection() method (see LightUp.cs script).
    public void PlayerSelection(GameObject sphere)
    {
        // Variable for storing the selected index.
        int selectedIndex = 0;

        // Loop throught the array to find the index of the selected sphere.
        for (int i = 0; i < puzzleSpheres.Length; i++)
        {
            // If the passed in sphere is the sphere at the index being checked.
            if (puzzleSpheres[i] == sphere)
            {
                // Update the index of the passed in sphere to be the same as the index being checked.
                selectedIndex = i;
            }
        }
        SolutionCheck(selectedIndex);
    }

    // Check if the sphere the player selected is correct.
    public void SolutionCheck(int playerSelectionIndex)
    {
        if (playerSelectionIndex == puzzleOrder[currentSolveIndex])
        {
            currentSolveIndex++;

            if (currentSolveIndex >= puzzleSpheres.Length)
            {
                PuzzleSuccess();
            }
        }
        else
        {
            PuzzleFailure();
        }
    }

    // Do this when the player solves the puzzle.
    public void PuzzleSuccess()
    {
        puzzleSolved = true;
        doorKey.OpenDoor();
        waypointController.ActiveWaypointKey();
        puzzleSpheres[0].transform.parent.gameObject.SetActive(false);
    }

    // Do this when the player selects the wrong sphere.
    public void PuzzleFailure()
    {
        failAudioHolder.GetComponent<AudioSource>().Play();
        currentSolveIndex = 0;
        StartPuzzle();
    }
}
