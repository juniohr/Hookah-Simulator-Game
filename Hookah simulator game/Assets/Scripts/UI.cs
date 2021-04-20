using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class UI : MonoBehaviour
{
    public GameObject fecharUI;
    public GameObject rosh;
    public GameObject vazo;
    public GameObject stem;
    public List<GameObject> Roshs = new List<GameObject>();
    public List<GameObject> Stems = new List<GameObject>();
    public List<GameObject> Vazos = new List<GameObject>();
    public Transform instanciarRosh;
    public Transform instanciarStem;
    public Transform instanciarVazo;
    public Transform instanciarCarvao;
    public Transform instanciarFumaça;
    public Transform instanciarBolinha;
    public GameObject[] prefabFumaça;
    public GameObject[] objsNaCena;
    public Button[] botoesInterativos;
    public float nivelDeFumaca;
    public bool pressionandoOuSoltando;
    public GameObject verificarSeEstaPuxando;
    public GameObject verificarMangueira;
    public GameObject prefabBolinha;
    private AudioSource puxe;
    public AudioClip Puxar;
    public AudioClip soltar;
    public GameObject video;

    public static UI inst;
    void Start()
    {
        inst = this;
        puxe = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (pressionandoOuSoltando)
        {
            Debug.Log(nivelDeFumaca);
            nivelDeFumaca += Time.fixedDeltaTime;
        }

        /* if (objsNaCena[1] != null)
         {
             botoesInterativos[1].interactable = true;

             for (byte i = 0; i < paiDosBotoesStem.transform.childCount; i++)
             {
                 filhosdoRosh[i] = paiDosBotoesRosh.transform.GetChild(i).gameObject;
                 filhosdoRosh[i].SetActive(true);
             }
         }

         if (objsNaCena[2] != null)
         {
             botoesInterativos[2].interactable = true;

             for (byte i = 0; i < paiDosBotoesStem.transform.childCount; i++)
             {
                 filhosdoStem[i] = paiDosBotoesStem.transform.GetChild(i).gameObject;
                 filhosdoStem[i].SetActive(true);
             }
         }*/
    }

    public void FecharUI()
    {
        fecharUI.SetActive(false);
        botoesInterativos[1].interactable = true;

        if (objsNaCena[3] != null)
        {
            botoesInterativos[0].interactable = false;
        }
        else if (objsNaCena[0] && objsNaCena[1] && objsNaCena[2] != null && fecharUI.activeInHierarchy == false)
        {
            botoesInterativos[0].interactable = true;
            Propagandas.instancia.Teste();
        }

    }

    public void Rosh()
    {
        rosh.SetActive(true);
        vazo.SetActive(false);
        stem.SetActive(false);
    }

    public void Vazo()
    {
        vazo.SetActive(true);
        rosh.SetActive(false);
        stem.SetActive(false);
    }

    public void Stem()
    {
        stem.SetActive(true);
        rosh.SetActive(false);
        vazo.SetActive(false);
    }

    public void InstanciarRosh(int index)
    {
        if (objsNaCena[0] == null)
        {
            Instantiate(Roshs[index], instanciarRosh.position, Quaternion.identity);
        }
        else
        {
            Destroy(objsNaCena[0]);
            Instantiate(Roshs[index], instanciarRosh.position, Quaternion.identity);
        }
    }

    public void InstanciarStem(int index)
    {
        if (objsNaCena[1] == null)
        {
            Instantiate(Roshs[index], instanciarStem.position, Quaternion.identity);
        }
        else
        {
            Destroy(objsNaCena[1]);
            Instantiate(Roshs[index], instanciarStem.position, Quaternion.identity);
        }
    }

    public void InstanciarVazo(int index)
    {
        if (objsNaCena[2] == null)
        {
            Instantiate(Roshs[index], instanciarVazo.position, Quaternion.identity);
        }
        else
        {
            Destroy(objsNaCena[2]);
            Instantiate(Roshs[index], instanciarVazo.position, Quaternion.identity);
        }
    }

    public void Carvao(int index)
    {
        if (objsNaCena[3] == null)
        {
            Instantiate(Roshs[index], instanciarCarvao.position, Quaternion.Euler(0, -24, -90));
            verificarSeEstaPuxando.SetActive(true);
        }
        else
        {
            Destroy(objsNaCena[3]);
            Instantiate(Roshs[index], instanciarCarvao.position, Quaternion.Euler(0, -24, -90));
            verificarSeEstaPuxando.SetActive(true);
        }

        verificarMangueira.SetActive(true);
        botoesInterativos[1].interactable = false;
        botoesInterativos[0].interactable = false;
        video.SetActive(true);
    }

    public void AbrirMenu()
    {
        fecharUI.SetActive(true);
        botoesInterativos[1].interactable = false;
    }

    public void PuxarFumaca()
    {
        pressionandoOuSoltando = true;
        puxe.clip = Puxar;
        puxe.Play();
    }
    public void PuxarFumaca2()
    {
        pressionandoOuSoltando = false;
        botoesInterativos[2].interactable = true;
        puxe.Stop();
        puxe.clip = soltar;
        puxe.Play();

        if (objsNaCena[4] == null)
        {
            if (nivelDeFumaca != 0 && nivelDeFumaca <= 1)
            {
                Instantiate(prefabFumaça[0], instanciarFumaça.position, Quaternion.identity);
            }
            else if (nivelDeFumaca > 1 && nivelDeFumaca <= 2)
            {
                Instantiate(prefabFumaça[1], instanciarFumaça.position, Quaternion.identity);
            }
            else if (nivelDeFumaca > 2)
            {
                Instantiate(prefabFumaça[2], instanciarFumaça.position, Quaternion.identity);
            }
        }
        else
        {
            Destroy(objsNaCena[4], 4);
            if (nivelDeFumaca != 0 && nivelDeFumaca <= 1)
            {
                Instantiate(prefabFumaça[0], instanciarFumaça.position, Quaternion.identity);
            }
            else if (nivelDeFumaca > 1 && nivelDeFumaca <= 2)
            {
                Instantiate(prefabFumaça[1], instanciarFumaça.position, Quaternion.identity);
            }
            else if (nivelDeFumaca >= 2)
            {
                Instantiate(prefabFumaça[2], instanciarFumaça.position, Quaternion.identity);
            }
        }
        nivelDeFumaca = 0;
        verificarSeEstaPuxando.SetActive(false);
        Invoke("VerificarSeEstaPuxando", 4);
    }

    public void VerificarSeEstaPuxando()
    {
        verificarSeEstaPuxando.SetActive(true);
        botoesInterativos[2].interactable = false;
    }

    public void SoltarBolinha()
    {
        Instantiate(prefabBolinha, instanciarBolinha.position, Quaternion.identity);
    }

    public void Video()
    {
        Propagandas.instancia.ShowRewardedVideo();
        video.SetActive(false);
    }
}
