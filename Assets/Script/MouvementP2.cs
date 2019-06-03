using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementP2 : MonoBehaviour {


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
        Deplacer_Personnage2();
    }

    private void Deplacer_Personnage2()
    {
        // Récupération des Inputs
        float rotation = Input.GetAxis("Horizontal P2") * vitesse_rotation;
        float deplacement = Input.GetAxis("Vertical P2") * vitesse;

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

        // Réassignation des paramètres (avec detection des collisions)
        cube.MoveRotation(Quaternion.AngleAxis(angle, Vector3.up));
        cube.MovePosition(cube.transform.position + dep);
    }
}
