using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class RunnerTriggerFact : MonoBehaviour
{
    public RunnerFacts[] runnerFacts;
    private static List<RunnerFacts> undisplayedFacts;
    private RunnerFacts currentFact;

    [SerializeField]
    private GameObject uiObject;
    [SerializeField]
    private float hideFactUI = 1;
    [SerializeField]
    public Text factText;


    void Start()
    {
        if (undisplayedFacts == null || undisplayedFacts.Count == 0)
        {
            undisplayedFacts = runnerFacts.ToList<RunnerFacts>();
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 1;
        }
    }

    void SetFact()
    {
        int randomFactIndex = Random.Range(0, undisplayedFacts.Count);
        currentFact = undisplayedFacts[randomFactIndex];

        factText.text = currentFact.runnerFact;
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Fact")
        {
            FindObjectOfType<SoundManager>().Play("LearnSound");
            Time.timeScale = 0;
            SetFact();
            uiObject.SetActive(true);

            StartCoroutine(HideFact());
        }
    }
    
    IEnumerator HideFact()
    {
        //undisplayedFacts.Remove(currentFact);

        yield return new WaitForSeconds(hideFactUI);
        uiObject.SetActive(false);
    }
}
