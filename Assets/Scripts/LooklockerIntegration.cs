using System.Collections;
using UnityEngine;
using LootLocker.Requests;

public class LooklockerIntegration : MonoBehaviour {

    readonly int leaderboardId = 7518;
    void Start() {
        StartCoroutine(ConnectToLootLocker());
    }

    IEnumerator ConnectToLootLocker(){
        bool requestComplete = false;

        LootLockerSDKManager.StartGuestSession((response) => {
            if(response.success) {
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                requestComplete = true;
            }

            if (!response.success) {
                Debug.Log("error starting LootLocker session"); 
                return;
            }

            Debug.Log("successfully started LootLocker session");
        });
        yield return new WaitWhile(() => requestComplete == false);
    }
    public IEnumerator SubmitScore(){
        bool done = false;
        // LootLockerSDKManager.SubmitScore(PlayerPrefs.GetString("PlayerID"));
        yield return new WaitWhile(() => done == false);
    }

}
