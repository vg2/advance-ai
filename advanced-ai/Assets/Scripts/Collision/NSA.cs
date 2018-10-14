using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace AssemblyCSharp.Assets.Scripts.Collision
{
    public class NSA
    {
        public NSA()
        {
        }


        /*
         * This method is used to generate a list of valid Origami Robots 
         */

        private  void DetectorGeneration(OrigamiRobot[] robots, int detectorRadius, int team)
        {

            // a detector for each robot : number of dectors = number of robots  = repoitre size
            List<Vector3> validDetectors = null;
               
            int repoitreSize = robots.Length;
            // team variable used to generate self set 
            float [] selfRange = GenerateSelfSetRange(team, repoitreSize);
            
            // generate detectors equal to repotre size
            while(repoitreSize <=0){

                Vector3 dector = GenerateRandomDetector();

                //valid detector does not match self
                if(!matches(dector,selfRange ))
                {
                    validDetectors.Add(dector);
                    repoitreSize--;   
                }
                       
            }

            //for each robot set detector
            for (int i = 0; i < robots.Length; i++){
               // robots[i].setDetector(validDetectors[i]);
            }
           

         
        }

        private Boolean NonSelfDetection(OrigamiRobot self, OrigamiRobot other) // other is the sample
        {
            
           
          // TODO these new vectors should be the valid detectors a value to be put in robot?  
            if (MatchingRule.EuclideanDistance(new Vector3(1,2,3), new Vector3(1,2,3) ) < 0.5 )
            {
                return false; 
            }
            else
            {
                return true;
            }
        }
        
        
        private Vector3 GenerateRandomDetector()
        {
            return  new Vector3(UnityEngine.Random.Range(0.1f, 0.5f), UnityEngine.Random.Range(position.y - scale.y, position.y + scale.y), UnityEngine.Random.Range(position.z + scale.z, position.z - scale.z));
        }
        
        private Boolean matches(Vector3 dector, float[] self)
        {
            
            //TODO
            return false;  
        }
        
        
        private float [] GenerateSelfSetRange(int team, int size){

            float lowerBound = 0f;
            float upperBound  = 0f;

            if (team == 1)
            {
                lowerBound = 0.1f;
                upperBound = 0.5f;
            }else{
                lowerBound = 0.6f;
                upperBound = 1f;
            }
           
            return new float[] {lowerBound, upperBound };
        }
    }


}