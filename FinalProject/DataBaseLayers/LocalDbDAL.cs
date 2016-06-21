using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;


namespace FinalProject
{
    /*
     * LocalDbDAL class.
     * Main purpose - Data Access Layer for local database.
     */
    public class LocalDbDAL
    {
        //Connection string for debbuging mode using visual studio database.mdf local database
        //static string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\etyem_000\Desktop\College_Of__Engineering\Final Project - DNA\code\FinalProject-master\FinalProject-master\FinalProject\Database.mdf;Integrated Security=True";

        //Connection string for debbuging mode using sql server
        static string connectionString = @"Data Source=ETYE-PC\SQLEXPRESS;Initial Catalog=6B6BBD80FD1798D29B9948E7A24ECA45_TYE MYER - FINAL PROJECT 2016\FINALPROJECT-MASTER\FINALPROJECT-MASTER\FINALPROJECT\DATABASE.MDF;Integrated Security=True";

        //Connection string for publish
        //static string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

        //Get gene by gene name and chromosome, if not exist return null.
        public static List<String> getGene(string geneName, string chrom)
        {
            List<String> toReturn = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@chrom", SqlDbType.NChar).Value = chrom;
                    cmd.Parameters.Add("@geneName", SqlDbType.NChar).Value = geneName;
                    cmd.CommandText = "SELECT * FROM Gene WHERE chrom=@chrom AND name=@geneName";
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            toReturn = new List<string>();
                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                toReturn.Add(rdr.GetString(i));
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return toReturn;

        }

