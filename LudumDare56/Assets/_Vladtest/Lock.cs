using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lock : MonoBehaviour
{
	private int N1, N2, N3, N4, PN1, PN2, PN3, PN4;
	private int CurentNumber = 1;
	public TextMeshProUGUI TN1, TN2, TN3, TN4;
	public TextMeshProUGUI TNP1, TNP2, TNP3, TNP4;
	public Animator polka;
	
	
	public AudioSource audioSource;
	public AudioSource audioSource2;
    void Start()
    {
	    SetDefault();
        PN1 = -1;
		PN2 = -1;
		PN3 = -1;
		PN4 = -1;
		N1 = Random.Range(0, 9);
		N2 = Random.Range(0 ,9);
		N3 = Random.Range(0, 9);
		N4 = Random.Range(0, 9);
		TNP1.text = N1.ToString();
		TNP2.text = N2.ToString();
		TNP3.text = N3.ToString();
		TNP4.text = N4.ToString();
		Debug.Log(N1.ToString() + "  " + N2.ToString() + "  " + N3.ToString() + "  " + N4.ToString());
    }

    public void EnterNumber(Key key)
    {
	    switch(CurentNumber)
	    {
		    case 1:
		    {
			    TN1.text = key.Value.ToString();
			    PN1 = key.Value;
			    CurentNumber++;
			    return;
		    }
		    case 2:
		    {
			    TN2.text = key.Value.ToString();
			    PN2 = key.Value;
			    CurentNumber++;
			    return;
		    }
		    case 3:
		    {
			    TN3.text = key.Value.ToString();
			    PN3 = key.Value;
			    CurentNumber++;
			    return;
		    }
		    case 4:
		    {
			    TN4.text = key.Value.ToString();
			    PN4 = key.Value;
			    CurentNumber++;
			    return;
		    }
		    case 5:
		    {
			    return;
		    }
	    }
    }

    public void SetDefault()
    {
	    TN4.text = "0";
	    TN3.text = "0";
	    TN2.text = "0";
	    TN1.text = "0";
	    PN1 = 0;
	    PN2 = 0;
	    PN3 = 0;
	    PN4 = 0;
	    CurentNumber = 1;
    }
    public void OpenLock()
    {
	    //когда открою замочек
	    Debug.Log("Ультра харошь");
	    audioSource.Play();
	    polka.SetBool("IsOpen", true);
    }

    public bool IsPasswordCorrect()
    {
	    if(PN1 == N1 && PN2 == N2 && PN3 == N3 && PN4 == N4)
		{
			return true;
		}
	    else
	    {
		    return false;
	    }
	}
    void Update()
    {
        
    }
}
