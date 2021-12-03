using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Opciones Generales")]
    [SerializeField] GameObject pantallaMenu;
    [SerializeField] GameObject pantallaOpciones;
    [SerializeField] float tiempoCambiaOpcion;


    [Header("Elementos menu")]
    [SerializeField] SpriteRenderer comenzar;
    [SerializeField] SpriteRenderer opciones;
    [SerializeField] SpriteRenderer salir;


    [Header("Sprites menu")]
    [SerializeField] Sprite comenzar_off;
    [SerializeField] Sprite comenzar_on;
    [SerializeField] Sprite opciones_off;
    [SerializeField] Sprite opciones_on;
    [SerializeField] Sprite salir_off;
    [SerializeField] Sprite salir_on;

    [Header("Sprites menu")]
    [SerializeField] AudioSource snd_opcion;
    [SerializeField] AudioSource snd_seleccion;

    int pantalla;
    int opcionMenu, opcionMenuAnt;
    int opcionOpciones, opcionOpcionesAnt;
    bool pulsadoSubmit;
    float v, h;
    float tiempoV, tiempoH;
 

    void Awake()
    {
        pantalla = 0;
        tiempoV = tiempoH = 0;
        opcionMenu = opcionMenuAnt = 1;
       // opcionOpciones = opcionOpcionesAnt = 1;
        AjustaOpciones();
        
    }

    private void AjustaOpciones()
    {
        
    }

    void Update()
    {
        v = Input.GetAxisRaw("Vertical");

        if (v > 0.25F) v = 1;
        else if (v < -0.25F) v = -1;
        else v = 0;

        h = Input.GetAxisRaw("Horizontal");
        if (h > 0.25F) h = 1;
        else if (h < -0.25F) h = -1;
        else h = 0;


        if (Input.GetButtonUp("Submit")) pulsadoSubmit = false;
        if (v == 0) tiempoV = 0;
        if (pantalla == 0) MenuPrincipal();
        if (pantalla == 1) MenuOpciones();
    }

    private void MenuOpciones()
    {
        if (v != 0)
        {
            if (tiempoV == 0 || tiempoV > tiempoCambiaOpcion)
            {
                if (v == 1 && opcionOpciones> 1) SeleccionOpcion(opcionOpciones - 1);
                if (v == -1 && opcionOpciones < 3) SeleccionOpcion(opcionOpciones + 1);
                if (tiempoV > tiempoCambiaOpcion) tiempoV = 0;
            }
            tiempoV += Time.deltaTime;
        }
   

        SceneManager.LoadScene("Creditos");
    }

    void MenuPrincipal()
    {
        if (v != 0)
        {
            if (tiempoV == 0 || tiempoV > tiempoCambiaOpcion)
            {
                if (v == 1 && opcionMenu > 1) SeleccionMenu(opcionMenu - 1);
                if (v == -1 && opcionMenu < 3) SeleccionMenu(opcionMenu + 1);
                if (tiempoV > tiempoCambiaOpcion) tiempoV = 0;
            }
            tiempoV += Time.deltaTime;
        }
        if (Input.GetButtonDown("Submit") && !pulsadoSubmit)
        {
            snd_seleccion.Play();
            if (opcionMenu == 1) SceneManager.LoadScene("SampleScene");
            if (opcionMenu == 2) CargaPantallaOpciones();
            if (opcionMenu == 3) Application.Quit(); 
        }
    }

    private void CargaPantallaOpciones()
    {
        SceneManager.LoadScene("Creditos");
    }

    void SeleccionMenu(int op)
    {
        snd_opcion.Play();
        opcionMenu = op;
        if (op == 1) comenzar.sprite = comenzar_on;
        if (op == 2) opciones.sprite = opciones_on;
        if (op == 3) salir.sprite = salir_on;
        if (opcionMenuAnt == 1) comenzar.sprite = comenzar_off;
        if (opcionMenuAnt == 2) opciones.sprite = opciones_off;
        if (opcionMenuAnt == 3) salir.sprite = salir_off;
        opcionMenuAnt = op;

    }
    void SeleccionOpcion(int op)
    {
        snd_opcion.Play();
        opcionOpciones = op;
        if (op == 1) comenzar.sprite = comenzar_on;
        if (op == 2) opciones.sprite = opciones_on;
        if (op == 3) salir.sprite = salir_on;
        if (opcionMenuAnt == 1) comenzar.sprite = comenzar_off;
        if (opcionMenuAnt == 2) opciones.sprite = opciones_off;
        if (opcionMenuAnt == 3) salir.sprite = salir_off;
        opcionMenuAnt = op;

    }
}
