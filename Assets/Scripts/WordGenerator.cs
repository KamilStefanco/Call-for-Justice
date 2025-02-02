using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour {
    public static int currentIndex = 0;
    private static bool hasBeenGenerated = false; // Nová premenná sledujúca, či už bol zoznam vygenerovaný
    private static string[] wordList = {"the", "town", "of", "pressburg", "found", "itself", "in", "danger", "after", "the", "discovery", "of", "a", "series", "of", "murders", "allegedly", "carried", "out", "by", "the", "local", "mafia", "the", "past", "few", "months", "have", "been", "affected", "by", "the", "discovery", "of", "victims", "who", "were", "brutally", "murdered", "and", "found", "in", "deserted", "places", "the", "investigation", "showed", "that", "the", "murders", "were", "part", "of", "planned", "actions", "aimed", "at", "sending", "a", "warning", "to", "rival", "gangs"};
	//private static string[] wordList = {"the", "town", "of", "lackova"};
    public static void ResetIndex() {
        currentIndex = 0;
        hasBeenGenerated = false; // Reset pri opätovnom generovaní
    }

	public static string GetRandomWord() {
		if (currentIndex >= wordList.Length) {
			hasBeenGenerated = true; // Označíme, že všetky slová boli vygenerované
			Debug.Log("All words have been generated.");
			return null;
		}

		string wordToReturn = wordList[currentIndex];
		Debug.Log($"Generating word: {wordToReturn}");
		currentIndex++;

		if (currentIndex >= wordList.Length) {
			hasBeenGenerated = true; // Označíme, že všetky slová boli vygenerované
			Debug.Log("No more words to generate.");
		}

		return wordToReturn;
	}
	public static bool HasBeenGenerated() {
		return currentIndex >= wordList.Length;
	}
}
