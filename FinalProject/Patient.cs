using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    /*
     * Patient class holds all patient details
     * Contains only constractor and getters 
     * Main purpose - easy transfer of patient details
     */
    public class Patient
    {
        string _testName;
        string _patientId;
        string _fName;
        string _lName;
        string _pathoNum;
        string _runNum;
        string _tumourSite;
        string _diseaseLevel;
        string _background;
        string _prevTreatment;
        string _currTreatment;
        string _conclusion;

        public Patient(string testName, string id, string fName, string lName, string pathoNum, string runNum, string tumourSite, string diseaseLevel, string background, string prevTreatment, string currTreatment, string conclusion)
        {
            _testName = testName;
            _patientId = id;
            _fName = fName;
            _lName = lName;
            _pathoNum = pathoNum;
            _runNum = runNum;
            _tumourSite = tumourSite;
            _diseaseLevel = diseaseLevel;
            _background = background;
            _prevTreatment = prevTreatment;
            _currTreatment = currTreatment;
            _conclusion = conclusion;
        }

        public override string ToString()
        {
            return _testName + " " + _fName + " " + _lName;
        }
        public string TestName { get { return _testName; } }
        public string PatientID { get { return _patientId; } }
        public string FName { get { return _fName; } }
        public string LName { get { return _lName; } }
        public string PathoNum { get { return _pathoNum; } }
        public string RunNum { get { return _runNum; } }
        public string TumourSite { get { return _tumourSite; } }
        public string DiseaseLevel { get { return _diseaseLevel; } }
        public string Background { get { return _background; } }
        public string PrevTreatment { get { return _prevTreatment; } }
        public string CurrTreatment { get { return _currTreatment; } }
        public string Conclusion { get { return _conclusion; } }
    }
}
