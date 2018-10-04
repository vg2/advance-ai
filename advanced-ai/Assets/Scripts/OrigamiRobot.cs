using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

public class OrigamiRobot
{
    private Triangle[] parts;

    private Vector3 position;
    private Vector3 orientation;

    private int team;
    public int fitness = 1000;
    private int numParts;

    private Transform tileInfo;

    public OrigamiRobot(int team, int numParts, Transform tileInfo)
    {
        this.team = team; //the robot's team or colony.
        this.tileInfo = tileInfo;
        parts = new Triangle[numParts]; //initial number of triangles the robot is made up of.
        position = tileInfo.position; //inital robot's position.
        InitializeParts();
    }

    /*
     * This function initializes the triangles by setting their vertices.
     * The method also ensures that the vertices are within the hexagon
     * representing the robot's position.
     */
    private void InitializeParts()
    {
        /*
         * This lists stores triangles that still have "vacant" sides
         * for new triangles to link to.
         */
        List<Triangle> candidateLinks = new List<Triangle>();
        int numPartsGenerated = 0; //Keeps track of the number of parts generated so far.

        //---Generate the first triangle using the tile info.---//
        Vector3 scale = tileInfo.localScale;
        Vector3 vertexA = new Vector3(UnityEngine.Random.Range(position.x - scale.x, position.x + scale.x), UnityEngine.Random.Range(position.y - scale.y, position.y + scale.y), Random.Range(position.z + scale.z, position.z - scale.z));
        Vector3 vertexB = new Vector3(UnityEngine.Random.Range(position.x - scale.x, position.x + scale.x), UnityEngine.Random.Range(position.y - scale.y, position.y + scale.y), Random.Range(position.z + scale.z, position.z - scale.z));
        Vector3 vertexC = new Vector3(UnityEngine.Random.Range(position.x - scale.x, position.x + scale.x), UnityEngine.Random.Range(position.y - scale.y, position.y + scale.y), Random.Range(position.z + scale.z, position.z - scale.z));
        Triangle t = new Triangle(vertexA, vertexB, vertexC);
        parts[0] = t;
        numPartsGenerated++;
        candidateLinks.Add(t);
        
        //--Generate the rest of the parts.--//
        while(numPartsGenerated < numParts)
        {
            int rIndex = UnityEngine.Random.Range(0, candidateLinks.Count); //Pick a random triangle from this list.
            int numVacantSides = VacantSides(candidateLinks[rIndex]);
            int rSide = UnityEngine.Random.Range(0, numVacantSides); //Pick a random side to extend/link to.

            switch (rSide)
            {
                case 0: //
                    vert
            }
            numPartsGenerated++;
        }
    }

    private int VacantSides(Triangle triangle)
    {
        throw new NotImplementedException();
    }

    public Dictionary<Triangle, List<Triangle>> getBodyMakeUp()
    {
        Dictionary<Triangle, List<Triangle>> pairs = new Dictionary<Triangle, List<Triangle>>();
        for (int i = 0; i < parts.Length; i++)
        {
            List<Triangle> neighbours = new List<Triangle>();
            for (int j = 0; j < parts.Length; i++)
            {

            }
        }

        return pairs;
    }

    /*
     * The following function returns the object's position in the game world.
     */
    public Vector3 getPosition()
    {
        return position;
    }

    public void setPosition(Vector3 position)
    {
        this.position = position;
    }

    public Triangle[] getBody()
    {
        return parts;
    }

    public int GetTeam()
    {
        return team;
    }

    public void SetTeam(int team)
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