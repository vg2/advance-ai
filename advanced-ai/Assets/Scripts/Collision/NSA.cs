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
            float [] selfRange = GenerateSelfSetRange(team);
            
            // generate detectors equal to repotre size
            while(repoitreSize > 0){

                Vector3 dector = GenerateRandomDetector(selfRange);

                //valid detector does not match self
                if(!matches(dector,selfRange ))
                {
                    validDetectors.Add(dector);
                    repoitreSize--;   
                }
                       
            }

            //for each robot set detector
            for (int i = 0; i < robots.Length; i++){
               robots[i].SetDetector(validDetectors[i]);
            }
           
            
         
        }

        public static Boolean NonSelfDetection(OrigamiRobot self, OrigamiRobot other) // other is the sample
        {
            
           
          // TODO - decide on threshold currently at 0.5  
            if (MatchingRule.EuclideanDistance(self.GetDetector(), other.GetDetector()) < 0.5 )
            {
                // self
                return true; 
            }
            else
            {
                //non self
                return false;
            }
        }
        
        
        private Vector3 GenerateRandomDetector(float [] range)
        {
           
            return  new Vector3(UnityEngine.Random.Range(range[0], range[1]), UnityEngine.Random.Range(range[0], range[1]), UnityEngine.Random.Range(range[0], range[1]));
        }
        
        private Boolean matches(Vector3 detector, float[] self)
        {

            //TODO

            float xpos = detector.x;
            float ypos = detector.y;
           
            if((xpos <= self[1] && xpos >= self[0] ) && (ypos <= self[1] && ypos >= self[0])) 
            {
                return true;
            }
            else{
                return false;
            }
        }
        
        
        private float [] GenerateSelfSetRange(int team)
        {

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