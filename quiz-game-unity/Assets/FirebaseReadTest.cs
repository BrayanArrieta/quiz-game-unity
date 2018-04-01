using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;
public class FirebaseReadTest: MonoBehaviour {
	void Start() {
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://quiz-game-unity.firebaseio.com/");;
		// Set up the Editor before calling into the realtime database.
		FirebaseApp.LogLevel = LogLevel.Verbose;
		FirebaseDatabase.DefaultInstance.LogLevel = LogLevel.Verbose;
		// Get the root reference location of the database.
		DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("Users");
	}
}