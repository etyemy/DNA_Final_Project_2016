using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject
{
    /*
     * MainBL class.
     * Main purpose - Bussiness Logic Layer for both UCSC and local databases.
     * Check logic of queries data, rearrange the answers into competible data.
     * No documentation for each function - same as DAL classes.
     */
    public class MainBL
    {
        public static Mutation getMutationByDetails(string chrom, int position, char varNuc, char refNuc)
        {
            Mutation toReturn = null;
            try
            {
                List<String> mutationDetails = LocalDbDAL.getMutationByDetails(chrom, position, refNuc, varNuc);
                if (mutationDetails != null)
                {
                    string mutId = mutationDetails.ElementAt(0);
                    string tempChrom = mutationDetails.ElementAt(1);
                    int tempPosition = Convert.ToInt32(mutationDetails.ElementAt(2));
                    string tempGeneName = mutationDetails.ElementAt(3);
                    char tempRefNuc = Convert.ToChar(mutationDetails.ElementAt(4));
                    char tempVarNuc = Convert.ToChar(mutationDetails.ElementAt(5));
                    char tempStrand = Convert.ToChar(mutationDetails.ElementAt(6));
                    string tempChromNum = mutationDetails.ElementAt(7);
                    string tempRefCodon = mutationDetails.ElementAt(8);
                    string tempVarCodon = mutationDetails.ElementAt(9);
                    string tempRefAA = mutationDetails.ElementAt(10);
                    string tempVarAA = mutationDetails.ElementAt(11);
                    string tempPMutationName = mutationDetails.ElementAt(12);
                    string tempCMutationName = mutationDetails.ElementAt(13);
                    string tempCosmicName = mutationDetails.ElementAt(14);
                    toReturn = new Mutation(mutId, tempChrom, tempPosition, tempGeneName, tempRefNuc, tempVarNuc, tempStrand, tempChromNum, tempRefCodon, tempVarCodon, tempRefAA, tempVarAA, tempPMutationName, tempCMutationName, tempCosmicName);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return toReturn;
        }
        public static List<Mutation> getMutationListByTestName(string testName)
        {
            List<Mutation> toReturn = null;
            try
            {
                List<string> tempList = LocalDbDAL.getMutationListPerPatient(testName);
                toReturn = new List<Mutation>();
                foreach (string s in tempList)
                    toReturn.Add(getMutationById(s));

            }
            catch (Exception)
            {
                throw;
            }
            return toReturn;

        }
        public static Mutation getMutationById(string mutId)
        {
            Mutation toReturn = null;
            try
            {
                List<String> mutationDetails = LocalDbDAL.getMutationByID(mutId);
                if (mutationDetails != null)
                {
                    string tempMutId = mutationDetails.ElementAt(0);
                    string tempChrom = mutationDetails.ElementAt(1);
                    int tempPosition = Convert.ToInt32(mutationDetails.ElementAt(2));
                    string tempGeneName = mutationDetails.ElementAt(3);
                    char tempRefNuc = Convert.ToChar(mutationDetails.ElementAt(4));
                    char tempVarNuc = Convert.ToChar(mutationDetails.ElementAt(5));
                    char tempStrand = Convert.ToChar(mutationDetails.ElementAt(6));
                    string tempChromNum = mutationDetails.ElementAt(7);
                    string tempRefCodon = mutationDetails.ElementAt(8);
                    string tempVarCodon = mutationDetails.ElementAt(9);
                    string tempRefAA = mutationDetails.ElementAt(10);
                    string tempVarAA = mutationDetails.ElementAt(11);
                    string tempPMutationName = mutationDetails.ElementAt(12);
                    string tempCMutationName = mutationDetails.ElementAt(13);
                    string tempCosmicName = mutationDetails.ElementAt(14);
                    toReturn = new Mutation(tempMutId, tempChrom, tempPosition, tempGeneName, tempRefNuc, tempVarNuc, tempStrand, tempChromNum, tempRefCodon, tempVarCodon, tempRefAA, tempVarAA, tempPMutationName, tempCMutationName, tempCosmicName);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return toReturn;
        }
        public static void addMutation(Mutation m)
        {
            try
            {
                LocalDbDAL.addMutation(m.MutId, m.Chrom, m.Position, m.GeneName, m.Ref, m.Var, m.Strand, m.ChromNum, m.RefCodon, m.VarCodon, m.RefAA, m.VarAA, m.PMutationName, m.CMutationName, m.CosmicName);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Gene addGene(string geneName, string chrom)
        {
            List<String> geneStrings = null;
            Gene toReturn = null;
            try
            {
                geneStrings = UcscDAL.getGene(geneName, chrom);
                if (geneStrings != null)
                {
                    char strand = Convert.ToChar(geneStrings[0]);
                    int cdsStart = int.Parse(geneStrings[1]);
                    int cdsEnd = int.Parse(geneStrings[2]);
                    int[] exonStars = exonStringToIntArray(geneStrings[4]);
                    int[] exonEnds = exonStringToIntArray(geneStrings[5]);
                    toReturn = new Gene(geneName, chrom, strand, cdsStart, cdsEnd, exonStars, exonEnds);
                    string tempExonStarts = exonIntArrayToString(toReturn.ExonStarts);
                    string tempExonEnds = exonIntArrayToString(toReturn.ExonEnds);

                    LocalDbDAL.addGene(geneName, chrom, strand, tempExonStarts, tempExonEnds);
                }
                return toReturn;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Gene getGene(string geneName, string chrom)
        {
            Gene g = null;
            List<String> geneStrings = null;
            try
            {
                geneStrings = LocalDbDAL.getGene(geneName, chrom);
                if (geneStrings != null)
                {
                    char strand = Convert.ToChar(geneStrings[2]);
                    int[] exonStarts = exonStringToIntArray(geneStrings[3]);
                    int[] exonEnds = exonStringToIntArray(geneStrings[4]);
                    g = new Gene(geneName, chrom, strand, exonStarts, exonEnds);
                }
                return g;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static List<String> getCosmicDetails(string chromNum, int position, char refNuc, char varNuc)
        {
            try
            {
                return UcscDAL.getCosmicDetails(chromNum, position, refNuc, varNuc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool mutationExist(Mutation mutation)
        {
            try
            {

                return LocalDbDAL.mutationExist(mutation.Chrom, mutation.Position, mutation.Ref, mutation.Var);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool patientExistByTestName(string testName)
        {
            try
            {
                return LocalDbDAL.patientExist(testName);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int getNumOfPatientWithSameMutation(string mutationId)
        {
            try
            {
                return LocalDbDAL.getNumOfPatientWithSameMutation(mutationId);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void addPatient(string testName, string id, string fName, string lName, string pathologicalNum, string runNum, string tumourSite, string deseaseLevel, string prevTreatment, string currTreatment, string background, string conclusion)
        {
            try
            {
                LocalDbDAL.addPatient(testName, id, fName, lName, pathologicalNum, runNum, tumourSite, deseaseLevel, prevTreatment, currTreatment, background, conclusion);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void updatePatient(string testName, string id, string fName, string lName, string pathologicalNum, string runNum, string tumourSite, string deseaseLevel, string prevTreatment, string currTreatment, string background, string conclusion)
        {
            try
            {
                LocalDbDAL.updatePatient(testName, id, fName, lName, pathologicalNum, runNum, tumourSite, deseaseLevel, prevTreatment, currTreatment, background, conclusion);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void addMatch(string testName, string mutId)
        {
            try
            {
                LocalDbDAL.addMatch(testName, mutId);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Patient> getPatientListById(string id)
        {
            List<Patient> toReturn = null;
            try
            {
                List<List<string>> patient = LocalDbDAL.getPatientListById(id);
                if (patient != null)
                {
                    toReturn = new List<Patient>();
                    foreach (List<string> l in patient)
                    {
                        string testName = l.ElementAt(0);
                        string patientId = l.ElementAt(1);
                        string fName = l.ElementAt(2);
                        string lName = l.ElementAt(3);
                        string pathoNum = l.ElementAt(4);
                        string runNum = l.ElementAt(5);
                        string tumourSite = l.ElementAt(6);
                        string diseaseLevel = l.ElementAt(7);
                        string background = l.ElementAt(8);
                        string prevTreatment = l.ElementAt(9);
                        string currTreatment = l.ElementAt(10);
                        string conclusion = l.ElementAt(11);
                        Patient p = new Patient(testName, patientId, fName, lName, pathoNum, runNum, tumourSite, diseaseLevel, background, prevTreatment, currTreatment, conclusion);
                        toReturn.Add(p);
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return toReturn;
        }

        public static List<Patient> getPatientListWithMutation(string mutationId)
        {
            List<Patient> toReturn = null;
            try
            {
                List<List<string>> patient = LocalDbDAL.getPatientListByMutation(mutationId);
                if (patient != null)
                {
                    toReturn = new List<Patient>();
                    foreach (List<string> l in patient)
                    {
                        string testName = l.ElementAt(0);
                        string patientId = l.ElementAt(1);
                        string fName = l.ElementAt(2);
                        string lName = l.ElementAt(3);
                        string pathoNum = l.ElementAt(4);
                        string runNum = l.ElementAt(5);
                        string tumourSite = l.ElementAt(6);
                        string diseaseLevel = l.ElementAt(7);
                        string background = l.ElementAt(8);
                        string prevTreatment = l.ElementAt(9);
                        string currTreatment = l.ElementAt(10);
                        string conclusion = l.ElementAt(11);
                        Patient p = new Patient(testName, patientId, fName, lName, pathoNum, runNum, tumourSite, diseaseLevel, background, prevTreatment, currTreatment, conclusion);
                        toReturn.Add(p);
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return toReturn;
        }
        public static string exonIntArrayToString(int[] p)
        {
            string toReturn = "";
            foreach (int n in p)
                toReturn += n + " ";
            return toReturn;
        }
        public static int[] exonStringToIntArray(string exon)
        {
            return Regex.Split(exon, @"\D+").Except(new string[] { "" }).ToArray().Select(x => int.Parse(x)).ToArray();
        }
    }
}
