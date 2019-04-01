using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe responsável por controlar o Enigma.
 */
public class EnigmaController : MonoBehaviour
{
    public Door doorKey;
    public float puzzleSpeed = 1f;
    public GameObject[] puzzleSpheres;
    public GameObject failAudioHolder;
    public WaypointController waypointController;

    private int[] puzzleOrder;
    private bool puzzleSolved = false;
    private int currentSolveIndex = 0;
    private int currentDisplayIndex = 0;

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

    /**
     * Aguarda 1 segundo, antes do Enigma iniciar.
     */
    public IEnumerator StartPuzzleAfterOneSecond()
    {
        yield return new WaitForSeconds (1);
        StartPuzzle();
    }

    /**
     * Prepara o Enigma.
     */
    public void PreparePuzzle()
    {
        StartCoroutine(StartPuzzleAfterOneSecond());
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
            SetActiveColliderOrbs(false);
        }
    }

    // Reset the puzzle sequence.
    public void ResetPuzzle()
    {
        GeneratePuzzleSequence();
    }

    // Disaplay the
    // Called from StartPuzzle() and invoked repeatingly.
    public void DisplayPattern()
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
            SetActiveColliderOrbs(true);
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

    /**
     * Ativa o Waypoint que dá acesso à sala da Chave e inativa o Enigma.
     */
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

    /**
     * Método Start.
     */
    private void Start()
    {
        puzzleOrder = new int[puzzleSpheres.Length];
        GeneratePuzzleSequence();
        SetActiveColliderOrbs(false);
    }

    /**
     * Ativa/inativa o componente "Collider" dos Orbs.
     */
    private void SetActiveColliderOrbs(bool active)
    {
        foreach (var orb in puzzleSpheres)
        {
            orb.GetComponent<SphereCollider>().enabled = active;
        }
    }
}
