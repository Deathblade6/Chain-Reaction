using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Click : MonoBehaviour
{
    public GameObject atom;
    public int max;
    public int fill;
    public GameObject[] neib;
    public GameObject instu;

    public static int mode;
    public static int occ;

    public GameObject atom01;
    public GameObject atom02;
    public GameObject atom03;
    public GameObject atom04;
    public GameObject atom05;
    public GameObject atom06;

    public GameObject planeR;
    public GameObject planeG;

    public GameObject pp;
    public GameObject ee;

    public GameObject redd;
    public GameObject greeen;
    // Start is called before the first frame update
    void Start()
    {
        fill = 0;
        mode = 1;
        occ = 2;
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mode == 1)
            {
                if (this.tag == "Clickable" || this.tag == "Player")
                {
                    mode = 2;
                    planeG.SetActive(true);
                    planeR.SetActive(false);
                    Filling();
                    occ--;
                }
            }
            else if(mode == 2)
            {
                if (this.tag == "Clickable" || this.tag == "Enemy")
                {
                    mode = 1;
                    Filling2();
                    planeR.SetActive(true);
                    planeG.SetActive(false);
                    occ--;
                }
            }
            
        }
    }

    public void Filling()
    {
        fill++;
        this.tag = "Player";
        if (fill >= max)
        {
            fill = 0;
            Destroy(instu);
            this.tag = "Clickable";
            for (int i = 0; i < max; i++)
            {
                neib[i].GetComponent<Click>().Filling();
            }
        }
        else
        {
            if (fill == 1)
            {
                instu = (GameObject)Instantiate(atom01, transform.position, transform.rotation);
            }
            else if(fill == 2)
            {
                Destroy(instu);
                instu = (GameObject)Instantiate(atom02, transform.position, transform.rotation);
            }
            else if (fill == 3)
            {
                Destroy(instu);
                instu = (GameObject)Instantiate(atom03, transform.position, transform.rotation);
            }
            //instu[fill] = (GameObject)Instantiate(atom, transform.position, transform.rotation);
        }
    }

    public void Filling2()
    {
        fill++;
        this.tag = "Enemy";
        if (fill >= max)
        {
            fill = 0;
            Destroy(instu);
            this.tag = "Clickable";
            for (int i = 0; i < max; i++)
            {
                neib[i].GetComponent<Click>().Filling2();
            }
        }
        else
        {
            if (fill == 1)
            {
                instu = (GameObject)Instantiate(atom04, transform.position, transform.rotation);
            }
            else if (fill == 2)
            {
                Destroy(instu);
                instu = (GameObject)Instantiate(atom05, transform.position, transform.rotation);
            }
            else if (fill == 3)
            {
                Destroy(instu);
                instu = (GameObject)Instantiate(atom06, transform.position, transform.rotation);
            }
            //instu[fill] = (GameObject)Instantiate(atom, transform.position, transform.rotation);
        }
    }
    private void Update()
    {
        if (occ <= 0)
        {
            pp = GameObject.FindWithTag("Player");
            ee = GameObject.FindWithTag("Enemy");
            if (pp == null)
            {
                greeen.SetActive(true);
                if (Input.anyKey)
                {
                    SceneManager.LoadScene("05");
                }
                
            }
            if (ee == null)
            {
                redd.SetActive(true);
                if (Input.anyKey)
                {
                    SceneManager.LoadScene("05");
                }
            }
        }
    }
}
