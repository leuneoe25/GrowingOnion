using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ExistingDBScript : MonoBehaviour {

	public TMP_Text text;

	// Use this for initialization
	void Start () {
		var ds = new DataService ("Onions.db");
		//ds.CreateDB ();
		var people = ds.GetOnions();
		ToConsole (people);

		//people = ds.GetPersonsNamedRoberto ();
		//ToConsole("Searching for Roberto ...");
		//ToConsole (people);

		//ds.CreatePerson ();
		//ToConsole("New person has been created");
		//var p = ds.GetJohnny ();
		//ToConsole(p.ToString());
	}
	
	private void ToConsole(IEnumerable<Person> people){
		foreach (var person in people) {
			ToConsole(person.ToString());
		}
	}
    private void ToConsole(IEnumerable<Onion> people)
    {
        foreach (var person in people)
        {
            ToConsole(person.ToString());
        }
    }

    private void ToConsole(string msg){
        text.text += System.Environment.NewLine + msg;
		Debug.Log (msg);
	}

}