        //Add new gene to database.
        public static List<String> getRefSnp(string chrom, string position, string refNuc, string varNuc)
        {
            List<String> toReturn = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@chrom_num", SqlDbType.NChar).Value = chrom;
                    cmd.Parameters.Add("@chrom_position", SqlDbType.NChar).Value = position;
                    cmd.Parameters.Add("@ref_nuc", SqlDbType.NChar).Value = refNuc;
                    cmd.Parameters.Add("@var_nuc", SqlDbType.NChar).Value = varNuc;
                    cmd.CommandText = "SELECT * FROM RefSnpDB WHERE chrom_num=@chrom_num AND chrom_position=@chrom_position AND ref_nuc=@ref_nuc AND var_nuc=@var_nuc";
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        toReturn = new List<string>();
                        while (rdr.Read())
                        {
                            for (int i = 0; i < 11; i++)
                            {
                                toReturn.Add(rdr.GetString(i).Trim());
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return toReturn;
        }
        public static void addGene(string name, string chrom, char strand, string exonStarts, string exonEnds)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@name", SqlDbType.NChar).Value = name;
                    cmd.Parameters.Add("@chrom", SqlDbType.NChar).Value = chrom;
                    cmd.Parameters.Add("@strand", SqlDbType.NChar).Value = strand;
                    cmd.Parameters.Add("@exonStarts", SqlDbType.NChar).Value = exonStarts;
                    cmd.Parameters.Add("@exonEnds", SqlDbType.NChar).Value = exonEnds;
                    cmd.CommandText = "INSERT INTO Gene VALUES (@name,@chrom,@strand,@exonStarts,@exonEnds)";
                    cmd.ExecuteNonQuery();
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get mutation by mutation id, if not exist return null.
        public static List<String> getMutationByID(string mutId)
        {
            List<String> toReturn = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@mutId", SqlDbType.NChar).Value = mutId;
                    cmd.CommandText = "SELECT * FROM Mutation WHERE mut_id=@mutId";
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            toReturn = new List<string>();
                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                string toAdd = rdr.GetString(i).Trim();
                                if (toAdd.Equals(""))
                                    toReturn.Add(null);
                                else
                                    toReturn.Add(toAdd);
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return toReturn;
        }

        //Get mutation by full details, if not exist return null.
        public static List<String> getMutationByDetails(string chrom, int position, char varNuc, char refNuc)
        {
            List<String> toReturn = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@chrom", SqlDbType.NChar).Value = chrom;
                    cmd.Parameters.Add("@position", SqlDbType.NChar).Value = position;
                    cmd.Parameters.Add("@ref", SqlDbType.NChar).Value = refNuc;
                    cmd.Parameters.Add("@var", SqlDbType.NChar).Value = varNuc;
                    cmd.CommandText = "SELECT * FROM Mutation WHERE chrom=@chrom AND position=@position AND ref=@ref AND var=@var";
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            toReturn = new List<string>();
                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                string toAdd = rdr.GetString(i).Trim();
                                if (toAdd.Equals(""))
                                    toReturn.Add(null);
                                else
                                    toReturn.Add(toAdd);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return toReturn;
        }

        //Get the list of the mutations that matches test name. return null if test name not exist.
        public static List<string> getMutationListPerPatient(string testName)
        {
            List<String> toReturn = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@testName", SqlDbType.NChar).Value = testName;
                    cmd.CommandText = "SELECT mutation_id FROM Matches WHERE test_name=@testName";
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        toReturn = new List<string>();
                        while (rdr.Read())
                        {
                            toReturn.Add(rdr.GetString(0).Trim());
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return toReturn;
        }

        //Add new mutation to database.
        public static void addMutation(string mutId, string chrom, int position, string geneName, char refNuc, char varNuc, char strand, string chromNum, string refCodon, string varCodon, string refAA, string varAA, string pMutationName, string cMutationName, string cosmicName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@mutId", SqlDbType.NChar).Value = mutId;
                    cmd.Parameters.Add("@chrom", SqlDbType.NChar).Value = chrom;
                    cmd.Parameters.Add("@position", SqlDbType.NChar).Value = position;
                    cmd.Parameters.Add("@geneName", SqlDbType.NChar).Value = geneName;
                    cmd.Parameters.Add("@refNuc", SqlDbType.NChar).Value = refNuc;
                    cmd.Parameters.Add("@varNuc", SqlDbType.NChar).Value = varNuc;
                    cmd.Parameters.Add("@strand", SqlDbType.NChar).Value = strand;
                    cmd.Parameters.Add("@chromNum", SqlDbType.NChar).Value = chromNum;
                    cmd.Parameters.Add("@refCodon", SqlDbType.NChar).Value = refCodon;
                    cmd.Parameters.Add("@varCodon", SqlDbType.NChar).Value = varCodon;
                    cmd.Parameters.Add("@refAA", SqlDbType.NChar).Value = refAA;
                    cmd.Parameters.Add("@varAA", SqlDbType.NChar).Value = varAA;
                    cmd.Parameters.Add("@pMutationName", SqlDbType.NChar).Value = pMutationName;
                    cmd.Parameters.Add("@cMutationName", SqlDbType.NChar).Value = cMutationName;
                    cmd.Parameters.Add("@cosmicName", SqlDbType.NChar).Value = cosmicName;
                    cmd.CommandText = "INSERT INTO Mutation VALUES(@mutId,@chrom,@position,@geneName,@refNuc,@varNuc,@strand,@chromNum,@refCodon,@varCodon,@refAA,@varAA,@pMutationName,@cMutationName,@cosmicName)";
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        //Return true if mutation is allready in database,false otherwise.
        public static bool mutationExist(string chrom, int position, char refNuc, char varNuc)
        {
            bool toReturn = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@chrom", SqlDbType.NChar).Value = chrom;
                    cmd.Parameters.Add("@position", SqlDbType.NChar).Value = position;
                    cmd.Parameters.Add("@refNuc", SqlDbType.NChar).Value = refNuc;
                    cmd.Parameters.Add("@varNuc", SqlDbType.NChar).Value = varNuc;
                    cmd.CommandText = "SELECT * FROM Mutation WHERE chrom=@chrom AND position=@position AND ref=@refNuc AND var=@varNuc";
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            toReturn = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return toReturn;
        }

        //Return true if patient exist in database,false otherwise. search by test name.
        public static bool patientExist(string testName)
        {
            bool toReturn = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@testName", SqlDbType.NChar).Value = testName;
                    cmd.CommandText = "SELECT * FROM Patients WHERE test_name=@testName";
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            toReturn = true;
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return toReturn;
        }

        //Add new patient to database.
        public static void addPatient(string testName, string id, string fName, string lName, string pathologicalNum, string runNum, string tumourSite, string diseaseLevel, string background, string prevTreatment, string currTreatment, string conclusion)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@testName", SqlDbType.NChar).Value = testName;
                    cmd.Parameters.Add("@id", SqlDbType.NChar).Value = id;
                    cmd.Parameters.Add("@fName", SqlDbType.NChar).Value = fName;
                    cmd.Parameters.Add("@lName", SqlDbType.NChar).Value = lName;
                    cmd.Parameters.Add("@pathologicalNum", SqlDbType.NChar).Value = pathologicalNum;
                    cmd.Parameters.Add("@runNum", SqlDbType.NChar).Value = runNum;
                    cmd.Parameters.Add("@tumourSite", SqlDbType.NChar).Value = tumourSite;
                    cmd.Parameters.Add("@diseaseLevel", SqlDbType.NChar).Value = diseaseLevel;
                    cmd.Parameters.Add("@prevTreatment", SqlDbType.NChar).Value = prevTreatment;
                    cmd.Parameters.Add("@currTreatment", SqlDbType.NChar).Value = currTreatment;
                    cmd.Parameters.Add("@background", SqlDbType.NChar).Value = background;
                    cmd.Parameters.Add("@conclusion", SqlDbType.NChar).Value = conclusion;
                    cmd.CommandText = "INSERT INTO Patients VALUES (@testName,@id,@fName,@lName,@pathologicalNum,@runNum,@tumourSite,@diseaseLevel,@background,@prevTreatment,@currTreatment,@conclusion)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Update exist patient.
        public static void updatePatient(string testName, string id, string fName, string lName, string pathologicalNum, string runNum, string tumourSite, string diseaseLevel, string prevTreatment, string currTreatment, string background, string conclusion)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@id", SqlDbType.NChar).Value = id;
                    cmd.Parameters.Add("@fName", SqlDbType.NChar).Value = fName;
                    cmd.Parameters.Add("@lName", SqlDbType.NChar).Value = lName;
                    cmd.Parameters.Add("@pathologicalNum", SqlDbType.NChar).Value = pathologicalNum;
                    cmd.Parameters.Add("@runNum", SqlDbType.NChar).Value = runNum;
                    cmd.Parameters.Add("@tumourSite", SqlDbType.NChar).Value = tumourSite;
                    cmd.Parameters.Add("@diseaseLevel", SqlDbType.NChar).Value = diseaseLevel;
                    cmd.Parameters.Add("@prevTreatment", SqlDbType.NChar).Value = prevTreatment;
                    cmd.Parameters.Add("@currTreatment", SqlDbType.NChar).Value = currTreatment;
                    cmd.Parameters.Add("@background", SqlDbType.NChar).Value = background;
                    cmd.Parameters.Add("@conclusion", SqlDbType.NChar).Value = conclusion;
                    cmd.Parameters.Add("@testName", SqlDbType.NChar).Value = testName;
                    cmd.CommandText = "UPDATE Patients SET id=@id,first_name=@fName,last_name=@lName,pathological_number=@pathologicalNum"
                        + ",run_number=@runNum,tumour_site=@tumourSite,disease_level=@diseaseLevel,previous_treatment=@prevTreatment"
                        + ",current_treatment=@currTreatment,background=@background,conclusion=@conclusion,test_name=@testName "
                        + "WHERE test_name=@testName";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Add match of test name an mutation id to Matches table.
        public static void addMatch(string testName, string mutId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@testName", SqlDbType.NChar).Value = testName;
                    cmd.Parameters.Add("@mutId", SqlDbType.NChar).Value = mutId;
                    cmd.CommandText = "INSERT into Matches VALUES (@testName,@mutId)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Count number of patient that matches mutation, by mutation id.
        public static int getNumOfPatientWithSameMutation(string mutId)
        {
            int toReturn = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@mutId", SqlDbType.NChar).Value = mutId;
                    cmd.CommandText = "SELECT COUNT(DISTINCT test_name) FROM Matches WHERE mutation_id=@mutId";
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            toReturn = rdr.GetInt32(0);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return toReturn;
        }

        //Get all tests for specific patient, search by patient id.
        public static List<List<string>> getPatientListById(string id)
        {
            List<List<String>> toReturn = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@id", SqlDbType.NChar).Value = id;
                    cmd.CommandText = "SELECT * FROM Patients WHERE id=@id";
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        bool first = true;
                        while (rdr.Read())
                        {
                            if (first)
                            {
                                toReturn = new List<List<string>>();
                                first = false;
                            }
                            List<string> l = new List<string>();
                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                l.Add(rdr.GetString(i).Trim());
                            }
                            toReturn.Add(l);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return toReturn;
        }

        //Get all patients that matches same mutation, search by mutation id.
        public static List<List<string>> getPatientListByMutation(string mutationId)
        {
            List<List<String>> toReturn = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@mutationId", SqlDbType.NChar).Value = mutationId;
                    cmd.CommandText = "SELECT * FROM Patients,Matches WHERE Matches.test_name=Patients.test_name AND Matches.mutation_id=@mutationId";
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        bool first = true;
                        while (rdr.Read())
                        {
                            if (first)
                            {
                                toReturn = new List<List<string>>();
                                first = false;
                            }

                            List<string> l = new List<string>();
                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                l.Add(rdr.GetString(i).Trim());
                            }
                            toReturn.Add(l);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return toReturn;
        }

        //Add refSNP to the DB
        public static void addRefSnp(string num,string pos,string refNuc,string varNuc,string rsId,string clinSig,string popDiv,string maf,string chrSamCnt,string allele,string allelePerc)
        {
            if (rsId.Equals("") || rsId == null)
            {
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    
                   
                    
                    cmd.Parameters.Add("@chrom_num", SqlDbType.NChar).Value = num;
                    cmd.Parameters.Add("@chrom_position", SqlDbType.NChar).Value = pos;
                    cmd.Parameters.Add("@ref_nuc", SqlDbType.NChar).Value = refNuc;
                    cmd.Parameters.Add("@var_nuc", SqlDbType.NChar).Value = varNuc;
                    cmd.Parameters.Add("@rsid", SqlDbType.NChar).Value = rsId;
                    cmd.Parameters.Add("@clinical_significance", SqlDbType.NChar).Value = clinSig;
                    cmd.Parameters.Add("@population_diversity", SqlDbType.NChar).Value = popDiv;
                    cmd.Parameters.Add("@maf", SqlDbType.Text).Value = maf;
                    cmd.Parameters.Add("@chrom_sample_count", SqlDbType.NChar).Value = chrSamCnt;
                    cmd.Parameters.Add("@alleles", SqlDbType.NChar).Value = allele;
                    cmd.Parameters.Add("@alleles_percentage", SqlDbType.NChar).Value = allelePerc;


                    cmd.CommandText = "INSERT INTO RefSnpDB VALUES (@chrom_num,@chrom_position,@ref_nuc,@var_nuc,@rsid,@clinical_significance,@population_diversity,@maf,@chrom_sample_count,@alleles,@alleles_percentage)";
                    
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                throw;
            }
             
        }
        public static void addTumor(string patientId, string tumorSite, string pathNum, string bloodTestNum)
        {
            String tumorId;
            if (pathNum == "" && bloodTestNum == "")
            {
                return;
            }
            else if (pathNum != "")
            {
                tumorId = "P_" + pathNum;
            }
            else
            {
                tumorId = "B_" + bloodTestNum;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@tumorId", SqlDbType.NChar).Value = tumorId;
                    cmd.Parameters.Add("@patientId", SqlDbType.NChar).Value = patientId;
                    cmd.Parameters.Add("@tumorSite", SqlDbType.NChar).Value = tumorSite;
                    cmd.Parameters.Add("@pathNum", SqlDbType.Text).Value = pathNum;
                    cmd.Parameters.Add("@bloodTestNum", SqlDbType.Text).Value = bloodTestNum;
                    cmd.CommandText = "INSERT into Tumors VALUES (@tumorId,@patientId,@tumorSite,@pathNum,@bloodTestNum)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void addRelative(string relation,string id,string date,string location,string about)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@Relation", SqlDbType.NChar).Value = relation;
                    cmd.Parameters.Add("@patient_id", SqlDbType.NChar).Value = id;
                    cmd.Parameters.Add("@date_of_illness", SqlDbType.NChar).Value = date;
                    cmd.Parameters.Add("@location_of_illness", SqlDbType.Text).Value = location;
                    cmd.Parameters.Add("@about", SqlDbType.Text).Value = about;
                    cmd.CommandText = "INSERT into Relatives VALUES (@patient_id,@Relation,@date_of_illness,@location_of_illness,@about)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void deleteRelative(string relation,string id,string date,string location,string about){
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "DELETE FROM Relatives WHERE patient_id=@patient_id AND Relation=@Relation AND date_of_illness=@date_of_illness AND location_of_illness=@location_of_illness AND about=@about";
                    cmd.Parameters.Add("@Relation", SqlDbType.NChar).Value = relation;
                    cmd.Parameters.Add("@patient_id", SqlDbType.NChar).Value = id;
                    cmd.Parameters.Add("@date_of_illness", SqlDbType.NChar).Value = date;
                    cmd.Parameters.Add("@location_of_illness", SqlDbType.NChar).Value = location;
                    cmd.Parameters.Add("@about", SqlDbType.NChar).Value = about;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void deleteTumor(string patientId,string tumorSite, string pathNum, string bloodTestNum)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    //cmd.CommandText = "DELETE FROM Tumors WHERE patient_id=@patient_id AND Relation=@Relation AND date_of_illness=@date_of_illness AND location_of_illness=@location_of_illness AND about=@about";
                    cmd.Parameters.Add("@patientId", SqlDbType.NChar).Value = patientId;
                    cmd.Parameters.Add("@tumorSite", SqlDbType.NChar).Value = tumorSite;
                    cmd.Parameters.Add("@pathNum", SqlDbType.NChar).Value = pathNum;
                    cmd.Parameters.Add("@bloodTestNum", SqlDbType.NChar).Value = bloodTestNum;
                    cmd.CommandText = "DELETE FROM Tumors WHERE patientId=@patientId AND tumorSite=@tumorSite AND pathNum=@pathNum AND bloodTestNum=@bloodTestNum";

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool isRefSnpExists(string num,string pos,string varNuc,string refNuc)
        {
            bool toReturn = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.Parameters.Add("@chrom_num", SqlDbType.NChar).Value = num;
                    cmd.Parameters.Add("@chrom_position", SqlDbType.NChar).Value = pos;
                    cmd.Parameters.Add("@ref_nuc", SqlDbType.NChar).Value = refNuc;
                    cmd.Parameters.Add("@var_nuc", SqlDbType.NChar).Value = varNuc;
                    cmd.CommandText = "SELECT * FROM RefSnpDB WHERE chrom_num=@chrom_num AND chrom_position=@chrom_position AND ref_nuc=@ref_nuc AND var_nuc=@var_nuc";
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            toReturn = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return toReturn;
        }
        public static string getConnectionString()
        {
            return connectionString;
        }
    }
}
