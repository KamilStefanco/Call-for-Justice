using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class WordManager : MonoBehaviour {

	public List<Word> words;

	public WordSpawner wordSpawner;

	private bool hasActiveWord;
	private Word activeWord;

	public LevelLoader levelLoader;

    public void AddWord() {
        string randomWord = WordGenerator.GetRandomWord();
        if (randomWord != null) { // Ak ešte máme slová na generovanie
            Word word = new Word(randomWord, wordSpawner.SpawnWord());
            words.Add(word);
        }
    }

	public void TypeLetter(char letter) {
		if (hasActiveWord) {
			// Overenie, či aktívne slovo obsahuje ďalšie písmeno na typovanie
			if (activeWord.GetNextLetter() == letter) {
				activeWord.TypeLetter();
				// Ak bolo slovo napísané (a teda odstránené), aktualizujeme stav
				if (activeWord.WordTyped()) {
					hasActiveWord = false; // Resetujeme stav aktívneho slova
					words.Remove(activeWord); // Odstránime slovo zo zoznamu
					CheckForWin(); // Skontrolujeme, či sme vyhrali
				}
			}
		} else {
			foreach (Word word in words) {
				if (word.GetNextLetter() == letter) {
					activeWord = word;
					hasActiveWord = true;
					word.TypeLetter();
					// Okamžite kontrolujeme, či bolo slovo napísané, ak obsahuje len jedno písmeno
					if (activeWord.WordTyped()) {
						hasActiveWord = false; // Resetujeme stav aktívneho slova
						words.Remove(activeWord); // Odstránime slovo zo zoznamu
						CheckForWin(); // Skontrolujeme, či sme vyhrali
					}
					break; // Prestaneme hľadať ďalšie slovo, keďže sme našli zhodu
				}
			}
		}
	}

	void CheckForWin() {
		Debug.Log($"Checking for win. Words left: {words.Count}, All Generated: {WordGenerator.HasBeenGenerated()}");
		if (words.Count == 0 && WordGenerator.HasBeenGenerated()) {
			Debug.Log("Win");
			// Ukončenie hry alebo načítanie výherné scény
				levelLoader.LoadNextLevel("office 2");
		}
	}

}
