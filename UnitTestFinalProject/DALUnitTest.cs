using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProject;
using System.Collections.Generic;
namespace UnitTestFinalProject
{
    /**
     * Unit Test for dadabase access layers.
     */
    [TestClass]
    public class DBLayersUnitTest
    {
        /**
         * Test the PatientExist method with non existed id of patient
         * Result should be false
        */
        [TestMethod]
        public void FalsePatientExistTest()
        {
            bool result = MainBL.patientExistByTestName("000");
                 bool expected = false;
            Assert.AreEqual(expected, result);

        }
        /**
         * Test the GetGene method with non existed gene
         * Result should be null
         */
        [TestMethod]
        public void GetGeneThatNotExistTest()
        {
            Gene g = MainBL.getGene("TestGeneName", "TestChrom");
            bool result = (g == null);
            bool expected = true;
            Assert.AreEqual(expected, result);

        }
        /**
         * Test the AddGene method by adding new gene and check if is exist
         * Result should not be null
         */
        [TestMethod]
        public void AddGeneTest()
        {
            MainBL.addGene("PIK3CA", "chr3");
            Gene g = MainBL.getGene("PIK3CA", "chr3");
            bool result = (g != null);
            bool expected = true;
            Assert.AreEqual(expected, result);
        }

        /*
         * Test the GetCosmicDetails method with non existed mutation
         * Result should be null
         */
        [TestMethod]
        public void FalseGetCosmicDetailsTest()
        {
            List<string> sl = MainBL.getCosmicDetails("25", 0, 'A', 'A');
            bool result = (sl == null);
            bool expected = true;
            Assert.AreEqual(expected, result);
        }
        /*
         * Test the GetCosmicDetails method with existed mutation
         * Result should not be null
         */
        [TestMethod]
        public void GetCosmicDetailsTest()
        {
            List<string> sl = MainBL.getCosmicDetails("3", 178952085, 'A', 'G');
            bool result = (sl != null);
            bool expected = true;
            Assert.AreEqual(expected, result);
        }
        /*
         * Test the NumOfPatientWithSameMutation method with non existed id
         * Result should be 0
         */
        [TestMethod]
        public void NumOfPatientWithSameMutationTest()
        {
            int result = MainBL.getNumOfPatientWithSameMutation("0");
            int expected = 0;
            Assert.AreEqual(expected, result);
        }
    }
}
