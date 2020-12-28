using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hivemind{
    public enum Ingredient_ID{
        Egg,
        Noodles,
        Chicken,
        Broth,
        GreenOnion
    }

    public class Spawner : MonoBehaviour
    {
        public int next_ing;
        public Ingredient_ID[] ids_needed;
        public GameObject[] ingredients;
        public Vector2[] track_starts;

        private float time_elapsed = 0.0f;

        //private dummy variables for now
        private int curr_track = 0;
        private int curr_ing = 0;

        // Update is called once per frame
        void Update()
        {
            if(time_elapsed > 0.2f){
                time_elapsed = 0.0f;
                //do some extra randomization later
                GameObject objToSpawn = ingredients[(int)(ids_needed[next_ing])];
                Vector2 trackToSpawnOn = track_starts[curr_track];
                Debug.Log($"Spawning ingredient { objToSpawn } on track { trackToSpawnOn }...");
                Instantiate(objToSpawn, trackToSpawnOn, Quaternion.identity);
                curr_track = (curr_track + 1) % 3;
                curr_ing = (curr_ing + 1) % 5;
            }
            time_elapsed += Time.deltaTime;
        }

        public void NextIng(){
            Debug.Log($"NextIng() called: should move onto next ingredient ({ ingredients[(int)(ids_needed[next_ing])] })...");
            //play success noise
            next_ing++;
            if(next_ing == 6){
                MinigameManager.Instance.minigame.gameWin = true;
            }
	    }
    }
}