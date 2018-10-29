using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;
using Assets.Scripts;

/*
 * Author: Siphesihle Sithungu, Anthony Kolenic, Martin Messe
 * Description: This class represents an Origami Robot.
 * A robot is an array of triangles.
 */
public class OrigamiRobot
{
    private Triangle[] parts;

    private Vector3 position;
    private Vector3 orientation;
    private Team team;
    public int fitness = 1000;
    private int numParts;
    private Boolean centreFound;
    private Vector3 centre;

    private GameObject tile;

    public OrigamiRobot(Team team, int numParts, GameObject tile)
    {
        this.numParts = numParts;
        centreFound = false;
        this.team = team; //the robot's team or colony.
        this.tile = tile;

        parts = new Triangle[numParts]; //initial number of triangles the robot is made up of.
        position = tile.transform.position; //inital robot's position.
        InitializeParts();
    }

    /*
	 * Calculate the centre of a robot based on its position
	 */
    public Vector3 GetCentre()
    {
        if (!centreFound)
        {
            //initiliaze values 
            int numTriangles = parts.Length;
            float x = 0;
            float y = 0;
            float z = 0;
            int i = 0;

            //calculate total for all triangles
            for (i = 0; i < numTriangles;i++)
            {
                List<Vector3> triangles = parts[i].GetVertices();
                Vector3 triA = triangles[0];
                Vector3 triB = triangles[1];
                Vector3 triC = triangles[2];
                x += triA.x + triB.x + triC.x;
                y += triA.y + triB.y + triC.y;
                z += triA.z + triB.z + triC.z;
            }

            //Calculate Average 
            x = x / numTriangles;
            y = y / numTriangles;
            z = z / numTriangles;

            //set centre 
            centreFound = true;
            centre = new Vector3(x, y, z);
        }
        return centre;
    }

    /*
     * This function initializes the triangles by assigning values to their vertices.
     * The method also ensures that the vertices are within one hexagon/tile representing the robot's position.
     */
    private void InitializeParts()
    {
        //This lists stores triangles that still have "vacant" sides for new triangles to link to.
        List<Triangle> candidateLinks = new List<Triangle>();

        int numPartsGenerated = 0; //Keeps track of the number of parts generated so far.

        Triangle t = RandTriangle(); //Generate the first triangle.
        parts[0] = t; //Add the new triangle to the parts array.
        numPartsGenerated++;
        candidateLinks.Add(t); //The new triangle is now a candidate link.
        //--Generate the rest of the parts.--//
        while (numPartsGenerated < numParts && candidateLinks.Count > 0)
        {
            int rMySide = UnityEngine.Random.Range(0, 3); //The side the new triangle is going to use to form a link.
            Triangle temp = RandTriangle(); //Generate a triangle with random vertices.
            int rIndex = UnityEngine.Random.Range(0, candidateLinks.Count); //Pick a random triangle from from the list of candidate links.
            candidateLinks[rIndex].LinkNeighbour(temp, rMySide + 1);

            parts[numPartsGenerated] = temp;
            candidateLinks.Add(temp);
            UpdateCandidateLinks(candidateLinks);//Remove triangles that have no vacant sides anymore.
            numPartsGenerated++;
        }
    }
	
	/*
	 * This function returns the robot's rotation.
	 */
	public Vector3 GetRotation()
	{
        return new Vector3(0,0,0);
	}
	
	/*
	 * This function returns the robot's position.
	 */
	public Vector3 GetPosition()
	{
        return new Vector3(0,0,0);
	}

    public GameObject GetRobotTile()
    {
        return this.tile;
    }

    public Transform GetRobotTransformProperties()
    {
        return this.tile.transform;
    }
		
    //--Function for generating a triangle with random vertices.--//
    private Triangle RandTriangle()
    {
        return Triangle.GenerateRandomTriangle(tile.transform, position);
    }

    //--This function removes Triangles that no longer have vacant sides from candidate links.--//
    private void UpdateCandidateLinks(List<Triangle> candidateLinks)
    {
        for (int i = 0; i < candidateLinks.Count; i++)
        {
            if (candidateLinks[i].GetVacantSides().Count == 0)
            {
                candidateLinks.RemoveAt(i);
            }
        }
    }

	/*
	 * The following function returns the links between the triangles.
	 * Each key is a triangle belonging to the robot. Each value is a list of the triangle's neighbours.
	 */
    public Dictionary<Triangle, List<Triangle>> GetLinks()
    {
        Dictionary<Triangle, List<Triangle>> pairs = new Dictionary<Triangle, List<Triangle>>();
        for (int i = 0; i < parts.Length; i++)
        {
            List<Triangle> neighbours = new List<Triangle>();
            foreach(Triangle n in parts[i].GetNeighbours())
            {
                neighbours.Add(n);
            }
            pairs.Add(parts[i], neighbours);
        }
        return pairs;
    }

    public void SetBody(Triangle[] bodyProperties)
    {
        this.parts = bodyProperties;
        centreFound = false;
    }

    public void setPosition(Vector3 position)
    {
        this.position = position;
    }

    public Triangle[] getBody()
    {
        return parts;
    }

    public Team GetTeam()
    {
        return team;
    }

    public void SetTeam(Team team)
    {
        this.team = team;
    }

    public int GetNumParts()
    {
        return numParts;
    }

    public void SetNumParts(int numParts)
    {
        this.numParts = numParts;
    }
}