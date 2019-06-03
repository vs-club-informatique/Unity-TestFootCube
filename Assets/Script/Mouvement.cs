using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{

    Rigidbody cube;

    public float vitesse = 1;
    public float vitesse_rotation = 3;
    float converter = Mathf.PI / 180;

    

    // Use this for initialization
    void Start ()
    {
        cube = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        //Deplacer_Personnage();
        Deplacer_Personnage2();
    }


    private void Deplacer_Personnage()
    {
        // Récupération des Inputs
        float rotation = Input.GetAxis("Horizontal") * vitesse_rotation;
        float deplacement = Input.GetAxis("Vertical") * vitesse;
        float jump = Input.GetAxis("Jump") * vitesse;

        // Récupération de l'angle actuel de rotation
        float angle = 0;
        Vector3 axis = new Vector3();
        cube.transform.rotation.ToAngleAxis(out angle, out axis);

        // Modification de l'angle de rotation
        angle = (360 + angle + rotation) % 360;

        // Calcul du déplacement selon les axes
        float depz = deplacement * Mathf.Cos(angle * converter);
        float depx = deplacement * Mathf.Sin(angle * converter);

        // Création du vecteur de déplacement
        Vector3 dep = new Vector3(depx, 0, depz);

        // Réassignation des paramètres
        cube.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        cube.transform.position = cube.transform.position + dep;
    }

    private void Deplacer_Personnage2()
    {
        // Récupération des Inputs
        float rotation = Input.GetAxis("Horizontal") * vitesse_rotation;
        float deplacement = Input.GetAxis("Vertical") * vitesse;
        float jump = Input.GetAxis("Jump") * 20;

        // Récupération de l'angle actuel de rotation
        float angle = 0;
        Vector3 axis = new Vector3();
        cube.transform.rotation.ToAngleAxis(out angle, out axis);

        // Modification de l'angle de rotation
        angle = (360 + angle + rotation) % 360;

        // Calcul du déplacement selon les axes
        float depz = deplacement * Mathf.Cos(angle * converter);
        float depx = deplacement * Mathf.Sin(angle * converter);

        // Création du vecteur de déplacement
        Vector3 dep = new Vector3(depx, jump, depz);

		//cube.velocity = new Vector3(depx, jump, depz);
        // Réassignation des paramètres (avec detection des collisions)
        cube.MoveRotation(Quaternion.AngleAxis(angle, Vector3.up));
        cube.MovePosition(cube.transform.position + dep);
    }
}
